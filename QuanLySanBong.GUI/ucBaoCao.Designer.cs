namespace QuanLySanBong.GUI
{
    partial class ucBaoCao
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
            groupBox1 = new GroupBox();
            btnXuatExcel = new Button();
            btnThongKe = new Button();
            btnThangNay = new Button();
            btnHomNay = new Button();
            lblSan = new Label();
            cboSanBong = new ComboBox();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            pnlCards = new Panel();
            pnlCard4 = new Panel();
            lblTongHoaDon = new Label();
            label4 = new Label();
            pnlCard3 = new Panel();
            lblTienDichVu = new Label();
            label3 = new Label();
            pnlCard2 = new Panel();
            lblTienSan = new Label();
            label2 = new Label();
            pnlCard1 = new Panel();
            lblTongDoanhThu = new Label();
            label1 = new Label();
            dgvBaoCao = new DataGridView();
            groupBox1.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuatExcel);
            groupBox1.Controls.Add(btnThongKe);
            groupBox1.Controls.Add(btnThangNay);
            groupBox1.Controls.Add(btnHomNay);
            groupBox1.Controls.Add(lblSan);
            groupBox1.Controls.Add(cboSanBong);
            groupBox1.Controls.Add(dtpDenNgay);
            groupBox1.Controls.Add(lblDenNgay);
            groupBox1.Controls.Add(dtpTuNgay);
            groupBox1.Controls.Add(lblTuNgay);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1285, 135);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "BỘ LỌC THỐNG KÊ";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(1154, 67);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(131, 46);
            btnXuatExcel.TabIndex = 9;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(1154, 3);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(131, 46);
            btnThongKe.TabIndex = 8;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnThangNay
            // 
            btnThangNay.Location = new Point(998, 67);
            btnThangNay.Name = "btnThangNay";
            btnThangNay.Size = new Size(150, 46);
            btnThangNay.TabIndex = 7;
            btnThangNay.Text = "Tháng Này";
            btnThangNay.UseVisualStyleBackColor = true;
            btnThangNay.Click += btnThangNay_Click;
            // 
            // btnHomNay
            // 
            btnHomNay.Location = new Point(998, 3);
            btnHomNay.Name = "btnHomNay";
            btnHomNay.Size = new Size(150, 46);
            btnHomNay.TabIndex = 6;
            btnHomNay.Text = "Hôm Nay";
            btnHomNay.UseVisualStyleBackColor = true;
            // 
            // lblSan
            // 
            lblSan.AutoSize = true;
            lblSan.Location = new Point(626, 57);
            lblSan.Name = "lblSan";
            lblSan.Size = new Size(129, 32);
            lblSan.TabIndex = 5;
            lblSan.Text = "Chọn Sân: ";
            // 
            // cboSanBong
            // 
            cboSanBong.FormattingEnabled = true;
            cboSanBong.Location = new Point(738, 54);
            cboSanBong.Name = "cboSanBong";
            cboSanBong.Size = new Size(242, 40);
            cboSanBong.TabIndex = 4;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(427, 57);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(193, 39);
            dtpDenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(306, 57);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(133, 32);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến Ngày: ";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(106, 57);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(194, 39);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(3, 57);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(116, 32);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ Ngày: ";
            // 
            // pnlCards
            // 
            pnlCards.Controls.Add(pnlCard4);
            pnlCards.Controls.Add(pnlCard3);
            pnlCards.Controls.Add(pnlCard2);
            pnlCards.Controls.Add(pnlCard1);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 135);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(1285, 230);
            pnlCards.TabIndex = 1;
            // 
            // pnlCard4
            // 
            pnlCard4.Controls.Add(lblTongHoaDon);
            pnlCard4.Controls.Add(label4);
            pnlCard4.Location = new Point(970, 21);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(215, 128);
            pnlCard4.TabIndex = 1;
            // 
            // lblTongHoaDon
            // 
            lblTongHoaDon.AutoSize = true;
            lblTongHoaDon.Location = new Point(87, 70);
            lblTongHoaDon.Name = "lblTongHoaDon";
            lblTongHoaDon.Size = new Size(76, 32);
            lblTongHoaDon.TabIndex = 1;
            lblTongHoaDon.Text = "0 lượt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 11);
            label4.Name = "label4";
            label4.Size = new Size(183, 32);
            label4.TabIndex = 0;
            label4.Text = "TỔNG SỐ LƯỢT";
            // 
            // pnlCard3
            // 
            pnlCard3.Controls.Add(lblTienDichVu);
            pnlCard3.Controls.Add(label3);
            pnlCard3.Location = new Point(667, 21);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(215, 128);
            pnlCard3.TabIndex = 1;
            // 
            // lblTienDichVu
            // 
            lblTienDichVu.AutoSize = true;
            lblTienDichVu.Location = new Point(81, 80);
            lblTienDichVu.Name = "lblTienDichVu";
            lblTienDichVu.Size = new Size(48, 32);
            lblTienDichVu.TabIndex = 1;
            lblTienDichVu.Text = "0 đ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(21, 11);
            label3.Name = "label3";
            label3.Size = new Size(163, 32);
            label3.TabIndex = 0;
            label3.Text = "TIỀN DỊCH VỤ";
            // 
            // pnlCard2
            // 
            pnlCard2.Controls.Add(lblTienSan);
            pnlCard2.Controls.Add(label2);
            pnlCard2.Location = new Point(354, 21);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(215, 128);
            pnlCard2.TabIndex = 1;
            // 
            // lblTienSan
            // 
            lblTienSan.AutoSize = true;
            lblTienSan.Location = new Point(80, 69);
            lblTienSan.Name = "lblTienSan";
            lblTienSan.RightToLeft = RightToLeft.No;
            lblTienSan.Size = new Size(48, 32);
            lblTienSan.TabIndex = 1;
            lblTienSan.Text = "0 đ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(73, 11);
            label2.Name = "label2";
            label2.Size = new Size(116, 32);
            label2.TabIndex = 0;
            label2.Text = "TIỀN SÂN";
            // 
            // pnlCard1
            // 
            pnlCard1.Controls.Add(lblTongDoanhThu);
            pnlCard1.Controls.Add(label1);
            pnlCard1.Location = new Point(43, 21);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(227, 128);
            pnlCard1.TabIndex = 0;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Location = new Point(63, 61);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(48, 32);
            lblTongDoanhThu.TabIndex = 1;
            lblTongDoanhThu.Text = "0 đ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(0, 29);
            label1.Name = "label1";
            label1.Size = new Size(223, 32);
            label1.TabIndex = 0;
            label1.Text = "TỔNG DOANH THU";
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Dock = DockStyle.Fill;
            dgvBaoCao.Location = new Point(0, 365);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersWidth = 82;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(1285, 241);
            dgvBaoCao.TabIndex = 2;
            // 
            // ucBaoCao
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvBaoCao);
            Controls.Add(pnlCards);
            Controls.Add(groupBox1);
            Name = "ucBaoCao";
            Size = new Size(1285, 606);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlCards.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblTuNgay;
        private Label lblSan;
        private ComboBox cboSanBong;
        private DateTimePicker dtpDenNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpTuNgay;
        private Button btnThangNay;
        private Button btnHomNay;
        private Panel pnlCards;
        private Panel pnlCard4;
        private Panel pnlCard3;
        private Panel pnlCard2;
        private Panel pnlCard1;
        private Label lblTongDoanhThu;
        private Label label1;
        private Label lblTongHoaDon;
        private Label label4;
        private Label lblTienDichVu;
        private Label label3;
        private Label lblTienSan;
        private Label label2;
        private DataGridView dgvBaoCao;
        private Button btnXuatExcel;
        private Button btnThongKe;
    }
}
