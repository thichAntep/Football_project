using System;
using System.Windows.Forms;

namespace QuanLySanBong.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Đăng ký sự kiện cho các nút
            btnTrangChu.Click += btnTrangChu_Click;
            btnSanBong.Click += btnSanBong_Click;
            btnLoaiSan.Click += btnLoaiSan_Click;
            btnDatSan.Click += btnDatSan_Click;
            btnKhachHang.Click += btnKhachHang_Click;
            btnDichVu.Click += btnDichVu_Click;
            btnHoaDon.Click += btnHoaDon_Click;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            btnBaoCao.Click += btnBaoCao_Click;
            btnDangXuat.Click += btnDangXuat_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void btnTrangChu_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormTrangChu());
        }

        private void btnSanBong_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormSanBong());
        }

        private void btnLoaiSan_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormLoaiSan());
        }

        private void btnDatSan_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormDatSan());
        }

        private void btnKhachHang_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormKhachHang());
        }

        private void btnDichVu_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormDichVu());
        }

        private void btnHoaDon_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormHoaDon());
        }

        private void btnTaiKhoan_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormTaiKhoan());
        }

        private void btnBaoCao_Click(
            object sender,
            EventArgs e)
        {
            MoForm(new FormBaoCao());
        }

        private void btnDangXuat_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Bạn có muốn đăng xuất không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                using (FormDangNhap formDangNhap =
                       new FormDangNhap())
                {
                    formDangNhap.ShowDialog();
                }

                this.Close();
            }
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Bạn có muốn thoát chương trình không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            btnTrangChu = new Button();
            btnSanBong = new Button();
            btnLoaiSan = new Button();
            btnDatSan = new Button();
            btnKhachHang = new Button();
            btnDichVu = new Button();
            btnHoaDon = new Button();
            btnTaiKhoan = new Button();
            btnBaoCao = new Button();
            btnDangXuat = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(330, 34);
            label1.Name = "label1";
            label1.Size = new Size(210, 32);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Sân Bóng";
            label1.Click += label1_Click;
            // 
            // btnTrangChu
            // 
            btnTrangChu.Location = new Point(29, 71);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(150, 46);
            btnTrangChu.TabIndex = 1;
            btnTrangChu.Text = "Trang Chủ";
            btnTrangChu.UseVisualStyleBackColor = true;
            // 
            // btnSanBong
            // 
            btnSanBong.Location = new Point(29, 139);
            btnSanBong.Name = "btnSanBong";
            btnSanBong.Size = new Size(150, 46);
            btnSanBong.TabIndex = 2;
            btnSanBong.Text = "Quản Lý Sân";
            btnSanBong.UseVisualStyleBackColor = true;
            // 
            // btnLoaiSan
            // 
            btnLoaiSan.Location = new Point(29, 202);
            btnLoaiSan.Name = "btnLoaiSan";
            btnLoaiSan.Size = new Size(150, 46);
            btnLoaiSan.TabIndex = 3;
            btnLoaiSan.Text = "Loại Sân";
            btnLoaiSan.UseVisualStyleBackColor = true;
            // 
            // btnDatSan
            // 
            btnDatSan.Location = new Point(29, 274);
            btnDatSan.Name = "btnDatSan";
            btnDatSan.Size = new Size(150, 46);
            btnDatSan.TabIndex = 4;
            btnDatSan.Text = "Đặt Sân";
            btnDatSan.UseVisualStyleBackColor = true;
            // 
            // btnKhachHang
            // 
            btnKhachHang.Location = new Point(29, 347);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(212, 46);
            btnKhachHang.TabIndex = 5;
            btnKhachHang.Text = "Khách Hàng";
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += button5_Click;
            // 
            // btnDichVu
            // 
            btnDichVu.Location = new Point(29, 416);
            btnDichVu.Name = "btnDichVu";
            btnDichVu.Size = new Size(150, 46);
            btnDichVu.TabIndex = 6;
            btnDichVu.Text = "Dịch Vụ";
            btnDichVu.UseVisualStyleBackColor = true;
            // 
            // btnHoaDon
            // 
            btnHoaDon.Location = new Point(29, 490);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(150, 46);
            btnHoaDon.TabIndex = 7;
            btnHoaDon.Text = "Hóa Đơn";
            btnHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.Location = new Point(29, 568);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(150, 46);
            btnTaiKhoan.TabIndex = 8;
            btnTaiKhoan.Text = "Tài Khoản";
            btnTaiKhoan.UseVisualStyleBackColor = true;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            // 
            // btnBaoCao
            // 
            btnBaoCao.Location = new Point(29, 644);
            btnBaoCao.Name = "btnBaoCao";
            btnBaoCao.Size = new Size(150, 46);
            btnBaoCao.TabIndex = 9;
            btnBaoCao.Text = "Báo Cáo";
            btnBaoCao.UseVisualStyleBackColor = true;
            btnBaoCao.Click += button9_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Location = new Point(39, 715);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(158, 63);
            btnDangXuat.TabIndex = 10;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += button10_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(316, 700);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 46);
            btnThoat.TabIndex = 11;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            ClientSize = new Size(1400, 912);
            Controls.Add(btnTrangChu);
            Controls.Add(btnSanBong);
            Controls.Add(btnLoaiSan);
            Controls.Add(btnDatSan);
            Controls.Add(btnKhachHang);
            Controls.Add(btnDichVu);
            Controls.Add(btnHoaDon);
            Controls.Add(btnTaiKhoan);
            Controls.Add(btnBaoCao);
            Controls.Add(btnDangXuat);
            Controls.Add(btnThoat);
            Controls.Add(label1);
            Name = "FormMain";
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void MoForm(Form form)
        {
            form.StartPosition =
                FormStartPosition.CenterScreen;

            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private Label label1;
        private Button btnTrangChu;
        private Button btnSanBong;
        private Button btnLoaiSan;
        private Button btnDatSan;
        private Button btnKhachHang;
        private Button btnDichVu;
        private Button btnHoaDon;
        private Button btnTaiKhoan;
        private Button btnBaoCao;
        private Button btnDangXuat;
        private Button btnThoat;

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}