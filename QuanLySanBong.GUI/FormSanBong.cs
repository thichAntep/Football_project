using QuanLySanBong.BUS;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLySanBong.GUI
{
    public partial class FormSanBong : Form
    {
        public FormSanBong()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormSanBong_Load;
            dgvSanBong.CellClick += dgvSanBong_CellClick;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        // Khi Form được mở
        private void FormSanBong_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadLoaiSan();
                LoadTrangThai();
                LoadDanhSachSanBong();

                txtMaSan.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi khi tải dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tải danh sách sân bóng lên DataGridView
        private void LoadDanhSachSanBong()
        {
            try
            {
                dgvSanBong.DataSource =
                    SanBongBUS.Instance.GetAll();

                if (dgvSanBong.Columns["ID"] != null)
                {
                    dgvSanBong.Columns["ID"].HeaderText =
                        "Mã sân";
                }

                if (dgvSanBong.Columns["TenSan"] != null)
                {
                    dgvSanBong.Columns["TenSan"].HeaderText =
                        "Tên sân";
                }

                if (dgvSanBong.Columns["TenLoaiSan"] != null)
                {
                    dgvSanBong.Columns["TenLoaiSan"].HeaderText =
                        "Loại sân";
                }

                if (dgvSanBong.Columns["GiaThue"] != null)
                {
                    dgvSanBong.Columns["GiaThue"].HeaderText =
                        "Giá thuê";
                }

                if (dgvSanBong.Columns["TrangThai"] != null)
                {
                    dgvSanBong.Columns["TrangThai"].HeaderText =
                        "Trạng thái";
                }

                if (dgvSanBong.Columns["LoaiSanID"] != null)
                {
                    dgvSanBong.Columns["LoaiSanID"]
                        .Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi tải danh sách sân",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tải loại sân vào ComboBox
        private void LoadLoaiSan()
        {
            string query = @"
                SELECT ID, TenLoaiSan
                FROM LoaiSan
                ORDER BY TenLoaiSan";

            DataTable data =
                DataProvider.Instance.ExecuteQuery(query);

            cboLoaiSan.DataSource = data;
            cboLoaiSan.DisplayMember = "TenLoaiSan";
            cboLoaiSan.ValueMember = "ID";
            cboLoaiSan.SelectedIndex = -1;
        }

        // Tải trạng thái vào ComboBox
        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();

            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đang sử dụng");
            cboTrangThai.Items.Add("Đang bảo trì");

            cboTrangThai.SelectedIndex = 0;
        }

        // Nút Thêm
        private void btnThem_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                        txtTenSan.Text))
                {
                    MessageBox.Show(
                        "Vui lòng nhập tên sân.");
                    txtTenSan.Focus();
                    return;
                }

                if (cboLoaiSan.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Vui lòng chọn loại sân.");
                    cboLoaiSan.Focus();
                    return;
                }

                if (!decimal.TryParse(
                        txtGiaThue.Text.Trim(),
                        out decimal giaThue))
                {
                    MessageBox.Show(
                        "Giá thuê phải là số.");
                    txtGiaThue.Focus();
                    return;
                }

                if (giaThue <= 0)
                {
                    MessageBox.Show(
                        "Giá thuê phải lớn hơn 0.");
                    txtGiaThue.Focus();
                    return;
                }

                SanBongDTO sanBong = new SanBongDTO
                {
                    TenSan = txtTenSan.Text.Trim(),

                    LoaiSanID = Convert.ToInt32(
                        cboLoaiSan.SelectedValue),

                    GiaThue = giaThue,

                    TrangThai = cboTrangThai.Text
                };

                bool result =
                    SanBongBUS.Instance.Insert(sanBong);

                if (result)
                {
                    MessageBox.Show(
                        "Thêm sân bóng thành công.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadDanhSachSanBong();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show(
                        "Thêm sân bóng thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi thêm sân",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (!int.TryParse(
                        txtMaSan.Text,
                        out int id))
                {
                    MessageBox.Show(
                        "Vui lòng chọn sân cần xóa.");
                    return;
                }

                DialogResult result =
                    MessageBox.Show(
                        "Bạn có chắc muốn xóa sân này không?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                bool deleted =
                    SanBongBUS.Instance.Delete(id);

                if (deleted)
                {
                    MessageBox.Show(
                        "Xóa sân bóng thành công.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadDanhSachSanBong();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy sân cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi xóa sân",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Khi chọn một dòng trong DataGridView
        private void dgvSanBong_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvSanBong.Rows[e.RowIndex];

            txtMaSan.Text =
                row.Cells["ID"].Value?.ToString();

            txtTenSan.Text =
                row.Cells["TenSan"].Value?.ToString();

            txtGiaThue.Text =
                row.Cells["GiaThue"].Value?.ToString();

            cboTrangThai.Text =
                row.Cells["TrangThai"].Value?.ToString();

            if (row.Cells["LoaiSanID"].Value != null)
            {
                cboLoaiSan.SelectedValue =
                    row.Cells["LoaiSanID"].Value;
            }
        }

        // Nút Làm mới
        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            ClearInput();
            LoadDanhSachSanBong();
        }

        // Xóa dữ liệu trên các ô nhập
        private void ClearInput()
        {
            txtMaSan.Clear();
            txtTenSan.Clear();
            txtGiaThue.Clear();

            if (cboLoaiSan.Items.Count > 0)
            {
                cboLoaiSan.SelectedIndex = -1;
            }

            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }

            txtTenSan.Focus();
        }
    }
}