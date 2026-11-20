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
            dgvHoaDon = new DataGridView();
            pnlChiTiet = new Panel();
            btnLamMoi = new Button();
            btnThanhToan = new Button();
            lblTienDV = new Label();
            lblTienSan = new Label();
            dgvChiTiet = new DataGridView();
            lblGioRa = new Label();
            lblGioVao = new Label();
            lblKhach = new Label();
            lblSan = new Label();
            lblMaHD = new Label();
            pnlLoc = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            cboTrangThai = new ComboBox();
            txtTim = new TextBox();
            btnTim = new Button();
            lblTongTien = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            pnlLoc.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(49, 535);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(139, 32);
            lblTongTien.TabIndex = 8;
            lblTongTien.Text = "lblTongTien";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(pnlLoc, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.Size = new Size(1191, 777);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(dgvHoaDon, 0, 0);
            tableLayoutPanel2.Controls.Add(pnlChiTiet, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 119);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1185, 655);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(3, 3);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 82;
            dgvHoaDon.Size = new Size(705, 649);
            dgvHoaDon.TabIndex = 0;
            // 
            // pnlChiTiet
            // 
            pnlChiTiet.Controls.Add(btnLamMoi);
            pnlChiTiet.Controls.Add(btnThanhToan);
            pnlChiTiet.Controls.Add(lblTongTien);
            pnlChiTiet.Controls.Add(lblTienDV);
            pnlChiTiet.Controls.Add(lblTienSan);
            pnlChiTiet.Controls.Add(dgvChiTiet);
            pnlChiTiet.Controls.Add(lblGioRa);
            pnlChiTiet.Controls.Add(lblGioVao);
            pnlChiTiet.Controls.Add(lblKhach);
            pnlChiTiet.Controls.Add(lblSan);
            pnlChiTiet.Controls.Add(lblMaHD);
            pnlChiTiet.Dock = DockStyle.Fill;
            pnlChiTiet.Location = new Point(714, 3);
            pnlChiTiet.Name = "pnlChiTiet";
            pnlChiTiet.Size = new Size(468, 649);
            pnlChiTiet.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(295, 597);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 46);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(52, 593);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(150, 46);
            btnThanhToan.TabIndex = 9;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // lblTienDV
            // 
            lblTienDV.AutoSize = true;
            lblTienDV.Location = new Point(262, 474);
            lblTienDV.Name = "lblTienDV";
            lblTienDV.Size = new Size(117, 32);
            lblTienDV.TabIndex = 7;
            lblTienDV.Text = "lblTienDV";
            // 
            // lblTienSan
            // 
            lblTienSan.AutoSize = true;
            lblTienSan.Location = new Point(49, 474);
            lblTienSan.Name = "lblTienSan";
            lblTienSan.RightToLeft = RightToLeft.No;
            lblTienSan.Size = new Size(125, 32);
            lblTienSan.TabIndex = 6;
            lblTienSan.Text = "lblTienSan";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(19, 248);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 82;
            dgvChiTiet.Size = new Size(437, 199);
            dgvChiTiet.TabIndex = 5;
            // 
            // lblGioRa
            // 
            lblGioRa.AutoSize = true;
            lblGioRa.Location = new Point(66, 197);
            lblGioRa.Name = "lblGioRa";
            lblGioRa.Size = new Size(102, 32);
            lblGioRa.TabIndex = 4;
            lblGioRa.Text = "lblGioRa";
            // 
            // lblGioVao
            // 
            lblGioVao.AutoSize = true;
            lblGioVao.Location = new Point(262, 124);
            lblGioVao.Name = "lblGioVao";
            lblGioVao.Size = new Size(115, 32);
            lblGioVao.TabIndex = 3;
            lblGioVao.Text = "lblGioVao";
            // 
            // lblKhach
            // 
            lblKhach.AutoSize = true;
            lblKhach.Location = new Point(45, 124);
            lblKhach.Name = "lblKhach";
            lblKhach.Size = new Size(99, 32);
            lblKhach.TabIndex = 2;
            lblKhach.Text = "lbKhach";
            // 
            // lblSan
            // 
            lblSan.AutoSize = true;
            lblSan.Location = new Point(282, 42);
            lblSan.Name = "lblSan";
            lblSan.Size = new Size(79, 32);
            lblSan.TabIndex = 1;
            lblSan.Text = "lblSan";
            // 
            // lblMaHD
            // 
            lblMaHD.AutoSize = true;
            lblMaHD.Location = new Point(34, 42);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(82, 32);
            lblMaHD.TabIndex = 0;
            lblMaHD.Text = "MaHD";
            // 
            // pnlLoc
            // 
            pnlLoc.Controls.Add(tableLayoutPanel3);
            pnlLoc.Dock = DockStyle.Fill;
            pnlLoc.Location = new Point(3, 3);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1185, 110);
            pnlLoc.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel3.Controls.Add(dtpTuNgay, 0, 0);
            tableLayoutPanel3.Controls.Add(dtpDenNgay, 1, 0);
            tableLayoutPanel3.Controls.Add(cboTrangThai, 2, 0);
            tableLayoutPanel3.Controls.Add(txtTim, 3, 0);
            tableLayoutPanel3.Controls.Add(btnTim, 4, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1185, 110);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Anchor = AnchorStyles.None;
            dtpTuNgay.Location = new Point(3, 35);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(290, 39);
            dtpTuNgay.TabIndex = 0;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Anchor = AnchorStyles.None;
            dtpDenNgay.Location = new Point(299, 35);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(290, 39);
            dtpDenNgay.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Anchor = AnchorStyles.None;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(595, 35);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(231, 40);
            cboTrangThai.TabIndex = 2;
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.None;
            txtTim.Location = new Point(832, 35);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(171, 39);
            txtTim.TabIndex = 3;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.None;
            btnTim.Location = new Point(1020, 32);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(150, 46);
            btnTim.TabIndex = 4;
            btnTim.Text = "Tìm Kiếm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // ucHoaDon
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucHoaDon";
            Size = new Size(1191, 777);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            pnlChiTiet.ResumeLayout(false);
            pnlChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            pnlLoc.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dgvHoaDon;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel pnlChiTiet;
        private Panel pnlLoc;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblGioRa;
        private Label lblGioVao;
        private Label lblKhach;
        private Label lblSan;
        private Label lblMaHD;
        private ComboBox cboTrangThai;
        private TextBox txtTim;
        private Button btnTim;
        private Button btnLamMoi;
        private Button btnThanhToan;
        private Label lblTongTien;
        private Label lblTienDV;
        private Label lblTienSan;
        private DataGridView dgvChiTiet;
    }
}
