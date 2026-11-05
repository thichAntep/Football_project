namespace QuanLySanBong.GUI
{
    partial class Form_Main
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
            pnlMenu = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            tlnMenu = new TableLayoutPanel();
            btnThemSan = new Button();
            lblDatSan = new Label();
            lblKhachHang = new Label();
            lblLichDat = new Label();
            label7 = new Label();
            btnTrangChu = new Button();
            helpProvider1 = new HelpProvider();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            pnlContent = new Panel();
            pnlMenu.SuspendLayout();
            panel1.SuspendLayout();
            tlnMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(panel1);
            pnlMenu.Controls.Add(tlnMenu);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(271, 991);
            pnlMenu.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 97);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Image = Properties.Resources.Sole;
            label2.ImageAlign = ContentAlignment.BottomLeft;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(266, 64);
            label2.TabIndex = 2;
            label2.Text = "      \r\n        Quản Lý Sân Bóng";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Image = Properties.Resources.Sole;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.BottomCenter;
            label1.Click += label1_Click;
            // 
            // tlnMenu
            // 
            tlnMenu.ColumnCount = 1;
            tlnMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlnMenu.Controls.Add(btnThemSan, 0, 4);
            tlnMenu.Controls.Add(lblDatSan, 0, 1);
            tlnMenu.Controls.Add(lblKhachHang, 0, 2);
            tlnMenu.Controls.Add(lblLichDat, 0, 3);
            tlnMenu.Controls.Add(label7, 0, 5);
            tlnMenu.Controls.Add(btnTrangChu, 0, 0);
            tlnMenu.Location = new Point(21, 143);
            tlnMenu.Name = "tlnMenu";
            tlnMenu.RowCount = 6;
            tlnMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlnMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlnMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlnMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlnMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlnMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlnMenu.Size = new Size(235, 650);
            tlnMenu.TabIndex = 0;
            tlnMenu.Paint += tlnMenu_Paint;
            // 
            // btnThemSan
            // 
            btnThemSan.Dock = DockStyle.Fill;
            btnThemSan.Location = new Point(3, 435);
            btnThemSan.Name = "btnThemSan";
            btnThemSan.Size = new Size(229, 102);
            btnThemSan.TabIndex = 1;
            btnThemSan.Text = "Thêm Sân";
            btnThemSan.UseVisualStyleBackColor = true;
            btnThemSan.Click += btnThemSan_Click;
            // 
            // lblDatSan
            // 
            lblDatSan.AutoSize = true;
            lblDatSan.Dock = DockStyle.Fill;
            lblDatSan.Image = Properties.Resources.soccer_feild;
            lblDatSan.ImageAlign = ContentAlignment.MiddleLeft;
            lblDatSan.Location = new Point(3, 108);
            lblDatSan.Name = "lblDatSan";
            lblDatSan.Size = new Size(229, 108);
            lblDatSan.TabIndex = 1;
            lblDatSan.Text = "Đặt Sân";
            lblDatSan.TextAlign = ContentAlignment.MiddleCenter;
            lblDatSan.Click += label3_Click;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Dock = DockStyle.Fill;
            lblKhachHang.ForeColor = SystemColors.ControlText;
            lblKhachHang.Image = Properties.Resources.person;
            lblKhachHang.ImageAlign = ContentAlignment.MiddleLeft;
            lblKhachHang.Location = new Point(3, 216);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(229, 108);
            lblKhachHang.TabIndex = 2;
            lblKhachHang.Text = "Khách Hàng";
            lblKhachHang.TextAlign = ContentAlignment.MiddleCenter;
            lblKhachHang.UseWaitCursor = true;
            // 
            // lblLichDat
            // 
            lblLichDat.AutoSize = true;
            lblLichDat.Dock = DockStyle.Fill;
            lblLichDat.Image = Properties.Resources.schedule;
            lblLichDat.ImageAlign = ContentAlignment.MiddleLeft;
            lblLichDat.Location = new Point(3, 324);
            lblLichDat.Name = "lblLichDat";
            lblLichDat.Size = new Size(229, 108);
            lblLichDat.TabIndex = 3;
            lblLichDat.Text = "Lịch Đặt";
            lblLichDat.TextAlign = ContentAlignment.MiddleCenter;
            lblLichDat.UseMnemonic = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 540);
            label7.Name = "label7";
            label7.Size = new Size(78, 32);
            label7.TabIndex = 5;
            label7.Text = "label7";
            // 
            // btnTrangChu
            // 
            btnTrangChu.Dock = DockStyle.Fill;
            btnTrangChu.Location = new Point(3, 3);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(229, 102);
            btnTrangChu.TabIndex = 6;
            btnTrangChu.Text = "Trang Chủ";
            btnTrangChu.UseVisualStyleBackColor = true;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Right;
            pnlContent.Location = new Point(275, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1544, 991);
            pnlContent.TabIndex = 1;
            // 
            // Form_Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1819, 991);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Name = "Form_Main";
            Text = "Form_Main";
            pnlMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tlnMenu.ResumeLayout(false);
            tlnMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private TableLayoutPanel tlnMenu;
        private Label label1;
        private Label lblDatSan;
        private Label lblKhachHang;
        private Label lblLichDat;
        private Label label7;
        private Panel panel1;
        private Label label2;
        private HelpProvider helpProvider1;
        private Button btnThemSan;
        private Button btnTrangChu;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Panel pnlContent;
    }
}