namespace QuanLySanBong.GUI
{
    partial class ucHoaDon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            cboSanHoaDon = new ComboBox();
            dgvDichVu = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            lblMaHD = new Label();
            lblTenSan = new Label();
            lblKhachHang = new Label();
            lblGioVao = new Label();
            lblGioRa = new Label();
            lblThoiGianDa = new Label();
            lblTienSan = new Label();
            lblTienDichVu = new Label();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            btnInHoaDon = new Button();
            btnLamMoi = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1016, 604);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(cboSanHoaDon, 0, 1);
            tableLayoutPanel2.Controls.Add(dgvDichVu, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(502, 598);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(511, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.Size = new Size(502, 598);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(151, 13);
            label1.Name = "label1";
            label1.Size = new Size(200, 32);
            label1.TabIndex = 0;
            label1.Text = "Dịch Vụ Đã Dùng";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(149, 13);
            label2.Name = "label2";
            label2.Size = new Size(203, 32);
            label2.TabIndex = 0;
            label2.Text = "Chi Tiết Tính Tiền";
            // 
            // cboSanHoaDon
            // 
            cboSanHoaDon.FormattingEnabled = true;
            cboSanHoaDon.Location = new Point(3, 62);
            cboSanHoaDon.Name = "cboSanHoaDon";
            cboSanHoaDon.Size = new Size(225, 40);
            cboSanHoaDon.TabIndex = 1;
            // 
            // dgvDichVu
            // 
            dgvDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVu.Dock = DockStyle.Fill;
            dgvDichVu.Location = new Point(3, 121);
            dgvDichVu.Name = "dgvDichVu";
            dgvDichVu.RowHeadersWidth = 82;
            dgvDichVu.Size = new Size(496, 352);
            dgvDichVu.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(lblMaHD, 0, 0);
            tableLayoutPanel4.Controls.Add(lblTenSan, 0, 1);
            tableLayoutPanel4.Controls.Add(lblKhachHang, 0, 2);
            tableLayoutPanel4.Controls.Add(lblGioVao, 0, 3);
            tableLayoutPanel4.Controls.Add(lblGioRa, 0, 4);
            tableLayoutPanel4.Controls.Add(lblThoiGianDa, 0, 5);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 62);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 6;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel4.Size = new Size(496, 233);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(lblTienSan, 0, 0);
            tableLayoutPanel5.Controls.Add(lblTienDichVu, 0, 1);
            tableLayoutPanel5.Controls.Add(lblTongTien, 0, 2);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 301);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Size = new Size(496, 203);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.Controls.Add(btnThanhToan, 0, 0);
            tableLayoutPanel6.Controls.Add(btnInHoaDon, 1, 0);
            tableLayoutPanel6.Controls.Add(btnLamMoi, 2, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 510);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(496, 85);
            tableLayoutPanel6.TabIndex = 3;
            // 
            // lblMaHD
            // 
            lblMaHD.Anchor = AnchorStyles.Left;
            lblMaHD.AutoSize = true;
            lblMaHD.Location = new Point(3, 3);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(212, 32);
            lblMaHD.TabIndex = 0;
            lblMaHD.Text = "Mã Hóa Đơn: -----";
            // 
            // lblTenSan
            // 
            lblTenSan.Anchor = AnchorStyles.Left;
            lblTenSan.AutoSize = true;
            lblTenSan.Location = new Point(3, 41);
            lblTenSan.Name = "lblTenSan";
            lblTenSan.Size = new Size(178, 32);
            lblTenSan.TabIndex = 1;
            lblTenSan.Text = "Sân Bóng: -----";
            // 
            // lblKhachHang
            // 
            lblKhachHang.Anchor = AnchorStyles.Left;
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(3, 79);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(225, 32);
            lblKhachHang.TabIndex = 2;
            lblKhachHang.Text = "Khách Hàng: -------";
            // 
            // lblGioVao
            // 
            lblGioVao.AutoSize = true;
            lblGioVao.Location = new Point(3, 114);
            lblGioVao.Name = "lblGioVao";
            lblGioVao.Size = new Size(168, 32);
            lblGioVao.TabIndex = 3;
            lblGioVao.Text = "Giờ Vào: ------";
            // 
            // lblGioRa
            // 
            lblGioRa.AutoSize = true;
            lblGioRa.Location = new Point(3, 152);
            lblGioRa.Name = "lblGioRa";
            lblGioRa.Size = new Size(155, 32);
            lblGioRa.TabIndex = 4;
            lblGioRa.Text = "Giờ Ra: ------";
            lblGioRa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblThoiGianDa
            // 
            lblThoiGianDa.AutoSize = true;
            lblThoiGianDa.Location = new Point(3, 190);
            lblThoiGianDa.Name = "lblThoiGianDa";
            lblThoiGianDa.Size = new Size(224, 32);
            lblThoiGianDa.TabIndex = 5;
            lblThoiGianDa.Text = "Thời Gian Đá: ------";
            // 
            // lblTienSan
            // 
            lblTienSan.Anchor = AnchorStyles.Left;
            lblTienSan.AutoSize = true;
            lblTienSan.Location = new Point(3, 17);
            lblTienSan.Name = "lblTienSan";
            lblTienSan.Size = new Size(188, 32);
            lblTienSan.TabIndex = 0;
            lblTienSan.Text = "Tiền Sân: 0 VNĐ";
            // 
            // lblTienDichVu
            // 
            lblTienDichVu.Anchor = AnchorStyles.Left;
            lblTienDichVu.AutoSize = true;
            lblTienDichVu.Location = new Point(3, 84);
            lblTienDichVu.Name = "lblTienDichVu";
            lblTienDichVu.Size = new Size(233, 32);
            lblTienDichVu.TabIndex = 1;
            lblTienDichVu.Text = "Tiền Dịch Vụ: 0 VNĐ";
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Left;
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(3, 152);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(283, 32);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "Tổng Thanh Toán: 0 VNĐ";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Anchor = AnchorStyles.None;
            btnThanhToan.Location = new Point(7, 19);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(150, 46);
            btnThanhToan.TabIndex = 0;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Anchor = AnchorStyles.None;
            btnInHoaDon.Location = new Point(172, 19);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(150, 46);
            btnInHoaDon.TabIndex = 1;
            btnInHoaDon.Text = "In Hóa Đơn";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.None;
            btnLamMoi.Location = new Point(338, 19);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // ucHoaDon
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucHoaDon";
            Size = new Size(1016, 604);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private ComboBox cboSanHoaDon;
        private DataGridView dgvDichVu;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label lblMaHD;
        private Label lblTenSan;
        private Label lblKhachHang;
        private Label lblGioVao;
        private Label lblGioRa;
        private Label lblThoiGianDa;
        private Label lblTienSan;
        private Label lblTienDichVu;
        private Label lblTongTien;
        private Button btnThanhToan;
        private Button btnInHoaDon;
        private Button btnLamMoi;
    }
}
