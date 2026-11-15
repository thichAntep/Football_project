namespace QuanLySanBong.GUI
{
    partial class ucTrangChu
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
            btnThemSan = new Button();
            pnlHeader = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblDoanhThu = new Label();
            lblSanDaDat = new Label();
            lblKhachMoi = new Label();
            lblSanTrong = new Label();
            dgvLich = new DataGridView();
            dtpNgay = new DateTimePicker();
            panel1 = new Panel();
            pnlHeader.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLich).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThemSan
            // 
            btnThemSan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemSan.Location = new Point(1479, 0);
            btnThemSan.Name = "btnThemSan";
            btnThemSan.Size = new Size(123, 46);
            btnThemSan.TabIndex = 3;
            btnThemSan.Text = "Thêm Sân";
            btnThemSan.UseVisualStyleBackColor = true;
            btnThemSan.Click += btnThemSan_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(tableLayoutPanel2);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1602, 158);
            pnlHeader.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(lblDoanhThu, 1, 0);
            tableLayoutPanel2.Controls.Add(lblSanDaDat, 0, 0);
            tableLayoutPanel2.Controls.Add(lblKhachMoi, 2, 0);
            tableLayoutPanel2.Controls.Add(lblSanTrong, 3, 0);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1602, 158);
            tableLayoutPanel2.TabIndex = 0;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // lblDoanhThu
            // 
            lblDoanhThu.Anchor = AnchorStyles.None;
            lblDoanhThu.AutoSize = true;
            lblDoanhThu.Location = new Point(533, 63);
            lblDoanhThu.Name = "lblDoanhThu";
            lblDoanhThu.Size = new Size(133, 32);
            lblDoanhThu.TabIndex = 1;
            lblDoanhThu.Text = "Doanh Thu";
            lblDoanhThu.Click += label2_Click;
            // 
            // lblSanDaDat
            // 
            lblSanDaDat.Anchor = AnchorStyles.None;
            lblSanDaDat.AutoSize = true;
            lblSanDaDat.Location = new Point(200, 63);
            lblSanDaDat.Name = "lblSanDaDat";
            lblSanDaDat.Size = new Size(0, 32);
            lblSanDaDat.TabIndex = 0;
            lblSanDaDat.Click += label1_Click;
            // 
            // lblKhachMoi
            // 
            lblKhachMoi.Anchor = AnchorStyles.None;
            lblKhachMoi.AutoSize = true;
            lblKhachMoi.Location = new Point(936, 63);
            lblKhachMoi.Name = "lblKhachMoi";
            lblKhachMoi.Size = new Size(128, 32);
            lblKhachMoi.TabIndex = 2;
            lblKhachMoi.Text = "Khách Mới";
            // 
            // lblSanTrong
            // 
            lblSanTrong.Anchor = AnchorStyles.None;
            lblSanTrong.AutoSize = true;
            lblSanTrong.Location = new Point(1308, 63);
            lblSanTrong.Name = "lblSanTrong";
            lblSanTrong.Size = new Size(185, 32);
            lblSanTrong.TabIndex = 3;
            lblSanTrong.Text = "Sân Đang Trống";
            // 
            // dgvLich
            // 
            dgvLich.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLich.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLich.Location = new Point(0, 45);
            dgvLich.Name = "dgvLich";
            dgvLich.RowHeadersWidth = 82;
            dgvLich.Size = new Size(1602, 517);
            dgvLich.TabIndex = 5;
            // 
            // dtpNgay
            // 
            dtpNgay.Dock = DockStyle.Left;
            dtpNgay.Location = new Point(0, 0);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(400, 39);
            dtpNgay.TabIndex = 6;
            dtpNgay.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpNgay);
            panel1.Controls.Add(dgvLich);
            panel1.Controls.Add(btnThemSan);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 158);
            panel1.Name = "panel1";
            panel1.Size = new Size(1602, 562);
            panel1.TabIndex = 7;
            // 
            // ucTrangChu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(pnlHeader);
            Name = "ucTrangChu";
            Size = new Size(1602, 720);
            pnlHeader.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLich).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnThemSan;
        private Panel pnlHeader;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblSanDaDat;
        private Label lblDoanhThu;
        private Label lblKhachMoi;
        private Label lblSanTrong;
        private DataGridView dgvLich;
        private DateTimePicker dtpNgay;
        private Panel panel1;
    }
}
