using QuanLySanBong.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySanBong.GUI
{
    public partial class ucDatSan : UserControl
    {
        public ucDatSan()
        {
            InitializeComponent();
            LoadDanhSachSan(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbLoaiSan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpTimeTimKiem_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblVang_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private Panel CreateCardSan(DataRow row)
        {
            // Tạo card
            Panel card = new Panel();
            card.Width = 200;
            card.Height = 130;
            card.Margin = new Padding(10);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            // Lấy dữ liệu từ SqlServer
            string maSan = row["MaSan"].ToString();
            string tenSan = row["TenSan"].ToString();
            string tenLoai = row["TenLoai"].ToString();
            string trangthai = row["TrangThai"].ToString();
            // Label Ten San
            Label lblTenSan = new Label();
            lblTenSan.Text = tenSan;
            lblTenSan.AutoSize = false;
            lblTenSan.Font = new Font("Arial", 12, FontStyle.Bold);
            //Label LoaiSan
            Label lblLoaiSan = new Label();
            lblLoaiSan.Text = tenLoai;
            lblLoaiSan.Location = new Point(10, 40);
            lblLoaiSan.AutoSize = true;
            // Label trạng thái
            Label lblTrangThai = new Label();
            lblTrangThai.Text = trangthai;
            lblTrangThai.Location = new Point(10, 70);
            lblTrangThai.AutoSize = true;
            // Thêm các Label vào Card
            card.Controls.Add(lblTenSan);
            card.Controls.Add(lblLoaiSan);
            card.Controls.Add(lblTrangThai);


            return card;
        }
        private SanBongDAL sanBongDAL = new SanBongDAL();
        private void LoadDanhSachSan(int maLoai)
        {
            // 1. Xóa Card cũ
            flpDanhSachSan.Controls.Clear();

            // 2. Lấy dữ liệu từ SQL theo MaLoai
            DataTable data = sanBongDAL.GetDanhSachSan(maLoai);

            // 3. Duyệt từng dòng dữ liệu
            foreach (DataRow row in data.Rows)
            {
                // 4. Tạo một Card tương ứng với một sân
                Panel card = CreateCardSan(row);

                // 5. Thêm Card vào FlowLayoutPanel
                flpDanhSachSan.Controls.Add(card);
            }
        }
    }
}
