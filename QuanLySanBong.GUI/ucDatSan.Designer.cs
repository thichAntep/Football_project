namespace QuanLySanBong.GUI
{
    partial class ucDatSan
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
            tblMain = new TableLayoutPanel();
            tblTrai = new TableLayoutPanel();
            tblPhai = new TableLayoutPanel();
            tblLoc = new TableLayoutPanel();
            tblFieds = new TableLayoutPanel();
            lblTieuDeTrai = new Label();
            lblTieuDePhai = new Label();
            btnTimKiem = new Button();
            dtpNgay = new DateTimePicker();
            lblLoaiSan = new Label();
            cboLoaiSan = new ComboBox();
            fplChuThich = new FlowLayoutPanel();
            fplSoDoSan = new FlowLayoutPanel();
            txtSan = new TextBox();
            txtNgay = new TextBox();
            txtKhunGio = new TextBox();
            txtDonGia = new TextBox();
            txtSDT = new TextBox();
            txtTenKH = new TextBox();
            txtGhiChu = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            numTienCoc = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnDatSan = new Button();
            btnHuyPhieu = new Button();
            btnLamMoi = new Button();
            tblMain.SuspendLayout();
            tblTrai.SuspendLayout();
            tblPhai.SuspendLayout();
            tblLoc.SuspendLayout();
            tblFieds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTienCoc).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblMain.Controls.Add(tblTrai, 0, 0);
            tblMain.Controls.Add(tblPhai, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(1260, 717);
            tblMain.TabIndex = 0;
            // 
            // tblTrai
            // 
            tblTrai.ColumnCount = 1;
            tblTrai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblTrai.Controls.Add(tblLoc, 0, 1);
            tblTrai.Controls.Add(lblTieuDeTrai, 0, 0);
            tblTrai.Controls.Add(fplChuThich, 0, 2);
            tblTrai.Controls.Add(fplSoDoSan, 0, 3);
            tblTrai.Dock = DockStyle.Fill;
            tblTrai.Location = new Point(3, 3);
            tblTrai.Name = "tblTrai";
            tblTrai.RowCount = 4;
            tblTrai.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblTrai.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblTrai.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblTrai.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tblTrai.Size = new Size(876, 711);
            tblTrai.TabIndex = 0;
            // 
            // tblPhai
            // 
            tblPhai.ColumnCount = 1;
            tblPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPhai.Controls.Add(tblFieds, 0, 1);
            tblPhai.Controls.Add(lblTieuDePhai, 0, 0);
            tblPhai.Controls.Add(tableLayoutPanel1, 0, 2);
            tblPhai.Dock = DockStyle.Fill;
            tblPhai.Location = new Point(885, 3);
            tblPhai.Name = "tblPhai";
            tblPhai.RowCount = 3;
            tblPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 9.523809F));
            tblPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 76.1904755F));
            tblPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPhai.Size = new Size(372, 711);
            tblPhai.TabIndex = 1;
            // 
            // tblLoc
            // 
            tblLoc.ColumnCount = 4;
            tblLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblLoc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblLoc.Controls.Add(btnTimKiem, 0, 0);
            tblLoc.Controls.Add(dtpNgay, 1, 0);
            tblLoc.Controls.Add(lblLoaiSan, 2, 0);
            tblLoc.Controls.Add(cboLoaiSan, 3, 0);
            tblLoc.Location = new Point(3, 74);
            tblLoc.Name = "tblLoc";
            tblLoc.RowCount = 1;
            tblLoc.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblLoc.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLoc.Size = new Size(870, 100);
            tblLoc.TabIndex = 0;
            // 
            // tblFieds
            // 
            tblFieds.ColumnCount = 2;
            tblFieds.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.27322F));
            tblFieds.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.7267761F));
            tblFieds.Controls.Add(txtSan, 1, 0);
            tblFieds.Controls.Add(txtNgay, 1, 1);
            tblFieds.Controls.Add(txtKhunGio, 1, 2);
            tblFieds.Controls.Add(txtDonGia, 1, 3);
            tblFieds.Controls.Add(txtSDT, 1, 4);
            tblFieds.Controls.Add(txtTenKH, 1, 5);
            tblFieds.Controls.Add(txtGhiChu, 1, 7);
            tblFieds.Controls.Add(label1, 0, 0);
            tblFieds.Controls.Add(label2, 0, 1);
            tblFieds.Controls.Add(label3, 0, 2);
            tblFieds.Controls.Add(label4, 0, 3);
            tblFieds.Controls.Add(label5, 0, 4);
            tblFieds.Controls.Add(label6, 0, 5);
            tblFieds.Controls.Add(label7, 0, 6);
            tblFieds.Controls.Add(label8, 0, 7);
            tblFieds.Controls.Add(numTienCoc, 1, 6);
            tblFieds.Dock = DockStyle.Fill;
            tblFieds.Location = new Point(3, 70);
            tblFieds.Name = "tblFieds";
            tblFieds.RowCount = 8;
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblFieds.Size = new Size(366, 535);
            tblFieds.TabIndex = 0;
            // 
            // lblTieuDeTrai
            // 
            lblTieuDeTrai.Anchor = AnchorStyles.None;
            lblTieuDeTrai.AutoSize = true;
            lblTieuDeTrai.Location = new Point(278, 19);
            lblTieuDeTrai.Name = "lblTieuDeTrai";
            lblTieuDeTrai.Size = new Size(320, 32);
            lblTieuDeTrai.TabIndex = 1;
            lblTieuDeTrai.Text = "SƠ ĐỒ VÀ TÌNH TRẠNG SÂN";
            // 
            // lblTieuDePhai
            // 
            lblTieuDePhai.Anchor = AnchorStyles.None;
            lblTieuDePhai.AutoSize = true;
            lblTieuDePhai.Location = new Point(121, 17);
            lblTieuDePhai.Name = "lblTieuDePhai";
            lblTieuDePhai.Size = new Size(130, 32);
            lblTieuDePhai.TabIndex = 1;
            lblTieuDePhai.Text = "PHIẾU ĐẶT";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Dock = DockStyle.Fill;
            btnTimKiem.Location = new Point(3, 3);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(168, 94);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dtpNgay
            // 
            dtpNgay.Anchor = AnchorStyles.None;
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(177, 30);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(298, 39);
            dtpNgay.TabIndex = 1;
            // 
            // lblLoaiSan
            // 
            lblLoaiSan.Anchor = AnchorStyles.None;
            lblLoaiSan.Location = new Point(511, 28);
            lblLoaiSan.Name = "lblLoaiSan";
            lblLoaiSan.Size = new Size(107, 43);
            lblLoaiSan.TabIndex = 2;
            lblLoaiSan.Text = "Loại Sân";
            // 
            // cboLoaiSan
            // 
            cboLoaiSan.Anchor = AnchorStyles.None;
            cboLoaiSan.FormattingEnabled = true;
            cboLoaiSan.Location = new Point(655, 30);
            cboLoaiSan.Name = "cboLoaiSan";
            cboLoaiSan.Size = new Size(212, 40);
            cboLoaiSan.TabIndex = 3;
            // 
            // fplChuThich
            // 
            fplChuThich.Dock = DockStyle.Fill;
            fplChuThich.Location = new Point(3, 180);
            fplChuThich.Name = "fplChuThich";
            fplChuThich.Size = new Size(870, 100);
            fplChuThich.TabIndex = 2;
            // 
            // fplSoDoSan
            // 
            fplSoDoSan.Dock = DockStyle.Fill;
            fplSoDoSan.Location = new Point(3, 286);
            fplSoDoSan.Name = "fplSoDoSan";
            fplSoDoSan.Size = new Size(870, 422);
            fplSoDoSan.TabIndex = 3;
            // 
            // txtSan
            // 
            txtSan.Anchor = AnchorStyles.None;
            txtSan.Location = new Point(186, 13);
            txtSan.Name = "txtSan";
            txtSan.Size = new Size(177, 39);
            txtSan.TabIndex = 0;
            // 
            // txtNgay
            // 
            txtNgay.Anchor = AnchorStyles.None;
            txtNgay.Location = new Point(186, 79);
            txtNgay.Name = "txtNgay";
            txtNgay.Size = new Size(177, 39);
            txtNgay.TabIndex = 1;
            // 
            // txtKhunGio
            // 
            txtKhunGio.Location = new Point(186, 135);
            txtKhunGio.Name = "txtKhunGio";
            txtKhunGio.Size = new Size(177, 39);
            txtKhunGio.TabIndex = 2;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(186, 201);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(177, 39);
            txtDonGia.TabIndex = 3;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(186, 267);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(177, 39);
            txtSDT.TabIndex = 4;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(186, 333);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(177, 39);
            txtTenKH.TabIndex = 5;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(186, 465);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(177, 39);
            txtGhiChu.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(65, 17);
            label1.Name = "label1";
            label1.Size = new Size(53, 32);
            label1.TabIndex = 8;
            label1.Text = "Sân";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(56, 83);
            label2.Name = "label2";
            label2.Size = new Size(70, 32);
            label2.TabIndex = 9;
            label2.Text = "Ngày";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(28, 149);
            label3.Name = "label3";
            label3.Size = new Size(127, 32);
            label3.TabIndex = 10;
            label3.Text = "Khung Giờ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(41, 215);
            label4.Name = "label4";
            label4.Size = new Size(100, 32);
            label4.TabIndex = 11;
            label4.Text = "Đơn Giá";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(9, 281);
            label5.Name = "label5";
            label5.Size = new Size(164, 32);
            label5.TabIndex = 12;
            label5.Text = "Số Điện Thoại";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(29, 347);
            label6.Name = "label6";
            label6.Size = new Size(124, 32);
            label6.TabIndex = 13;
            label6.Text = "Tên Khách";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(38, 413);
            label7.Name = "label7";
            label7.Size = new Size(107, 32);
            label7.TabIndex = 14;
            label7.Text = "Tiền Cọc";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(41, 482);
            label8.Name = "label8";
            label8.Size = new Size(100, 32);
            label8.TabIndex = 15;
            label8.Text = "Ghi Chú";
            // 
            // numTienCoc
            // 
            numTienCoc.Location = new Point(186, 399);
            numTienCoc.Name = "numTienCoc";
            numTienCoc.Size = new Size(177, 39);
            numTienCoc.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(btnHuyPhieu, 1, 0);
            tableLayoutPanel1.Controls.Add(btnLamMoi, 2, 0);
            tableLayoutPanel1.Controls.Add(btnDatSan, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 611);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(366, 97);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // btnDatSan
            // 
            btnDatSan.Dock = DockStyle.Top;
            btnDatSan.Location = new Point(3, 3);
            btnDatSan.Name = "btnDatSan";
            btnDatSan.Size = new Size(116, 46);
            btnDatSan.TabIndex = 0;
            btnDatSan.Text = "Đặt Sân";
            btnDatSan.UseVisualStyleBackColor = true;
            // 
            // btnHuyPhieu
            // 
            btnHuyPhieu.Dock = DockStyle.Top;
            btnHuyPhieu.Location = new Point(125, 3);
            btnHuyPhieu.Name = "btnHuyPhieu";
            btnHuyPhieu.Size = new Size(116, 46);
            btnHuyPhieu.TabIndex = 1;
            btnHuyPhieu.Text = "Hủy";
            btnHuyPhieu.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Dock = DockStyle.Top;
            btnLamMoi.Location = new Point(247, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(116, 46);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // ucBaoCao
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblMain);
            Name = "ucBaoCao";
            Size = new Size(1260, 717);
            tblMain.ResumeLayout(false);
            tblTrai.ResumeLayout(false);
            tblTrai.PerformLayout();
            tblPhai.ResumeLayout(false);
            tblPhai.PerformLayout();
            tblLoc.ResumeLayout(false);
            tblFieds.ResumeLayout(false);
            tblFieds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTienCoc).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblTrai;
        private TableLayoutPanel tblPhai;
        private TableLayoutPanel tblLoc;
        private TableLayoutPanel tblFieds;
        private Label lblTieuDeTrai;
        private Label lblTieuDePhai;
        private Button btnTimKiem;
        private DateTimePicker dtpNgay;
        private Label lblLoaiSan;
        private ComboBox cboLoaiSan;
        private FlowLayoutPanel fplChuThich;
        private FlowLayoutPanel fplSoDoSan;
        private TextBox txtSan;
        private TextBox txtNgay;
        private TextBox txtKhunGio;
        private TextBox txtDonGia;
        private TextBox txtSDT;
        private TextBox txtTenKH;
        private TextBox txtGhiChu;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown numTienCoc;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnHuyPhieu;
        private Button btnLamMoi;
        private Button btnDatSan;
    }
}
