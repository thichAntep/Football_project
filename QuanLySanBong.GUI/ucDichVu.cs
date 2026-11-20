using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLySanBong.BUS;
using QuanLySanBong.DTO;

namespace QuanLySanBong.GUI
{
    // File này đi cùng ucDichVu.Designer.cs của bạn. Không đổi tên control trong Designer.
    public partial class ucDichVu : UserControl
    {
        private readonly DichVuBUS bus = new DichVuBUS();

        private List<DichVuDTO> dsDichVuHienTai = new List<DichVuDTO>();
        private Font fontO;     // chữ chi tiết món
        private Font fontTen;   // chữ tên món (đậm)

        public ucDichVu()
        {
            InitializeComponent();

            Load += ucDichVu_Load;
            txtTimKiem.TextChanged += (s, e) => LocDichVu();
            cboLoaiDV.SelectedIndexChanged += (s, e) => LocDichVu();
            cboSanDangDa.SelectedIndexChanged += cboSanDangDa_SelectedIndexChanged;
            btnThanhToan.Click += btnThanhToan_Click;
            btnInHoaDon.Click += btnInHoaDon_Click;
        }

        // ================== LOAD ==================
        private void ucDichVu_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                fontO = new Font(Font.FontFamily, Font.SizeInPoints * 0.85f);
                fontTen = new Font(Font.FontFamily, Font.SizeInPoints * 0.95f, FontStyle.Bold);

                ChinhGiaoDien();
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ChinhGiaoDien()
        {
            tblMain.Dock = DockStyle.Fill;
            tblLeft.Dock = DockStyle.Fill;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel3.Dock = DockStyle.Fill;

            txtTimKiem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.PlaceholderText = "🔍 Nhập tên món/dịch vụ cần tìm...";

            cboLoaiDV.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboLoaiDV.DropDownStyle = ComboBoxStyle.DropDownList;

            cboSanDangDa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboSanDangDa.DropDownStyle = ComboBoxStyle.DropDownList;

            fplDichVu.Dock = DockStyle.Fill;
            fplDichVu.AutoScroll = true;

            // Bảng hiển thị chi tiết phiếu
            dgvPhieu.AutoGenerateColumns = false;
            dgvPhieu.AllowUserToAddRows = false;
            dgvPhieu.RowHeadersVisible = false;
            dgvPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieu.Columns.Clear();

            dgvPhieu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMaDV", DataPropertyName = "MaDV", Visible = false });
            dgvPhieu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTenDV", HeaderText = "Tên Dịch Vụ", DataPropertyName = "TenDV", FillWeight = 42, ReadOnly = true });
            dgvPhieu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSoLuong", HeaderText = "SL", DataPropertyName = "SoLuong", FillWeight = 15, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }, ReadOnly = true });
            dgvPhieu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDonGia", HeaderText = "Đơn Giá", DataPropertyName = "DonGia", FillWeight = 20, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }, ReadOnly = true });
            dgvPhieu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colThanhTien", HeaderText = "T.Tiền", DataPropertyName = "ThanhTien", FillWeight = 23, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }, ReadOnly = true });
            dgvPhieu.Columns.Add(new DataGridViewButtonColumn { Name = "colXoa", HeaderText = "Xóa", Text = "✕", UseColumnTextForButtonValue = true, FillWeight = 12 });
        }

        private void TaiDuLieu()
        {
            // 1. Tải danh sách sân đang đá
            var dsSan = bus.LayDanhSachSan();
            cboSanDangDa.DisplayMember = "TenSan";
            cboSanDangDa.ValueMember = "MaSan";
            cboSanDangDa.DataSource = dsSan;

            // 2. Tải danh mục đơn vị tính (Loại)
            var dsDVT = bus.LayDanhSachDVT();
            dsDVT.Insert(0, "-- Tất cả loại dịch vụ --");
            cboLoaiDV.DataSource = dsDVT;

            // 3. Tải danh sách dịch vụ
            TaiDanhSachMon();

            // 4. Tải chi tiết phiếu của sân đang chọn
            if (cboSanDangDa.SelectedValue is int maSan)
                TaiChiTietPhieu(maSan);
        }

        private void TaiDanhSachMon()
        {
            dsDichVuHienTai = bus.LayDanhSachDichVu();
            LocDichVu();
        }

        // ================== HIỂN THỊ THẺ DỊCH VỤ ==================
        private void HienThiSoDoDichVu(List<DichVuDTO> list)
        {
            fplDichVu.SuspendLayout();
            fplDichVu.Controls.Clear();

            if (list.Count == 0)
            {
                fplDichVu.Controls.Add(new Label { Text = "Không có dịch vụ nào phù hợp.", AutoSize = true, Font = fontO, ForeColor = Color.Gray, Margin = new Padding(15) });
                fplDichVu.ResumeLayout();
                return;
            }

            foreach (var dv in list)
            {
                bool conHang = dv.SoLuongTon > 0;
                var btn = new Button
                {
                    Width = 180,
                    Height = 110,
                    Margin = new Padding(6),
                    Font = fontO,
                    FlatStyle = FlatStyle.Flat,
                    UseVisualStyleBackColor = false,
                    BackColor = conHang ? Color.White : Color.FromArgb(240, 240, 240),
                    ForeColor = conHang ? Color.Black : Color.DimGray,
                    Enabled = conHang,
                    Cursor = conHang ? Cursors.Hand : Cursors.No,
                    Text = $"{dv.TenDV}\n\n{dv.DonGia:N0} đ / {dv.DVT}\n" + (conHang ? $"(Còn: {dv.SoLuongTon})" : "HẾT HÀNG"),
                    Tag = dv
                };

                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = conHang ? Color.FromArgb(0, 150, 136) : Color.LightGray;
                btn.Click += NutDichVu_Click;
                fplDichVu.Controls.Add(btn);
            }

            fplDichVu.ResumeLayout();
        }

        private void NutDichVu_Click(object sender, EventArgs e)
        {
            if (cboSanDangDa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sân đang đá trước khi gọi dịch vụ!");
                return;
            }

            int maSan = (int)cboSanDangDa.SelectedValue;
            var dv = (DichVuDTO)((Button)sender).Tag;

            if (!bus.ThemDichVu(maSan, dv, out string thongBao))
            {
                MessageBox.Show(thongBao);
                return;
            }

            TaiChiTietPhieu(maSan);
            TaiDanhSachMon();
        }

        private void TaiChiTietPhieu(int maSan)
        {
            var ds = bus.LayChiTiet(maSan, out _);
            dgvPhieu.DataSource = ds;

            decimal tong = ds.Sum(x => x.ThanhTien);
            btnThanhToan.Text = tong > 0 ? $"Thanh Toán ({tong:N0} đ)" : "Thanh Toán";
        }

        // ================== CÁC SỰ KIỆN GIAO DIỆN ==================
        private void dgvPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPhieu.Columns[e.ColumnIndex].Name == "colXoa")
            {
                if (cboSanDangDa.SelectedValue == null) return;
                int maSan = (int)cboSanDangDa.SelectedValue;

                var item = (ChiTietDichVuDTO)dgvPhieu.Rows[e.RowIndex].DataBoundItem;
                var res = MessageBox.Show(
                    $"Bạn muốn làm gì với món '{item.TenDV}'?\n- YES: Giảm 1 số lượng (hoàn kho)\n- NO: Xóa bỏ hẳn món khỏi phiếu",
                    "Thao tác món", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    bus.XoaDichVu(maSan, item.MaDV, item.SoLuong, item.DonGia, true);
                }
                else if (res == DialogResult.No)
                {
                    bus.XoaDichVu(maSan, item.MaDV, item.SoLuong, item.DonGia, false);
                }

                if (res != DialogResult.Cancel)
                {
                    TaiChiTietPhieu(maSan);
                    TaiDanhSachMon();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void LocDichVu()
        {
            string tuKhoa = (txtTimKiem.Text ?? "").Trim().ToLower();
            string dvtChon = cboLoaiDV.SelectedIndex > 0 ? cboLoaiDV.SelectedItem.ToString() : "";

            var dsLoc = dsDichVuHienTai.Where(x =>
                (string.IsNullOrEmpty(dvtChon) || x.DVT == dvtChon) &&
                (string.IsNullOrEmpty(tuKhoa) || x.TenDV.ToLower().Contains(tuKhoa))
            ).ToList();

            HienThiSoDoDichVu(dsLoc);
        }

        private void cboSanDangDa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanDangDa.SelectedValue is int maSan)
            {
                TaiChiTietPhieu(maSan);
            }
        }

        // ================== THANH TOÁN & IN ==================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cboSanDangDa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sân cần thanh toán!");
                return;
            }

            int maSan = (int)cboSanDangDa.SelectedValue;
            string tenSan = cboSanDangDa.Text;

            if (MessageBox.Show($"Xác nhận thanh toán cho sân [{tenSan}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bus.ThanhToan(maSan, out decimal tongTien, out string loi))
                {
                    MessageBox.Show($"Thanh toán thành công cho [{tenSan}]!\nTổng tiền: {tongTien:N0} đ");
                    TaiDuLieu();
                    dgvPhieu.DataSource = null;
                    btnThanhToan.Text = "Thanh Toán";
                }
                else
                {
                    MessageBox.Show("Lỗi: " + loi);
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu hiện tại chưa có dịch vụ nào để in!");
                return;
            }
            MessageBox.Show($"Đang gửi lệnh in hóa đơn cho [{cboSanDangDa.Text}]...");
        }
    }
}