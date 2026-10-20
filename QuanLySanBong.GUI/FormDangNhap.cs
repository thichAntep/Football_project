
using System;
using System.Data;
using System.Windows.Forms;
using QuanLySanBong.BUS;

namespace QuanLySanBong.GUI
{
    public partial class FormDangNhap : Form
    {
        private TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            DataTable data = taiKhoanBUS.DangNhap(
                tenDangNhap, matKhau);

            if (data != null && data.Rows.Count > 0)
            {
                string hoTen = data.Rows[0]["HoTen"].ToString();
                string vaiTro = data.Rows[0]["VaiTro"].ToString();

                MessageBox.Show(
                    "Đăng nhập thành công. Xin chào " + hoTen,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                FormMain formMain = new FormMain(vaiTro);
                this.Hide();
                formMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(
                    "Tên đăng nhập hoặc mật khẩu không đúng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        } // Đóng btnDangNhap_Click  

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (FormDangKy form = new FormDangKy())
            {
                form.ShowDialog();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    } // Đóng class FormDangNha
} // Đóng namespace