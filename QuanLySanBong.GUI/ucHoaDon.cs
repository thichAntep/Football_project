using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using QuanLySanBong.BUS;
using QuanLySanBong.DTO;

namespace QuanLySanBong.GUI
{
    public partial class ucHoaDon : UserControl
    {
        private readonly HoaDonBUS bus = new HoaDonBUS();

        private List<HoaDonDTO> dsHoaDon = new List<HoaDonDTO>();
        private HoaDonDTO hoaDonHienTai;

        private decimal tienSanTamTinh = 0;
        private decimal tienDVTamTinh = 0;
        private decimal tongTienTamTinh = 0;
        private DateTime gioRaHienTai;

        public ucHoaDon()
        {
            InitializeComponent();

            Load += ucHoaDon_Load;
            cboSanHoaDon.SelectedIndexChanged += cboSanHoaDon_SelectedIndexChanged;
            btnThanhToan.Click += btnThanhToan_Click;
            btnInHoaDon.Click += btnInHoaDon_Click;
            btnLamMoi.Click += (s, e) => TaiDanhSachHoaDon();
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ChinhGiaoDien();
            TaiDanhSachHoaDon();
        }

        private void ChinhGiaoDien()
        {
            // Thiết lập vị trí hiển thị các nhãn trong panel thông tin
            int top = 20;
            int gap = 38;

            KhoiTaoLabel(lblMaHD, "Mã Hóa Đơn:", ref top, gap, false);
            KhoiTaoLabel(lblTenSan, "Sân Bóng:", ref top, gap, false);
            KhoiTaoLabel(lblKhachHang, "Khách Hàng:", ref top, gap, false);
            KhoiTaoLabel(lblGioVao, "Giờ Vào:", ref top, gap, false);
            KhoiTaoLabel(lblGioRa, "Giờ Ra (Dự kiến):", ref top, gap, false);
            KhoiTaoLabel(lblThoiGianDa, "Thời Gian Đá:", ref top, gap, false);
            top += 10;
            KhoiTaoLabel(lblTienSan, "Tiền Sân:", ref top, gap, true);
            KhoiTaoLabel(lblTienDichVu, "Tiền Dịch Vụ:", ref top, gap, true);
            top += 5;
            KhoiTaoLabel(lblTongTien, "TỔNG THANH TOÁN:", ref top, gap, true, Color.Crimson, 13F);

            // Cấu hình bảng hiển thị chi tiết dịch vụ
            dgvDichVu.AutoGenerateColumns = false;
            dgvDichVu.AllowUserToAddRows = false;
            dgvDichVu.RowHeadersVisible = false;
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDichVu.Columns.Clear();
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Dịch Vụ", DataPropertyName = "TenDV", FillWeight = 45 });
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL", DataPropertyName = "SoLuong", FillWeight = 15, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn Giá", DataPropertyName = "DonGia", FillWeight = 20, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành Tiền", DataPropertyName = "ThanhTien", FillWeight = 25, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });
        }

        private void KhoiTaoLabel(Label lbl, string tieuDe, ref int top, int gap, bool inDam, Color? mau = null, float size = 10.5F)
        {
            lbl.Text = tieuDe;
            lbl.Location = new Point(25, top);
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", size, inDam ? FontStyle.Bold : FontStyle.Regular);
            lbl.ForeColor = mau ?? Color.Black;
            top += gap;
        }

        private void TaiDanhSachHoaDon()
        {
            dsHoaDon = bus.LayDanhSachHoaDonChuaThanhToan();

            cboSanHoaDon.DataSource = null;
            cboSanHoaDon.DisplayMember = "TenSan";
            cboSanHoaDon.ValueMember = "MaHD";
            cboSanHoaDon.DataSource = dsHoaDon;

            if (dsHoaDon.Count == 0)
            {
                XoaTrangGiaoDien();
                MessageBox.Show("Hiện không có sân nào có hóa đơn chưa thanh toán.");
            }
        }

        private void cboSanHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanHoaDon.SelectedItem is HoaDonDTO hd)
            {
                hoaDonHienTai = hd;
                HienThiThongTinHoaDon(hd);
            }
        }

        private void HienThiThongTinHoaDon(HoaDonDTO hd)
        {
            gioRaHienTai = DateTime.Now;

            // 1. Tải chi tiết dịch vụ
            hd.DanhSachDichVu = bus.LayChiTietDichVu(hd.MaHD);
            dgvDichVu.DataSource = hd.DanhSachDichVu;

            // 2. Tính tiền sân dựa trên GiaTheoGio và tiền dịch vụ
            tienSanTamTinh = bus.TinhTienSan(hd.GioVao, gioRaHienTai, hd.DonGiaGio);
            tienDVTamTinh = hd.DanhSachDichVu.Sum(x => x.ThanhTien);
            tongTienTamTinh = tienSanTamTinh + tienDVTamTinh;

            // 3. Hiển thị lên các Label
            double tongPhut = Math.Round((gioRaHienTai - hd.GioVao).TotalMinutes);
            int gio = (int)tongPhut / 60;
            int phut = (int)tongPhut % 60;

            lblMaHD.Text = $"Mã Hóa Đơn: HD{hd.MaHD:D4}";
            lblTenSan.Text = $"Sân Bóng: {hd.TenSan}";
            lblKhachHang.Text = $"Khách Hàng: {hd.TenKH} " + (string.IsNullOrEmpty(hd.SoDienThoai) ? "" : $"({hd.SoDienThoai})");
            lblGioVao.Text = $"Giờ Vào: {hd.GioVao:dd/MM/yyyy HH:mm}";
            lblGioRa.Text = $"Giờ Ra: {gioRaHienTai:dd/MM/yyyy HH:mm}";
            lblThoiGianDa.Text = $"Thời Gian Đá: {gio} giờ {phut} phút (Giá: {hd.DonGiaGio:N0} đ/h)";

            lblTienSan.Text = $"Tiền Sân: {tienSanTamTinh:N0} VNĐ";
            lblTienDichVu.Text = $"Tiền Dịch Vụ: {tienDVTamTinh:N0} VNĐ";
            lblTongTien.Text = $"TỔNG THANH TOÁN: {tongTienTamTinh:N0} VNĐ";
        }

        private void XoaTrangGiaoDien()
        {
            hoaDonHienTai = null;
            dgvDichVu.DataSource = null;
            lblMaHD.Text = "Mã Hóa Đơn: ---";
            lblTenSan.Text = "Sân Bóng: ---";
            lblKhachHang.Text = "Khách Hàng: ---";
            lblGioVao.Text = "Giờ Vào: ---";
            lblGioRa.Text = "Giờ Ra: ---";
            lblThoiGianDa.Text = "Thời Gian Đá: ---";
            lblTienSan.Text = "Tiền Sân: 0 VNĐ";
            lblTienDichVu.Text = "Tiền Dịch Vụ: 0 VNĐ";
            lblTongTien.Text = "TỔNG THANH TOÁN: 0 VNĐ";
        }

        // ================== THANH TOÁN ==================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán!");
                return;
            }

            var dialog = MessageBox.Show(
                $"XÁC NHẬN THANH TOÁN: [{hoaDonHienTai.TenSan}]\n" +
                $"-----------------------------------------\n" +
                $"- Tiền sân: {tienSanTamTinh:N0} VNĐ\n" +
                $"- Tiền dịch vụ: {tienDVTamTinh:N0} VNĐ\n" +
                $"- TỔNG TIỀN: {tongTienTamTinh:N0} VNĐ\n\n" +
                $"Hoàn tất thanh toán hóa đơn này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                if (bus.ThanhToan(hoaDonHienTai, gioRaHienTai, out string loi))
                {
                    MessageBox.Show("Thanh toán thành công!");

                    if (MessageBox.Show("Bạn có muốn in hóa đơn ngay bây giờ không?", "In hóa đơn",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        InHoaDon();
                    }

                    TaiDanhSachHoaDon();
                }
                else
                {
                    MessageBox.Show("Lỗi thanh toán: " + loi);
                }
            }
        }

        // ================== IN HÓA ĐƠN ==================
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!");
                return;
            }
            InHoaDon();
        }

        private void InHoaDon()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = pd,
                Width = 700,
                Height = 850
            };
            preview.ShowDialog();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTieuDe = new Font("Courier New", 16, FontStyle.Bold);
            Font fontDam = new Font("Courier New", 10, FontStyle.Bold);
            Font fontThuong = new Font("Courier New", 10, FontStyle.Regular);
            Font fontNho = new Font("Courier New", 9, FontStyle.Italic);

            int y = 40;
            int x = 50;
            int width = 700;

            // Header
            g.DrawString("HỆ THỐNG QUẢN LÝ SÂN BÓNG ĐÁ", fontTieuDe, Brushes.Black, new RectangleF(x, y, width, 30), new StringFormat { Alignment = StringAlignment.Center });
            y += 30;
            g.DrawString("HÓA ĐƠN THANH TOÁN", fontDam, Brushes.Black, new RectangleF(x, y, width, 25), new StringFormat { Alignment = StringAlignment.Center });
            y += 30;
            g.DrawString(new string('-', 75), fontThuong, Brushes.Black, x, y);
            y += 20;

            // Thông tin chung
            g.DrawString($"Mã Hóa Đơn : HD{hoaDonHienTai.MaHD:D4}", fontThuong, Brushes.Black, x, y);
            g.DrawString($"Ngày In: {DateTime.Now:dd/MM/yyyy HH:mm}", fontThuong, Brushes.Black, x + 350, y);
            y += 22;
            g.DrawString($"Sân Bóng   : {hoaDonHienTai.TenSan}", fontDam, Brushes.Black, x, y);
            g.DrawString($"Khách Hàng: {hoaDonHienTai.TenKH}", fontThuong, Brushes.Black, x + 350, y);
            y += 22;
            g.DrawString($"Giờ Vào    : {hoaDonHienTai.GioVao:dd/MM/yyyy HH:mm}", fontThuong, Brushes.Black, x, y);
            g.DrawString($"Giờ Ra: {gioRaHienTai:dd/MM/yyyy HH:mm}", fontThuong, Brushes.Black, x + 350, y);
            y += 25;
            g.DrawString(new string('-', 75), fontThuong, Brushes.Black, x, y);
            y += 20;

            // 1. Tiền sân
            g.DrawString($"1. TIỀN THUÊ SÂN: {tienSanTamTinh:N0} VNĐ", fontDam, Brushes.Black, x, y);
            y += 20;
            g.DrawString($"   (Thời gian: {lblThoiGianDa.Text.Replace("Thời Gian Đá: ", "")})", fontNho, Brushes.Black, x, y);
            y += 25;

            // 2. Dịch vụ
            g.DrawString("2. DỊCH VỤ SỬ DỤNG:", fontDam, Brushes.Black, x, y);
            y += 22;
            g.DrawString("Tên Dịch Vụ                 SL      Đơn Giá         Thành Tiền", fontDam, Brushes.Black, x, y);
            y += 18;
            g.DrawString(new string('.', 75), fontThuong, Brushes.Black, x, y);
            y += 20;

            if (hoaDonHienTai.DanhSachDichVu.Count == 0)
            {
                g.DrawString("   (Không có dịch vụ nào)", fontNho, Brushes.Black, x, y);
                y += 20;
            }
            else
            {
                foreach (var dv in hoaDonHienTai.DanhSachDichVu)
                {
                    string ten = dv.TenDV.PadRight(26).Substring(0, 26);
                    string sl = dv.SoLuong.ToString().PadLeft(4);
                    string dg = $"{dv.DonGia:N0}".PadLeft(14);
                    string tt = $"{dv.ThanhTien:N0}".PadLeft(16);

                    g.DrawString($"{ten} {sl} {dg} {tt}", fontThuong, Brushes.Black, x, y);
                    y += 20;
                }
            }

            y += 10;
            g.DrawString(new string('=', 75), fontThuong, Brushes.Black, x, y);
            y += 25;

            // Tổng kết
            g.DrawString($"Tổng Tiền Sân    : {tienSanTamTinh:N0} VNĐ", fontThuong, Brushes.Black, x + 300, y);
            y += 22;
            g.DrawString($"Tổng Tiền Dịch Vụ: {tienDVTamTinh:N0} VNĐ", fontThuong, Brushes.Black, x + 300, y);
            y += 25;
            g.DrawString($"TỔNG CỘNG        : {tongTienTamTinh:N0} VNĐ", fontTieuDe, Brushes.Crimson, x + 250, y);
            y += 50;

            // Footer
            g.DrawString("Cảm ơn quý khách và hẹn gặp lại!", fontNho, Brushes.Black, new RectangleF(x, y, width, 25), new StringFormat { Alignment = StringAlignment.Center });
        }
    }
}
