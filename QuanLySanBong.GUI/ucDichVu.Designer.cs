namespace QuanLySanBong.GUI
{
    partial class ucDichVu
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
            tblLeft = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtTimKiem = new TextBox();
            cboLoaiDV = new ComboBox();
            fplDichVu = new FlowLayoutPanel();
            cboSanDangDa = new ComboBox();
            dgvPhieu = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnThanhToan = new Button();
            btnInHoaDon = new Button();
            tblMain.SuspendLayout();
            tblLeft.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieu).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblMain.Controls.Add(tblLeft, 0, 0);
            tblMain.Controls.Add(tableLayoutPanel1, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1196, 729);
            tblMain.TabIndex = 0;
            // 
            // tblLeft
            // 
            tblLeft.ColumnCount = 1;
            tblLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblLeft.Controls.Add(label1, 0, 0);
            tblLeft.Controls.Add(tableLayoutPanel2, 0, 1);
            tblLeft.Controls.Add(fplDichVu, 0, 2);
            tblLeft.Dock = DockStyle.Fill;
            tblLeft.Location = new Point(3, 3);
            tblLeft.Name = "tblLeft";
            tblLeft.RowCount = 3;
            tblLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tblLeft.Size = new Size(831, 723);
            tblLeft.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(cboSanDangDa, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvPhieu, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(840, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(353, 723);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(332, 20);
            label1.Name = "label1";
            label1.Size = new Size(166, 32);
            label1.TabIndex = 0;
            label1.Text = "Dịch Vụ Thêm";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(73, 20);
            label2.Name = "label2";
            label2.Size = new Size(206, 32);
            label2.TabIndex = 0;
            label2.Text = "Phiếu Thanh Toán";
            label2.Click += label2_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.Controls.Add(txtTimKiem, 0, 0);
            tableLayoutPanel2.Controls.Add(cboLoaiDV, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(825, 102);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.None;
            txtTimKiem.Location = new Point(58, 31);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(420, 39);
            txtTimKiem.TabIndex = 0;
            // 
            // cboLoaiDV
            // 
            cboLoaiDV.Anchor = AnchorStyles.None;
            cboLoaiDV.FormattingEnabled = true;
            cboLoaiDV.Location = new Point(559, 31);
            cboLoaiDV.Name = "cboLoaiDV";
            cboLoaiDV.Size = new Size(242, 40);
            cboLoaiDV.TabIndex = 1;
            // 
            // fplDichVu
            // 
            fplDichVu.Dock = DockStyle.Fill;
            fplDichVu.Location = new Point(3, 183);
            fplDichVu.Name = "fplDichVu";
            fplDichVu.Size = new Size(825, 537);
            fplDichVu.TabIndex = 2;
            // 
            // cboSanDangDa
            // 
            cboSanDangDa.Anchor = AnchorStyles.None;
            cboSanDangDa.FormattingEnabled = true;
            cboSanDangDa.Location = new Point(55, 106);
            cboSanDangDa.Name = "cboSanDangDa";
            cboSanDangDa.Size = new Size(242, 40);
            cboSanDangDa.TabIndex = 1;
            // 
            // dgvPhieu
            // 
            dgvPhieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieu.Dock = DockStyle.Fill;
            dgvPhieu.Location = new Point(3, 183);
            dgvPhieu.Name = "dgvPhieu";
            dgvPhieu.RowHeadersWidth = 82;
            dgvPhieu.Size = new Size(347, 427);
            dgvPhieu.TabIndex = 2;
            dgvPhieu.CellContentClick += dgvPhieu_CellContentClick;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(btnThanhToan, 0, 0);
            tableLayoutPanel3.Controls.Add(btnInHoaDon, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 616);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(347, 104);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Anchor = AnchorStyles.None;
            btnThanhToan.Location = new Point(11, 29);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(150, 46);
            btnThanhToan.TabIndex = 0;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Anchor = AnchorStyles.None;
            btnInHoaDon.Location = new Point(185, 29);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.RightToLeft = RightToLeft.Yes;
            btnInHoaDon.Size = new Size(150, 46);
            btnInHoaDon.TabIndex = 1;
            btnInHoaDon.Text = "In Hóa Đơn";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // ucDichVu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblMain);
            Name = "ucDichVu";
            Size = new Size(1196, 729);
            tblMain.ResumeLayout(false);
            tblLeft.ResumeLayout(false);
            tblLeft.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieu).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblLeft;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txtTimKiem;
        private ComboBox cboLoaiDV;
        private FlowLayoutPanel fplDichVu;
        private ComboBox cboSanDangDa;
        private DataGridView dgvPhieu;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnThanhToan;
        private Button btnInHoaDon;
    }
}
