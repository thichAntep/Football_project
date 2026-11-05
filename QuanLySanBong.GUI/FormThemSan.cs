//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace QuanLySanBong.GUI
//{
//    public partial class FormThemSan : Form
//    {
//        public FormThemSan()
//        {
//            InitializeComponent();
//        }

//        private void label2_Click(object sender, EventArgs e)
//        {

//        }

//        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
//        {

//        }

//        private void btnXoaSan_Click(object sender, EventArgs e)
//        {

//        }

//        private void lblGiaTien_Click(object sender, EventArgs e)
//        {

//        }

//        private void lblLoaiSanXoa_Click(object sender, EventArgs e)
//        {

//        }

//        private void btnHuy_Click(object sender, EventArgs e)
//        {

//        }

//        private void cboXoaSan_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void cboXoaKhungGio_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void lblThongTinLoai_Click(object sender, EventArgs e)
//        {

//        }

//        private void btnXacNhanXoar_Click(object sender, EventArgs e)
//        {

//        }

//        private void lblTenSan_Click(object sender, EventArgs e)
//        {

//        }

//        private void txtTenSan_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void clbKhungGio_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLySanBong.DAL;

namespace QuanLySanBong.GUI
{
    public partial class FormThemSan : Form
    {
        private bool dangTaiDuLieu = false;

        public FormThemSan()
        {
            InitializeComponent();

            // Gắn sự kiện
            btnThemSan.Click += btnThemSan_Click;
            btnXoaSan.Click += btnXoaSan_Click;

            btnLuuThem.Click += btnLuuThem_Click;
            btnHuy.Click += btnHuy_Click;

            btnXacNhanXoar.Click += btnXacNhanXoar_Click;
            btnHuyXoa.Click += btnHuyXoa_Click;

            cboLoaiSan.SelectedIndexChanged += cboLoaiSan_SelectedIndexChanged;
            cboXoaSan.SelectedIndexChanged += cboXoaSan_SelectedIndexChanged;
            cboXoaKhungGio.SelectedIndexChanged += cboXoaKhungGio_SelectedIndexChanged;

            // Ẩn vùng nhập liệu lúc đầu
            grpThemSan.Visible = false;
            grpXoaSan.Visible = false;

            LoadData();
        }

        // ==========================================
        // 1. TẢI DỮ LIỆU
        // ==========================================

        private void LoadData()
        {
            try
            {
                dangTaiDuLieu = true;

                LoadDanhSachSan();
                LoadLoaiSan();
                LoadKhungGio();

                dangTaiDuLieu = false;
            }
            catch (Exception ex)
            {
                dangTaiDuLieu = false;
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachSan()
        {
            DataTable data = SanBongDAL.Instance.GetAllWithKhungGio();

            dgvDanhSachSan.DataSource = data;
            dgvDanhSachXoa.DataSource = data.Copy();

            CauHinhDataGridView(dgvDanhSachSan);
            CauHinhDataGridView(dgvDanhSachXoa);
        }

        private void CauHinhDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;

            if (dgv.Columns.Contains("MaSan"))
                dgv.Columns["MaSan"].Visible = false;

            if (dgv.Columns.Contains("MaLoai"))
                dgv.Columns["MaLoai"].Visible = false;

            if (dgv.Columns.Contains("MaKhungGio"))
                dgv.Columns["MaKhungGio"].Visible = false;
        }

        private void LoadLoaiSan()
        {
            string query = @"
                SELECT MaLoai, TenLoai
                FROM LoaiSan
                ORDER BY MaLoai";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cboLoaiSan.DataSource = data;
            cboLoaiSan.DisplayMember = "TenLoai";
            cboLoaiSan.ValueMember = "MaLoai";
            cboLoaiSan.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadKhungGio()
        {
            DataTable data = LichSanDAL.Instance.GetAllKhungGio();

            clbKhungGio.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                int maKhungGio = Convert.ToInt32(row["MaKhungGio"]);

                TimeSpan batDau = (TimeSpan)row["GioBatDau"];
                TimeSpan ketThuc = (TimeSpan)row["GioKetThuc"];

                string tenKhungGio = batDau.ToString(@"hh\:mm") + " - " + ketThuc.ToString(@"hh\:mm");

                clbKhungGio.Items.Add(
                    new KhungGioItem(maKhungGio, tenKhungGio));
            }
        }

        // ==========================================
        // 2. MỞ VÙNG THÊM SÂN
        // ==========================================

        private void btnThemSan_Click(object sender, EventArgs e)
        {
            grpThemSan.Visible = true;
            grpXoaSan.Visible = false;

            txtTenSan.Clear();

            for (int i = 0; i < clbKhungGio.Items.Count; i++)
                clbKhungGio.SetItemChecked(i, false);

            if (cboLoaiSan.Items.Count > 0)
                cboLoaiSan.SelectedIndex = 0;

            txtTenSan.Focus();
        }

        // ==========================================
        // 3. CHỌN LOẠI SÂN -> TỰ ĐỘNG LẤY GIÁ
        // ==========================================

        private void cboLoaiSan_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (dangTaiDuLieu || cboLoaiSan.SelectedValue == null)
                return;

            try
            {
                int maLoai = Convert.ToInt32(cboLoaiSan.SelectedValue);

                decimal gia = SanBongDAL.Instance.GetDefaultPrice(maLoai);

                nudGiaTien.Value = Math.Min(
                    nudGiaTien.Maximum,
                    Math.Max(nudGiaTien.Minimum, gia));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được giá sân: " + ex.Message);
            }
        }

        // ==========================================
        // 4. LƯU SÂN MỚI
        // ==========================================

        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSan = txtTenSan.Text.Trim();

                if (tenSan == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên sân.");
                    txtTenSan.Focus();
                    return;
                }

                if (cboLoaiSan.SelectedValue == null)
                {
                    MessageBox.Show("Bạn chưa chọn loại sân.");
                    return;
                }

                List<int> danhSachKhungGio = new List<int>();

                foreach (object item in clbKhungGio.CheckedItems)
                {
                    KhungGioItem khung = item as KhungGioItem;

                    if (khung != null)
                        danhSachKhungGio.Add(khung.MaKhungGio);
                }

                if (danhSachKhungGio.Count == 0)
                {
                    MessageBox.Show("Bạn phải chọn ít nhất một khung giờ.");
                    return;
                }

                if (SanBongDAL.Instance.ExistsName(tenSan))
                {
                    MessageBox.Show("Tên sân này đã tồn tại.");
                    return;
                }

                int maLoai = Convert.ToInt32(cboLoaiSan.SelectedValue);
                decimal giaTien = nudGiaTien.Value;

                DialogResult xacNhan = MessageBox.Show(
                    "Bạn có chắc chắn muốn thêm sân " + tenSan + "?",
                    "Xác nhận thêm sân",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes)
                    return;

                // Thêm sân trước
                int maSan = SanBongDAL.Instance.Insert(
                    tenSan,
                    maLoai,
                    "Trống");

                try
                {
                    // Thêm các khung giờ cho sân
                    int soLuong = LichSanDAL.Instance.InsertMany(
                        maSan,
                        danhSachKhungGio,
                        giaTien);

                    MessageBox.Show(
                        "Thêm sân thành công!\n" +
                        "Mã sân: " + maSan +
                        "\nSố khung giờ mới: " + soLuong,
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch
                {
                    // Nếu thêm khung giờ thất bại,
                    // xóa sân vừa tạo để tránh sân rỗng.
                    SanBongDAL.Instance.DeleteIfNoKhungGio(maSan);
                    throw;
                }

                LoadDanhSachSan();

                grpThemSan.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm sân: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 5. HỦY THÊM SÂN
        // ==========================================

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grpThemSan.Visible = false;
        }

        // ==========================================
        // 6. MỞ VÙNG XÓA SÂN
        // ==========================================

        private void btnXoaSan_Click(object sender, EventArgs e)
        {
            grpXoaSan.Visible = true;
            grpThemSan.Visible = false;

            LoadComboXoaSan();

            lblLoaiSanXoa.Text = "Chưa chọn";
            lblGiaTienXoa.Text = "Chưa chọn";
        }

        private void LoadComboXoaSan()
        {
            DataTable data = SanBongDAL.Instance.GetAll();

            cboXoaSan.DataSource = data;
            cboXoaSan.DisplayMember = "TenSan";
            cboXoaSan.ValueMember = "MaSan";
            cboXoaSan.DropDownStyle = ComboBoxStyle.DropDownList;

            cboXoaKhungGio.DataSource = null;
        }

        // ==========================================
        // 7. CHỌN SÂN -> TẢI KHUNG GIỜ
        // ==========================================

        private void cboXoaSan_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (dangTaiDuLieu || cboXoaSan.SelectedValue == null)
                return;

            try
            {
                int maSan;

                if (!int.TryParse(
                    cboXoaSan.SelectedValue.ToString(), out maSan))
                    return;

                DataTable data = LichSanDAL.Instance.GetByMaSan(maSan);

                data.Columns.Add("TenKhungGio", typeof(string));

                foreach (DataRow row in data.Rows)
                {
                    string batDau = Convert.ToDateTime(
                        row["GioBatDau"]).ToString("HH:mm");

                    string ketThuc = Convert.ToDateTime(
                        row["GioKetThuc"]).ToString("HH:mm");

                    row["TenKhungGio"] = batDau + " - " + ketThuc;
                }

                cboXoaKhungGio.DataSource = data;
                cboXoaKhungGio.DisplayMember = "TenKhungGio";
                cboXoaKhungGio.ValueMember = "MaID";

                lblLoaiSanXoa.Text = "Chưa chọn";
                lblGiaTienXoa.Text = "Chưa chọn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khung giờ: " + ex.Message);
            }
        }

        // ==========================================
        // 8. CHỌN KHUNG GIỜ -> HIỂN THỊ THÔNG TIN
        // ==========================================

        private void cboXoaKhungGio_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cboXoaKhungGio.SelectedItem == null)
                return;

            DataRowView row = cboXoaKhungGio.SelectedItem as DataRowView;

            if (row == null)
                return;

            lblLoaiSanXoa.Text = row["TenLoai"].ToString();

            decimal gia = Convert.ToDecimal(row["GiaTien"]);

            lblGiaTienXoa.Text = gia.ToString("N0") + " VNĐ";
        }

        // ==========================================
        // 9. XÁC NHẬN XÓA KHUNG GIỜ
        // ==========================================

        private void btnXacNhanXoar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboXoaKhungGio.SelectedValue == null)
                {
                    MessageBox.Show("Bạn chưa chọn khung giờ cần xóa.");
                    return;
                }

                int maID = Convert.ToInt32(
                    cboXoaKhungGio.SelectedValue);

                string tenSan = cboXoaSan.Text;
                string khungGio = cboXoaKhungGio.Text;

                DialogResult xacNhan = MessageBox.Show(
                    "Bạn muốn xóa khung giờ " + khungGio +
                    " của " + tenSan + "?\n\n" +
                    "Nếu đây là khung giờ cuối cùng, sân sẽ bị xóa.",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (xacNhan != DialogResult.Yes)
                    return;

                DataTable result =
                    LichSanDAL.Instance.DeleteAndCheckSan(maID);

                if (result.Rows.Count > 0)
                {
                    bool daXoaSan = Convert.ToBoolean(
                        result.Rows[0]["DaXoaSan"]);

                    if (daXoaSan)
                    {
                        MessageBox.Show(
                            "Đã xóa khung giờ cuối cùng và xóa luôn sân " +
                            tenSan + ".");
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa khung giờ thành công.");
                    }
                }

                LoadDanhSachSan();
                LoadComboXoaSan();

                lblLoaiSanXoa.Text = "Chưa chọn";
                lblGiaTienXoa.Text = "Chưa chọn";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa: " + ex.Message +
                    "\nCó thể sân đang được sử dụng hoặc có dữ liệu liên quan.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 10. HỦY XÓA
        // ==========================================

        private void btnHuyXoa_Click(object sender, EventArgs e)
        {
            grpXoaSan.Visible = false;
        }

        // ==========================================
        // 11. CLASS HIỂN THỊ KHUNG GIỜ
        // ==========================================

        private class KhungGioItem
        {
            public int MaKhungGio { get; set; }

            public string TenKhungGio { get; set; }

            public KhungGioItem(int ma, string ten)
            {
                MaKhungGio = ma;
                TenKhungGio = ten;
            }

            public override string ToString()
            {
                return TenKhungGio;
            }
        }
    }
}
