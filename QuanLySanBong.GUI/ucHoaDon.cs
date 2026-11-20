using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QuanLySanBong.BUS;
using QuanLySanBong.DTO;

namespace QuanLySanBong.GUI
{
    public partial class ucHoaDon : UserControl
    {
        private readonly HoaDonBUS bus = new HoaDonBUS();
        private readonly CultureInfo vi = new CultureInfo("vi-VN");
        private int maHDDangChon = -1;

        public ucHoaDon()
        {
            InitializeComponent();
            Load += ucHoaDon_Load;
            btnTim.Click += (s, e) => LoadHoaDon();
            btnLamMoi.Click += (s, e) => LoadHoaDon();
            btnThanhToan.Click += btnThanhToan_Click;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            txtTim.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadHoaDon(); };
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            cboTrangThai.Items.AddRange(new object[]
                { "Tất cả", HoaDonBUS.CHUA_THANH_TOAN, HoaDonBUS.DA_THANH_TOAN });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.SelectedIndex = 0;

            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            try
            {
                string tt = cboTrangThai.SelectedIndex <= 0 ? "" : cboTrangThai.Text;
                DataTable dt = bus.TimHoaDon(dtpTuNgay.Value, dtpDenNgay.Value, tt, txtTim.Text.Trim());
                dgvHoaDon.DataSource = dt;

                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns["TenSan"].HeaderText = "Sân";
                dgvHoaDon.Columns["TenKH"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["GioVao"].HeaderText = "Giờ vào";
                dgvHoaDon.Columns["GioRa"].HeaderText = "Giờ ra";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvHoaDon.Columns["GioVao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHoaDon.Columns["GioRa"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";

                if (dt.Rows.Count == 0) XoaChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null) return;
            maHDDangChon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHD"].Value);
            HienChiTiet(maHDDangChon);
        }

        private void HienChiTiet(int maHD)
        {
            HoaDonDTO hd = bus.GetById(maHD);
            if (hd == null) { XoaChiTiet(); return; }

            DataGridViewRow row = dgvHoaDon.CurrentRow;
            lblMaHD.Text = "Hóa đơn #" + hd.MaHD;
            lblSan.Text = "Sân: " + row.Cells["TenSan"].Value;
            lblKhach.Text = "Khách: " + row.Cells["TenKH"].Value;
            lblGioVao.Text = "Giờ vào: " + hd.GioVao.ToString("dd/MM/yyyy HH:mm");
            lblGioRa.Text = "Giờ ra: " + (hd.GioRa.HasValue ? hd.GioRa.Value.ToString("dd/MM/yyyy HH:mm") : "--");

            lblTienSan.Text = "Tiền sân: " + hd.TienSan.ToString("N0", vi) + " đ";
            lblTienDV.Text = "Tiền dịch vụ: " + hd.TienDichVu.ToString("N0", vi) + " đ";
            lblTongTien.Text = "TỔNG: " + hd.TongTien.ToString("N0", vi) + " đ";

            dgvChiTiet.DataSource = bus.GetChiTietDichVu(maHD);
            dgvChiTiet.Columns["TenDV"].HeaderText = "Dịch vụ";
            dgvChiTiet.Columns["DVT"].HeaderText = "ĐVT";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            btnThanhToan.Enabled = hd.TrangThai != HoaDonBUS.DA_THANH_TOAN;
        }

        private void XoaChiTiet()
        {
            maHDDangChon = -1;
            lblMaHD.Text = "Chưa chọn hóa đơn";
            lblSan.Text = lblKhach.Text = lblGioVao.Text = lblGioRa.Text = "";
            lblTienSan.Text = lblTienDV.Text = lblTongTien.Text = "";
            dgvChiTiet.DataSource = null;
            btnThanhToan.Enabled = false;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maHDDangChon < 0) return;

            if (MessageBox.Show("Xác nhận thanh toán hóa đơn #" + maHDDangChon + "?",
                "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bus.ThanhToan(maHDDangChon);
                MessageBox.Show("Thanh toán thành công!");
                int giu = maHDDangChon;
                LoadHoaDon();
                // chọn lại dòng vừa thanh toán
                foreach (DataGridViewRow r in dgvHoaDon.Rows)
                    if (Convert.ToInt32(r.Cells["MaHD"].Value) == giu) { r.Selected = true; dgvHoaDon.CurrentCell = r.Cells[0]; break; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}