namespace QuanLySanBong.GUI
{
    partial class FormDangKy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            txtNhapLaiMatKhau = new TextBox();
            txtHoTen = new TextBox();
            lebael1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnDangKy = new Button();
            btnQuaylai = new Button();
            SuspendLayout();
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(401, 154);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(372, 39);
            txtTenDangNhap.TabIndex = 0;
            txtTenDangNhap.TextChanged += txtTenDangNhap_TextChanged;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(401, 213);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(372, 39);
            txtMatKhau.TabIndex = 1;
            // 
            // txtNhapLaiMatKhau
            // 
            txtNhapLaiMatKhau.BackColor = SystemColors.HighlightText;
            txtNhapLaiMatKhau.Location = new Point(401, 275);
            txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            txtNhapLaiMatKhau.Size = new Size(372, 39);
            txtNhapLaiMatKhau.TabIndex = 2;
            txtNhapLaiMatKhau.TextChanged += txtNhapLaiMatKhau_TextChanged;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(401, 91);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(372, 39);
            txtHoTen.TabIndex = 10;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            // 
            // lebael1
            // 
            lebael1.AutoSize = true;
            lebael1.Location = new Point(142, 161);
            lebael1.Name = "lebael1";
            lebael1.Size = new Size(193, 32);
            lebael1.TabIndex = 6;
            lebael1.Text = "Tên Đăng Nhập: ";
            lebael1.Click += lebael1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 220);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 7;
            label2.Text = "Mật Khẩu: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 282);
            label3.Name = "label3";
            label3.Size = new Size(230, 32);
            label3.TabIndex = 8;
            label3.Text = "Nhập Lại Mật Khẩu: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(131, 317);
            label4.Name = "label4";
            label4.Size = new Size(0, 32);
            label4.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(194, 98);
            label1.Name = "label1";
            label1.Size = new Size(95, 32);
            label1.TabIndex = 11;
            label1.Text = "Họ Tên:";
            label1.Click += label1_Click;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(272, 345);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(150, 46);
            btnDangKy.TabIndex = 12;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnQuaylai
            // 
            btnQuaylai.Location = new Point(736, 345);
            btnQuaylai.Name = "btnQuaylai";
            btnQuaylai.Size = new Size(150, 46);
            btnQuaylai.TabIndex = 13;
            btnQuaylai.Text = "Quay Lại";
            btnQuaylai.UseVisualStyleBackColor = true;
            btnQuaylai.Click += btnQuayLai_Click;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 450);
            Controls.Add(btnQuaylai);
            Controls.Add(btnDangKy);
            Controls.Add(label1);
            Controls.Add(txtHoTen);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lebael1);
            Controls.Add(txtNhapLaiMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Name = "FormDangKy";
            Text = "DangKy";
            Load += FormDangKy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private TextBox txtNhapLaiMatKhau;
        private TextBox textBox4;
        private Button button1;
        private Label lebael1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtHoTen;
        private Label label1;
        private System.Windows.Forms.Button btnQuayLai;
        private Button btnDangKy;
        private Button btnQuaylai;

    }
}