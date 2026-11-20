using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLySanBong.BUS;
using QuanLySanBong.DTO;

namespace QuanLySanBong.GUI
{
    public partial class ucBaoCao : UserControl
    {
        public ucBaoCao()
        {
            InitializeComponent();
        }

        private void ucBaoCao_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanBong();
            SetMacDinhNgayThang();
            LoadBaoCao();
        }

        // Đổ danh sách sân vào ComboBox
        private void LoadDanhSachSanBong()
        {
            try
            {
                DataTable dt = BaoCaoBUS.Instance.GetDanhSachSanBong();

                // Tạo dòng "Tất cả các sân" ở đầu
                DataRow topRow = dt.NewRow();
                topRow["MaSan"] = 0;
                topRow["TenSan"] = "-- Tất cả các sân --";
                dt.Rows.InsertAt(topRow, 0);

                cboSanBong.DataSource = dt;
                cboSanBong.DisplayMember = "TenSan";
                cboSanBong.ValueMember = "MaSan";
                cboSanBong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đặt khoảng ngày mặc định (đầu tháng đến cuối ngày hôm nay)
        private void SetMacDinhNgayThang()
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            dtpDenNgay.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
        }

        // Lấy dữ liệu và hiển thị lên Grid + Thẻ tổng kết
        private void LoadBaoCao()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                int maSan = 0;

                if (cboSanBong.SelectedValue != null && int.TryParse(cboSanBong.SelectedValue.ToString(), out int val))
                {
                    maSan = val;
                }

                List<BaoCaoHoaDonDTO> list = BaoCaoBUS.Instance.GetDanhSachHoaDon(tuNgay, denNgay, maSan);

                // Gán nguồn dữ liệu cho DataGridView
                dgvBaoCao.DataSource = null;
                dgvBaoCao.DataSource = list;

                // Định dạng tiêu đề và tiền tệ
                FormatDataGridView();

                // Tính toán các thẻ tổng kết
                decimal tongTienSan = list.Sum(x => x.TienSan);
                decimal tongTienDV = list.Sum(x => x.TienDichVu);
                decimal tongDoanhThu = list.Sum(x => x.TongTien);
                int tongSoHoaDon = list.Count;

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                lblTienSan.Text = tongTienSan.ToString("#,##0", cul) + " đ";
                lblTienDichVu.Text = tongTienDV.ToString("#,##0", cul) + " đ";
                lblTongDoanhThu.Text = tongDoanhThu.ToString("#,##0", cul) + " đ";
                lblTongHoaDon.Text = tongSoHoaDon.ToString() + " hóa đơn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvBaoCao.Columns["MaHD"] != null) dgvBaoCao.Columns["MaHD"].HeaderText = "Mã HĐ";
            if (dgvBaoCao.Columns["TenSan"] != null) dgvBaoCao.Columns["TenSan"].HeaderText = "Tên Sân";
            if (dgvBaoCao.Columns["TenKH"] != null) dgvBaoCao.Columns["TenKH"].HeaderText = "Khách Hàng";
            if (dgvBaoCao.Columns["NhanVienLap"] != null) dgvBaoCao.Columns["NhanVienLap"].HeaderText = "NV Lập";
            if (dgvBaoCao.Columns["GioDen"] != null)
            {
                dgvBaoCao.Columns["GioDen"].HeaderText = "Giờ Đến";
                dgvBaoCao.Columns["GioDen"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvBaoCao.Columns["GioDi"] != null)
            {
                dgvBaoCao.Columns["GioDi"].HeaderText = "Giờ Đi";
                dgvBaoCao.Columns["GioDi"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvBaoCao.Columns["TienSan"] != null)
            {
                dgvBaoCao.Columns["TienSan"].HeaderText = "Tiền Sân";
                dgvBaoCao.Columns["TienSan"].DefaultCellStyle.Format = "#,##0";
            }
            if (dgvBaoCao.Columns["TienDichVu"] != null)
            {
                dgvBaoCao.Columns["TienDichVu"].HeaderText = "Tiền Dịch Vụ";
                dgvBaoCao.Columns["TienDichVu"].DefaultCellStyle.Format = "#,##0";
            }
            if (dgvBaoCao.Columns["TongTien"] != null)
            {
                dgvBaoCao.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvBaoCao.Columns["TongTien"].DefaultCellStyle.Format = "#,##0";
            }
            if (dgvBaoCao.Columns["TrangThai"] != null) dgvBaoCao.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        // Sự kiện click nút Thống kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        // Lọc nhanh hôm nay
        private void btnHomNay_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            dtpDenNgay.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            LoadBaoCao();
        }

        // Lọc nhanh tháng này
        private void btnThangNay_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            dtpDenNgay.Value = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month), 23, 59, 59);
            LoadBaoCao();
        }

        // Xuất bảng ra file CSV / Excel nhanh chóng không cần thư viện ngoài
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv|Excel Workbook (*.xlsx)|*.xlsx";
            sfd.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd_HHmm}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Tiêu đề cột
                    string[] columnNames = dgvBaoCao.Columns.Cast<DataGridViewColumn>()
                        .Select(column => "\"" + column.HeaderText.Replace("\"", "\"\"") + "\"")
                        .ToArray();
                    sb.AppendLine(string.Join(",", columnNames));

                    // Dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgvBaoCao.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] fields = row.Cells.Cast<DataGridViewCell>()
                                .Select(cell => "\"" + (cell.Value?.ToString() ?? "").Replace("\"", "\"\"") + "\"")
                                .ToArray();
                            sb.AppendLine(string.Join(",", fields));
                        }
                    }

                    // Lưu file với chuẩn UTF8 có BOM để Excel tiếng Việt không bị lỗi font
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}