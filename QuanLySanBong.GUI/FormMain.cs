using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
namespace QuanLySanBong.GUI
{
    public partial class FormMain : Form
    {
        private string vaiTro;
        private TableLayoutPanel tableMenu;
        private Panel pnlMenu;
        private FlowLayoutPanel flpMenu;
        public FormMain(string vaiTro)
        {
            InitializeComponent();

            // Đăng ký sự kiện cho các nút
            //CauHinhNut(
            //    btnTrangChu,
            //    "btnTrangChu",
            //    "Trang Chu",
            //    Properties.Resources.soccer_feild
            //    );
            //btnTrangChu.Click += btnTrangChu_Click;
            //btnSanBong.Click += btnSanBong_Click;

            this.vaiTro = vaiTro;
            menuButtons = new Button[]
            {
                btnTrangChu,
                btnSanBong,
                btnDatSan,
                btnKhachHang,
                btnHoaDon,
                btnDangXuat
            };
            

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
            btnTrangChu = new Button();
            btnSanBong = new Button();
            btnDatSan = new Button();
            btnKhachHang = new Button();
            btnHoaDon = new Button();
            btnDangXuat = new Button();
            pnlNoiDung = new Panel();
            pnlMenu = new Panel();
            tableMenu = new TableLayoutPanel();
            flpMenu = new FlowLayoutPanel();
            pnlNoiDung.SuspendLayout();
            pnlMenu.SuspendLayout();
            tableMenu.SuspendLayout();
            SuspendLayout();
            // 
            // btnTrangChu
            // 
            btnTrangChu.BackColor = Color.FromArgb(37, 99, 235);
            btnTrangChu.Cursor = Cursors.Hand;
            btnTrangChu.Dock = DockStyle.Fill;
            btnTrangChu.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 95, 220);
            btnTrangChu.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 55, 80);
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new Font("Loma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrangChu.Image = Properties.Resources.soccer_feild;
            btnTrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTrangChu.Location = new Point(50, 50);
            btnTrangChu.Margin = new Padding(30);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(297, 64);
            btnTrangChu.TabIndex = 2;
            btnTrangChu.Text = "Trang Chủ";
            btnTrangChu.UseVisualStyleBackColor = false;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // btnSanBong
            // 
            btnSanBong.BackColor = Color.FromArgb(37, 99, 235);
            btnSanBong.Cursor = Cursors.Hand;
            btnSanBong.Dock = DockStyle.Fill;
            btnSanBong.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 95, 220);
            btnSanBong.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 55, 80);
            btnSanBong.FlatStyle = FlatStyle.Flat;
            btnSanBong.Font = new Font("Loma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSanBong.Image = Properties.Resources.soccer_feild;
            btnSanBong.ImageAlign = ContentAlignment.MiddleLeft;
            btnSanBong.Location = new Point(50, 174);
            btnSanBong.Margin = new Padding(30);
            btnSanBong.Name = "btnSanBong";
            btnSanBong.Size = new Size(297, 64);
            btnSanBong.TabIndex = 2;
            btnSanBong.Text = "Sân Bóng";
            btnSanBong.UseVisualStyleBackColor = false;
            btnSanBong.Click += btnSanBong_Click_2;
            // 
            // btnDatSan
            // 
            btnDatSan.BackColor = Color.FromArgb(37, 99, 235);
            btnDatSan.Dock = DockStyle.Fill;
            btnDatSan.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 95, 220);
            btnDatSan.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 55, 80);
            btnDatSan.FlatStyle = FlatStyle.Flat;
            btnDatSan.Image = Properties.Resources.schedule;
            btnDatSan.ImageAlign = ContentAlignment.MiddleLeft;
            btnDatSan.Location = new Point(50, 298);
            btnDatSan.Margin = new Padding(30);
            btnDatSan.Name = "btnDatSan";
            btnDatSan.Size = new Size(297, 64);
            btnDatSan.TabIndex = 3;
            btnDatSan.Text = "Lịch Sân";
            btnDatSan.UseVisualStyleBackColor = true;
            btnDatSan.Click += button1_Click_2;
            // 
            // btnKhachHang
            // 
            btnKhachHang.BackColor = Color.FromArgb(37, 99, 235);
            btnKhachHang.Dock = DockStyle.Fill;
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Image = Properties.Resources.person1;
            btnKhachHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnKhachHang.Location = new Point(50, 422);
            btnKhachHang.Margin = new Padding(30);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(297, 64);
            btnKhachHang.TabIndex = 4;
            btnKhachHang.Text = "Khách Hàng";
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += btnKhachHang_Click_1;
            // 
            // btnHoaDon
            // 
            btnHoaDon.BackColor = Color.FromArgb(37, 99, 235);
            btnHoaDon.Dock = DockStyle.Fill;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Image = Properties.Resources.Bill;
            btnHoaDon.ImageAlign = ContentAlignment.MiddleLeft;
            btnHoaDon.Location = new Point(50, 546);
            btnHoaDon.Margin = new Padding(35);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(297, 64);
            btnHoaDon.TabIndex = 5;
            btnHoaDon.Text = "Hóa Đơn";
            btnHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(37, 99, 235);
            btnDangXuat.Dock = DockStyle.Fill;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Image = Properties.Resources.Logout;
            btnDangXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.Location = new Point(50, 670);
            btnDangXuat.Margin = new Padding(30);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(297, 66);
            btnDangXuat.TabIndex = 6;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.BackColor = Color.White;
            pnlNoiDung.Controls.Add(pnlMenu);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.ForeColor = SystemColors.ButtonHighlight;
            pnlNoiDung.Location = new Point(0, 0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Size = new Size(1690, 786);
            pnlNoiDung.TabIndex = 7;
            pnlNoiDung.Paint += pnlNoiDung_Paint;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(15, 23, 42);
            pnlMenu.Controls.Add(tableMenu);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(397, 786);
            pnlMenu.TabIndex = 1;
            // 
            // tableMenu
            // 
            tableMenu.ColumnCount = 1;
            tableMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableMenu.Controls.Add(btnTrangChu, 0, 0);
            tableMenu.Controls.Add(btnDangXuat, 0, 5);
            tableMenu.Controls.Add(btnHoaDon, 0, 4);
            tableMenu.Controls.Add(btnKhachHang, 0, 3);
            tableMenu.Controls.Add(btnDatSan, 0, 2);
            tableMenu.Controls.Add(btnSanBong, 0, 1);
            tableMenu.Dock = DockStyle.Fill;
            tableMenu.Location = new Point(0, 0);
            tableMenu.Name = "tableMenu";
            tableMenu.Padding = new Padding(20);
            tableMenu.RowCount = 6;
            tableMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableMenu.Size = new Size(397, 786);
            tableMenu.TabIndex = 0;
            tableMenu.Paint += tableMenu_Paint;
            // 
            // flpMenu
            // 
            flpMenu.Location = new Point(0, 0);
            flpMenu.Name = "flpMenu";
            flpMenu.Size = new Size(200, 100);
            flpMenu.TabIndex = 0;
            // 
            // FormMain
            // 
            ClientSize = new Size(1690, 786);
            Controls.Add(pnlNoiDung);
            Name = "FormMain";
            Load += FormMain_Load;
            pnlNoiDung.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            tableMenu.ResumeLayout(false);
            ResumeLayout(false);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private Button btnSanBong;
        private Button btnDatSan;
        private Button btnKhachHang;
        private Button btnHoaDon;
        internal Button btnDangXuat;
        private Panel pnlNoiDung;
        private Button btnTrangChu;

        private void picTrangChu_Click(object sender, EventArgs e)
        {
            btnTrangChu.PerformClick();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnSanBong_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        // Cấu Hình Nút Nhanh Đều Đỡ mất Thời Gian
        //private void CauHinhNut(
        //    Button button,
        //    string tenNut,
        //    string noiDung,
        //    Image image
        //    )
        //{
        //    button.Name = tenNut;
        //    button.Text = noiDung;
        //    button.Image = image;
        //    button.BackColor = Color.FromArgb(0, 255, 0);
        //    //Tự do scales trong tablelayout

        //    button.Margin = new Padding(10);
        //    button.AutoSize = false;
        //    button.Dock = DockStyle.Fill;

        //    //Hiển Thị Ảnh và chữ
        //    button.ImageAlign = ContentAlignment.MiddleLeft;
        //    button.TextAlign = ContentAlignment.MiddleCenter;
        //    button.TextImageRelation = TextImageRelation.ImageBeforeText;
        //    //Giao diện
        //    button.Cursor = Cursors.Hand;
        //    button.FlatStyle = FlatStyle.Flat;
        //    button.FlatAppearance.BorderSize = 0;
        //    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 30, 255);
        //    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 32, 42);
        //    button.ForeColor = Color.Black;
        //    button.Font = new Font(
        //        "Loma",
        //        9f,
        //        FontStyle.Bold,
        //        GraphicsUnit.Point);
        //    button.UseVisualStyleBackColor = false;

        //}

        private void tableMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSanBong_Click_2(object sender, EventArgs e)
        {

        }

        private void btnTrangChu_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTrangChu_Click_2(object sender, EventArgs e)
        {

        }

        private void pnlNoiDung_Paint(object sender, PaintEventArgs e)
        {

        }
        private readonly Button[] menuButtons;
        private const double ButtonRatio = 4.65;
        private const double MenuWidthRatio = 0.23;
        private void CauHinhMenuResponsive()
        {
            tableMenu.Visible = false;
            pnlMenu.Controls.Remove(tableMenu);
            foreach(Button button in menuButtons)
            {
                pnlMenu.Controls.Add(button);
                button.AutoSize = false;
                button.Margin = Padding.Empty;
                button.Anchor = AnchorStyles.None;

                //
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.TextImageRelation = TextImageRelation.ImageBeforeText;
            }

        }
        
    }
}