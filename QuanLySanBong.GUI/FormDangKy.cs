using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLySanBong.BUS;
namespace QuanLySanBong.GUI
{
    public partial class FormDangKy : Form
    {
        private TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();
        public FormDangKy()
        {
            InitializeComponent();

            txtMatKhau.PasswordChar = '*';
            txtNhapLaiMatKhau.PasswordChar = '*';
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string nhapLai = txtNhapLaiMatKhau.Text;
            string hoTen = txtHoTen.Text.Trim();

            if (matKhau != nhapLai)
            {
                MessageBox.Show("Mat Khau Nhap Lai Khong Khop");
                return;
            }
            try
            {
                int result = taiKhoanBUS.DangKy(
                    tenDangNhap, matKhau, hoTen);
                if (result > 0)
                {
                    MessageBox.Show("Dang Ky Thanh Cong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dang ky khong thanh cong!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            }
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {

        }

        private void lebael1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNhapLaiMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

