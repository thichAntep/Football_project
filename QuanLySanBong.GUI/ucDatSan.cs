using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLySanBong.BUS;
using QuanLySanBong.DTO;

namespace QuanLySanBong.GUI
{
    // File này đi cùng ucDatSan.Designer.cs của bạn (tblMain, tblTrai, tblPhai, tblLoc, tblFieds,
    // fplChuThich, fplSoDoSan, txtKhunGio, tableLayoutPanel1 ...). Không đổi tên control trong Designer.
    public partial class ucDatSan : UserControl
    {
        private readonly DatSanBUS bus = new DatSanBUS();

        private DateTime ngayDangXem = DateTime.Today;  // ngày của lần Tìm Kiếm gần nhất
        private OSanDTO oDangChon;
        private Button nutDangChon;

        // màu khớp với phần chú thích
        private static readonly Color MauTrong = Color.Lime;
        private static readonly Color MauDaDat = Color.Yellow;
        private static readonly Color MauDangDa = Color.Red;
        private static readonly Color MauBaoTri = Color.Gray;

        private Font fontO;     // chữ trong ô khung giờ (nhỏ hơn chữ chính)
        private Font fontTen;   // chữ tên sân (đậm)

        public ucDatSan()
        {
            InitializeComponent();
            PhienDangNhap.MaTK = 2;
            Load += ucDatSan_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnDatSan.Click += btnDatSan_Click;
            btnHuyPhieu.Click += btnHuyPhieu_Click;
            btnLamMoi.Click += (s, e) => LamMoiPhieu();
            txtSDT.Leave += txtSDT_Leave;
        }

        // ================== LOAD ==================
        private void ucDatSan_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                fontO = new Font(Font.FontFamily, Font.SizeInPoints * 0.7f);
                fontTen = new Font(Font.FontFamily, Font.SizeInPoints * 0.8f, FontStyle.Bold);

                ChinhGiaoDien();
                TaoChuThich();

                dtpNgay.Value = DateTime.Today;

                var dsLoai = bus.LayLoaiSan();
                dsLoai.Insert(0, new LoaiSanDTO { MaLoai = 0, TenLoai = "Tất cả loại sân" });
                cboLoaiSan.DropDownStyle = ComboBoxStyle.DropDownList;
                cboLoaiSan.DisplayMember = "TenLoai";
                cboLoaiSan.ValueMember = "MaLoai";
                cboLoaiSan.DataSource = dsLoai;
                cboLoaiSan.SelectedIndex = 0;

                LamMoiPhieu();
                TimKiem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        /// <summary>Bù những thuộc tính mà Designer của bạn chưa đặt (dock, anchor, chỉ-đọc...).</summary>
        private void ChinhGiaoDien()
        {
            // cho các panel con lấp đầy ô của bảng
            tblLoc.Dock = DockStyle.Fill;
            tableLayoutPanel1.Dock = DockStyle.Fill;

            // ô nhập co giãn theo chiều ngang, tự căn giữa theo chiều dọc
            var cacOTextBox = new TextBox[] { txtSan, txtNgay, txtKhunGio, txtDonGia, txtSDT, txtTenKH };
            foreach (var tb in cacOTextBox)
                tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numTienCoc.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            txtGhiChu.Multiline = true;
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Dock = DockStyle.Fill;

            // các ô chỉ để hiển thị
            txtSan.ReadOnly = true;
            txtNgay.ReadOnly = true;
            txtKhunGio.ReadOnly = true;
            txtDonGia.ReadOnly = true;

            txtSDT.MaxLength = 11;

            numTienCoc.ThousandsSeparator = true;
            numTienCoc.Increment = 50000;

            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.CustomFormat = "dddd, dd/MM/yyyy";

            fplSoDoSan.FlowDirection = FlowDirection.TopDown;
            fplSoDoSan.WrapContents = false;
            fplSoDoSan.AutoScroll = true;
        }

        /// <summary>Vẽ phần chú thích màu vào fplChuThich (Designer đang để trống).</summary>
        private void TaoChuThich()
        {
            fplChuThich.Controls.Clear();
            fplChuThich.FlowDirection = FlowDirection.LeftToRight;
            fplChuThich.WrapContents = true;

            fplChuThich.Controls.Add(TaoNhanChuThich("Chú Thích", true));
            ThemMucChuThich(MauTrong, "Trống");
            ThemMucChuThich(MauDaDat, "Đã Đặt");
            ThemMucChuThich(MauDangDa, "Đang Đá");
            ThemMucChuThich(MauBaoTri, "Đang Bảo Trì");
        }

        private Label TaoNhanChuThich(string text, bool dam)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = dam ? fontTen : fontO,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(6, 8, 6, 3)
            };
        }

        private void ThemMucChuThich(Color mau, string text)
        {
            int c = (int)(fontO.Height * 1.3);
            fplChuThich.Controls.Add(new Panel
            {
                BackColor = mau,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(c, c),
                Margin = new Padding(6, 6, 2, 3)
            });
            fplChuThich.Controls.Add(TaoNhanChuThich(text, false));
        }

        // ================== SƠ ĐỒ ==================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            try
            {
                int maLoai = cboLoaiSan.SelectedValue is int v ? v : 0;
                ngayDangXem = dtpNgay.Value.Date;

                var ds = bus.LaySoDo(ngayDangXem, maLoai);

                LamMoiPhieu();
                fplSoDoSan.SuspendLayout();
                fplSoDoSan.Controls.Clear();

                if (ds.Count == 0)
                {
                    fplSoDoSan.Controls.Add(new Label
                    {
                        Text = "Không có sân phù hợp.",
                        AutoSize = true,
                        Font = fontO,
                        Margin = new Padding(10)
                    });
                    fplSoDoSan.ResumeLayout();
                    return;
                }

                var nhomSan = ds.GroupBy(x => x.MaSan).ToList();
                int soKhung = Math.Max(1, ds.Select(x => x.MaKhungGio).Distinct().Count());

                // kích thước tự tính theo cỡ chữ và bề rộng vùng sơ đồ, nên không bị lệch khi màn hình scale
                int rongNhan = nhomSan.Max(g => TextRenderer.MeasureText(g.First().TenSan, fontTen).Width) + 16;
                rongNhan = Math.Max(rongNhan, 80);
                int khaDung = fplSoDoSan.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - rongNhan - 24;
                int rongO = Math.Max(110, khaDung / soKhung - 8);
                int caoO = fontO.Height * 3 + 16;

                foreach (var nhom in nhomSan)
                {
                    var hang = new FlowLayoutPanel
                    {
                        AutoSize = true,
                        WrapContents = false,
                        FlowDirection = FlowDirection.LeftToRight,
                        Margin = new Padding(3, 3, 3, 8)
                    };

                    hang.Controls.Add(new Label
                    {
                        Text = nhom.First().TenSan,
                        Width = rongNhan,
                        Height = caoO,
                        Font = fontTen,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Margin = new Padding(3)
                    });

                    foreach (var o in nhom)
                        hang.Controls.Add(TaoNutO(o, rongO, caoO));

                    fplSoDoSan.Controls.Add(hang);
                }
                fplSoDoSan.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private Button TaoNutO(OSanDTO o, int rong, int cao)
        {
            var btn = new Button
            {
                Width = rong,
                Height = cao,
                Margin = new Padding(3),
                Font = fontO,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                BackColor = MauO(o.TrangThai),
                ForeColor = o.TrangThai == TrangThaiO.DangDa ? Color.White : Color.Black,
                Text = o.TenKhungGio + Environment.NewLine + MoTa(o),
                Tag = o
            };
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.DimGray;
            btn.Click += NutO_Click;
            return btn;
        }

        private static Color MauO(TrangThaiO t)
        {
            switch (t)
            {
                case TrangThaiO.Trong: return MauTrong;
                case TrangThaiO.DaDat: return MauDaDat;
                case TrangThaiO.DangDa: return MauDangDa;
                default: return MauBaoTri;
            }
        }

        private static string MoTa(OSanDTO o)
        {
            switch (o.TrangThai)
            {
                case TrangThaiO.Trong: return "Trống - " + o.DonGia.ToString("N0") + "đ";
                case TrangThaiO.DaDat: return "Đã đặt: " + o.TenKhachDat;
                case TrangThaiO.DangDa: return "Đang đá: " + o.TenKhachDat;
                default: return "Bảo trì";
            }
        }

        private void NutO_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var o = (OSanDTO)btn.Tag;

            // bỏ viền chọn cũ, tô viền chọn mới
            BoVienChon();
            nutDangChon = btn;
            btn.FlatAppearance.BorderSize = 3;
            btn.FlatAppearance.BorderColor = Color.Blue;
            oDangChon = o;

            try
            {
                switch (o.TrangThai)
                {
                    case TrangThaiO.Trong:
                        HienPhieuMoi(o);
                        break;
                    case TrangThaiO.DaDat:
                    case TrangThaiO.DangDa:
                        HienPhieuCu(o);
                        break;
                    default:
                        MessageBox.Show("Sân đang bảo trì, không thể đặt.");
                        LamMoiPhieu();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BoVienChon()
        {
            if (nutDangChon != null && !nutDangChon.IsDisposed)
            {
                nutDangChon.FlatAppearance.BorderSize = 1;
                nutDangChon.FlatAppearance.BorderColor = Color.DimGray;
            }
            nutDangChon = null;
        }

        // ================== PHIẾU ĐẶT ==================
        private void BatNhap(bool cho)
        {
            txtSDT.ReadOnly = !cho;
            txtTenKH.ReadOnly = !cho;
            txtGhiChu.ReadOnly = !cho;
            numTienCoc.Enabled = cho;
        }

        private void LamMoiPhieu()
        {
            BoVienChon();
            oDangChon = null;

            txtSan.Clear();
            txtNgay.Clear();
            txtKhunGio.Clear();
            txtDonGia.Clear();
            txtSDT.Clear();
            txtTenKH.Clear();
            txtGhiChu.Clear();
            numTienCoc.Maximum = 1000000000m;
            numTienCoc.Value = 0;

            BatNhap(false);
            btnDatSan.Enabled = false;
            btnHuyPhieu.Enabled = false;
        }

        private void HienPhieuMoi(OSanDTO o)
        {
            txtSan.Text = o.TenSan;
            txtNgay.Text = ngayDangXem.ToString("dd/MM/yyyy");
            txtKhunGio.Text = o.TenKhungGio;
            txtDonGia.Text = o.DonGia.ToString("N0") + " đ";

            txtSDT.Clear();
            txtTenKH.Clear();
            txtGhiChu.Clear();
            numTienCoc.Value = 0;
            numTienCoc.Maximum = o.DonGia;

            BatNhap(true);
            btnDatSan.Enabled = true;
            btnHuyPhieu.Enabled = false;
            txtSDT.Focus();
        }

        private void HienPhieuCu(OSanDTO o)
        {
            var p = bus.LayPhieu(o.MaPhieu.Value);
            if (p == null)
            {
                MessageBox.Show("Không tìm thấy phiếu đặt.");
                return;
            }

            txtSan.Text = o.TenSan;
            txtNgay.Text = p.NgayDat.ToString("dd/MM/yyyy");
            txtKhunGio.Text = o.TenKhungGio;
            txtDonGia.Text = p.DonGia.ToString("N0") + " đ";
            txtSDT.Text = p.SoDienThoai;
            txtTenKH.Text = p.TenKH;
            txtGhiChu.Text = p.GhiChu;
            numTienCoc.Maximum = 1000000000m;
            numTienCoc.Value = p.TienCoc;

            BatNhap(false);
            btnDatSan.Enabled = false;
            btnHuyPhieu.Enabled = o.TrangThai == TrangThaiO.DaDat;  // đang đá thì không cho hủy
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (oDangChon == null || oDangChon.TrangThai != TrangThaiO.Trong) return;
            try
            {
                var kh = bus.TimKhach(txtSDT.Text);
                if (kh != null) txtTenKH.Text = kh.TenKH;   // khách cũ: tự điền tên
            }
            catch { /* bỏ qua lỗi tra cứu, khách vẫn nhập tay được */ }
        }

        private void btnDatSan_Click(object sender, EventArgs e)
        {
            try
            {
                string loi;
                bool ok = bus.DatSan(oDangChon, ngayDangXem, txtSDT.Text, txtTenKH.Text,
                                     numTienCoc.Value, txtGhiChu.Text, out loi);
                if (!ok)
                {
                    MessageBox.Show(loi, "Không đặt được");
                    return;
                }
                MessageBox.Show("Đặt sân thành công!");
                TimKiem();   // tải lại sơ đồ, ô vừa đặt chuyển sang vàng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt sân: " + ex.Message);
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (oDangChon == null || !oDangChon.MaPhieu.HasValue) return;

            if (MessageBox.Show("Hủy phiếu đặt này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (bus.HuyPhieu(oDangChon.MaPhieu.Value))
                {
                    MessageBox.Show("Đã hủy phiếu.");
                    TimKiem();
                }
                else
                {
                    MessageBox.Show("Không hủy được phiếu (có thể đã bị hủy trước đó).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hủy phiếu: " + ex.Message);
            }
        }
    }
}