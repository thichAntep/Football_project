using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySanBong.GUI
{
    public partial class Form_Main : Form
    {
        ucTrangChu TrangChu = new ucTrangChu();
        public Form_Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tlnMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTRangChu_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSanTrong_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void lblKhachMoitxt_Click(object sender, EventArgs e)
        {

        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void dgvLichSan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }
        private void btnThemSan_Click(object sender, EventArgs e)
        {
            using (FormThemSan f = new FormThemSan())
            {
                f.ShowDialog();
            }

            // code chạy sau khi FormB đóng (ví dụ load lại dữ liệu)
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            TrangChu.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(TrangChu);

        }
    }
}
