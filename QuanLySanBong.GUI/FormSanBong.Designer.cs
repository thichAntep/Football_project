
namespace QuanLySanBong.GUI
{
    partial class FormSanBong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            label8 = new Label();
            txtTimKiem = new TextBox();
            dgvSanBong = new DataGridView();
            cboTrangThai = new ComboBox();
            txtMaSan = new TextBox();
            txtTenSan = new TextBox();
            txtGiaThue = new TextBox();
            cboLoaiSan = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSanBong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold);
            label1.Location = new Point(731, 60);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(510, 56);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ SÂN BÓNG";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold);
            label2.Location = new Point(98, 180);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(325, 37);
            label2.TabIndex = 1;
            label2.Text = "Thông Tin Sân Bóng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Bold);
            label3.Location = new Point(98, 280);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(118, 32);
            label3.TabIndex = 2;
            label3.Text = "Mã Sân:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Bold);
            label4.Location = new Point(98, 390);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(132, 32);
            label4.TabIndex = 3;
            label4.Text = "Tên Sân:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10F, FontStyle.Bold);
            label5.Location = new Point(98, 500);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(139, 32);
            label5.TabIndex = 4;
            label5.Text = "Loại Sân:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Bold);
            label6.Location = new Point(98, 610);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(143, 32);
            label6.TabIndex = 5;
            label6.Text = "Giá Thuê:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 10F, FontStyle.Bold);
            label7.Location = new Point(98, 720);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(167, 32);
            label7.TabIndex = 6;
            label7.Text = "Trạng Thái:";
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnThem.Location = new Point(65, 840);
            btnThem.Margin = new Padding(5, 6, 5, 6);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(211, 80);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnSua.Location = new Point(309, 840);
            btnSua.Margin = new Padding(5, 6, 5, 6);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(211, 80);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnXoa.Location = new Point(552, 840);
            btnXoa.Margin = new Padding(5, 6, 5, 6);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(211, 80);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnLamMoi.Location = new Point(796, 840);
            btnLamMoi.Margin = new Padding(5, 6, 5, 6);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(211, 80);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnTimKiem.Location = new Point(715, 980);
            btnTimKiem.Margin = new Padding(5, 6, 5, 6);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(211, 80);
            btnTimKiem.TabIndex = 18;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 10F, FontStyle.Bold);
            label8.Location = new Point(98, 1000);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(148, 32);
            label8.TabIndex = 16;
            label8.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(325, 990);
            txtTimKiem.Margin = new Padding(5, 6, 5, 6);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(355, 39);
            txtTimKiem.TabIndex = 17;
            // 
            // dgvSanBong
            // 
            dgvSanBong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanBong.Location = new Point(79, 1069);
            dgvSanBong.Name = "dgvSanBong";
            dgvSanBong.RowHeadersWidth = 82;
            dgvSanBong.Size = new Size(857, 327);
            dgvSanBong.TabIndex = 19;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(309, 712);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(384, 40);
            cboTrangThai.TabIndex = 20;
            // 
            // txtMaSan
            // 
            txtMaSan.Location = new Point(325, 270);
            txtMaSan.Margin = new Padding(5, 6, 5, 6);
            txtMaSan.Name = "txtMaSan";
            txtMaSan.Size = new Size(355, 39);
            txtMaSan.TabIndex = 7;
            // 
            // txtTenSan
            // 
            txtTenSan.Location = new Point(325, 380);
            txtTenSan.Margin = new Padding(5, 6, 5, 6);
            txtTenSan.Name = "txtTenSan";
            txtTenSan.Size = new Size(355, 39);
            txtTenSan.TabIndex = 8;
            // 
            // txtGiaThue
            // 
            txtGiaThue.Location = new Point(325, 600);
            txtGiaThue.Margin = new Padding(5, 6, 5, 6);
            txtGiaThue.Name = "txtGiaThue";
            txtGiaThue.Size = new Size(355, 39);
            txtGiaThue.TabIndex = 10;
            // 
            // comboBox1
            // 
            cboLoaiSan.FormattingEnabled = true;
            cboLoaiSan.Location = new Point(309, 492);
            cboLoaiSan.Name = "comboBox1";
            cboLoaiSan.Size = new Size(384, 40);
            cboLoaiSan.TabIndex = 22;
            // 
            // FormSanBong
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1791, 1239);
            Controls.Add(cboLoaiSan);
            Controls.Add(cboTrangThai);
            Controls.Add(dgvSanBong);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(txtMaSan);
            Controls.Add(txtTenSan);
            Controls.Add(txtGiaThue);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(label8);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormSanBong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Sân Bóng";
            Load += FormSanBong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanBong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;

        private Label label8;
        private TextBox txtTimKiem;
        private DataGridView dgvSanBong;
        private ComboBox cboTrangThai;
        private TextBox txtMaSan;
        private TextBox txtTenSan;
        private TextBox txtGiaThue;
        private ComboBox cboLoaiSan;
    }
}
