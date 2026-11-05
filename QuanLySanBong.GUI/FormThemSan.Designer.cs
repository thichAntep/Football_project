namespace QuanLySanBong.GUI
{
    partial class FormThemSan
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
            btnThemSan = new Button();
            label1 = new Label();
            label2 = new Label();
            grpThemSan = new GroupBox();
            btnHuy = new Button();
            btnLuuThem = new Button();
            nudGiaTien = new NumericUpDown();
            lblGiaTien = new Label();
            clbKhungGio = new CheckedListBox();
            lblKhungGio = new Label();
            cboLoaiSan = new ComboBox();
            lblLoaiSan = new Label();
            txtTenSan = new TextBox();
            lblTenSan = new Label();
            grpXoaSan = new GroupBox();
            btnHuyXoa = new Button();
            btnXacNhanXoar = new Button();
            lblGiaTienXoa = new Label();
            lblThongTinGia = new Label();
            lblLoaiSanXoa = new Label();
            lblThongTinLoai = new Label();
            cboXoaKhungGio = new ComboBox();
            lblChonKhungGio = new Label();
            cboXoaSan = new ComboBox();
            lblChonSan = new Label();
            btnXoaSan = new Button();
            dgvDanhSachSan = new DataGridView();
            dgvDanhSachXoa = new DataGridView();
            grpThemSan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGiaTien).BeginInit();
            grpXoaSan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachXoa).BeginInit();
            SuspendLayout();
            // 
            // btnThemSan
            // 
            btnThemSan.Location = new Point(66, 60);
            btnThemSan.Name = "btnThemSan";
            btnThemSan.Size = new Size(150, 46);
            btnThemSan.TabIndex = 0;
            btnThemSan.Text = "Thêm Sân";
            btnThemSan.TextAlign = ContentAlignment.BottomCenter;
            btnThemSan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 32);
            label1.TabIndex = 3;
            label1.Text = "Quản Lý Sân";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 338);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(0, 32);
            label2.TabIndex = 5;
            // 
            // grpThemSan
            // 
            grpThemSan.Controls.Add(btnHuy);
            grpThemSan.Controls.Add(btnLuuThem);
            grpThemSan.Controls.Add(nudGiaTien);
            grpThemSan.Controls.Add(lblGiaTien);
            grpThemSan.Controls.Add(clbKhungGio);
            grpThemSan.Controls.Add(lblKhungGio);
            grpThemSan.Controls.Add(cboLoaiSan);
            grpThemSan.Controls.Add(lblLoaiSan);
            grpThemSan.Controls.Add(txtTenSan);
            grpThemSan.Controls.Add(lblTenSan);
            grpThemSan.Location = new Point(1110, 12);
            grpThemSan.Name = "grpThemSan";
            grpThemSan.Size = new Size(896, 409);
            grpThemSan.TabIndex = 7;
            grpThemSan.TabStop = false;
            grpThemSan.Text = "Thông Tin Sân Mới";
            grpThemSan.Visible = false;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(308, 345);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(150, 46);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuuThem
            // 
            btnLuuThem.Location = new Point(50, 345);
            btnLuuThem.Name = "btnLuuThem";
            btnLuuThem.Size = new Size(150, 46);
            btnLuuThem.TabIndex = 8;
            btnLuuThem.Text = "Lưu Sân";
            btnLuuThem.UseVisualStyleBackColor = true;
            // 
            // nudGiaTien
            // 
            nudGiaTien.Location = new Point(633, 77);
            nudGiaTien.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudGiaTien.Name = "nudGiaTien";
            nudGiaTien.Size = new Size(240, 39);
            nudGiaTien.TabIndex = 7;
            nudGiaTien.ThousandsSeparator = true;
            // 
            // lblGiaTien
            // 
            lblGiaTien.AllowDrop = true;
            lblGiaTien.AutoSize = true;
            lblGiaTien.Location = new Point(480, 77);
            lblGiaTien.Name = "lblGiaTien";
            lblGiaTien.Size = new Size(101, 32);
            lblGiaTien.TabIndex = 6;
            lblGiaTien.Text = "Giá Tiền";
            // 
            // clbKhungGio
            // 
            clbKhungGio.FormattingEnabled = true;
            clbKhungGio.ImeMode = ImeMode.Off;
            clbKhungGio.Location = new Point(633, 168);
            clbKhungGio.Name = "clbKhungGio";
            clbKhungGio.Size = new Size(240, 184);
            clbKhungGio.TabIndex = 5;
            // 
            // lblKhungGio
            // 
            lblKhungGio.AutoSize = true;
            lblKhungGio.Location = new Point(480, 168);
            lblKhungGio.Name = "lblKhungGio";
            lblKhungGio.Size = new Size(127, 32);
            lblKhungGio.TabIndex = 4;
            lblKhungGio.Text = "Khung Giờ";
            // 
            // cboLoaiSan
            // 
            cboLoaiSan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSan.FormattingEnabled = true;
            cboLoaiSan.Location = new Point(141, 160);
            cboLoaiSan.Name = "cboLoaiSan";
            cboLoaiSan.Size = new Size(277, 40);
            cboLoaiSan.TabIndex = 3;
            // 
            // lblLoaiSan
            // 
            lblLoaiSan.AutoSize = true;
            lblLoaiSan.Location = new Point(21, 160);
            lblLoaiSan.Name = "lblLoaiSan";
            lblLoaiSan.Size = new Size(103, 32);
            lblLoaiSan.TabIndex = 2;
            lblLoaiSan.Text = "Loại Sân";
            // 
            // txtTenSan
            // 
            txtTenSan.Location = new Point(141, 70);
            txtTenSan.Name = "txtTenSan";
            txtTenSan.Size = new Size(277, 39);
            txtTenSan.TabIndex = 1;
            // 
            // lblTenSan
            // 
            lblTenSan.AutoSize = true;
            lblTenSan.Location = new Point(21, 70);
            lblTenSan.Name = "lblTenSan";
            lblTenSan.Size = new Size(98, 32);
            lblTenSan.TabIndex = 0;
            lblTenSan.Text = "Tên Sân";
            // 
            // grpXoaSan
            // 
            grpXoaSan.Controls.Add(btnHuyXoa);
            grpXoaSan.Controls.Add(btnXacNhanXoar);
            grpXoaSan.Controls.Add(lblGiaTienXoa);
            grpXoaSan.Controls.Add(lblThongTinGia);
            grpXoaSan.Controls.Add(lblLoaiSanXoa);
            grpXoaSan.Controls.Add(lblThongTinLoai);
            grpXoaSan.Controls.Add(cboXoaKhungGio);
            grpXoaSan.Controls.Add(lblChonKhungGio);
            grpXoaSan.Controls.Add(cboXoaSan);
            grpXoaSan.Controls.Add(lblChonSan);
            grpXoaSan.Location = new Point(1110, 444);
            grpXoaSan.Name = "grpXoaSan";
            grpXoaSan.Size = new Size(896, 452);
            grpXoaSan.TabIndex = 8;
            grpXoaSan.TabStop = false;
            grpXoaSan.Text = "Thông Tin Sân Cần Xóa";
            grpXoaSan.Visible = false;
            // 
            // btnHuyXoa
            // 
            btnHuyXoa.Location = new Point(425, 352);
            btnHuyXoa.Name = "btnHuyXoa";
            btnHuyXoa.Size = new Size(150, 46);
            btnHuyXoa.TabIndex = 9;
            btnHuyXoa.Text = "Hủy";
            btnHuyXoa.UseVisualStyleBackColor = true;
            // 
            // btnXacNhanXoar
            // 
            btnXacNhanXoar.Location = new Point(87, 352);
            btnXacNhanXoar.Name = "btnXacNhanXoar";
            btnXacNhanXoar.Size = new Size(150, 46);
            btnXacNhanXoar.TabIndex = 8;
            btnXacNhanXoar.Text = "Xóa Khung Giờ";
            btnXacNhanXoar.UseVisualStyleBackColor = true;
            btnXacNhanXoar.Click += btnXacNhanXoar_Click;
            // 
            // lblGiaTienXoa
            // 
            lblGiaTienXoa.AutoSize = true;
            lblGiaTienXoa.Location = new Point(219, 263);
            lblGiaTienXoa.Name = "lblGiaTienXoa";
            lblGiaTienXoa.Size = new Size(134, 32);
            lblGiaTienXoa.TabIndex = 7;
            lblGiaTienXoa.Text = "GiaTienXoa";
            // 
            // lblThongTinGia
            // 
            lblThongTinGia.AutoSize = true;
            lblThongTinGia.Location = new Point(38, 263);
            lblThongTinGia.Name = "lblThongTinGia";
            lblThongTinGia.Size = new Size(101, 32);
            lblThongTinGia.TabIndex = 6;
            lblThongTinGia.Text = "Giá Tiền";
            // 
            // lblLoaiSanXoa
            // 
            lblLoaiSanXoa.AutoSize = true;
            lblLoaiSanXoa.Location = new Point(219, 197);
            lblLoaiSanXoa.Name = "lblLoaiSanXoa";
            lblLoaiSanXoa.Size = new Size(162, 32);
            lblLoaiSanXoa.TabIndex = 5;
            lblLoaiSanXoa.Text = "lblLoaiSanXoa";
            // 
            // lblThongTinLoai
            // 
            lblThongTinLoai.AutoSize = true;
            lblThongTinLoai.Location = new Point(36, 197);
            lblThongTinLoai.Name = "lblThongTinLoai";
            lblThongTinLoai.Size = new Size(103, 32);
            lblThongTinLoai.TabIndex = 4;
            lblThongTinLoai.Text = "Loại Sân";
            // 
            // cboXoaKhungGio
            // 
            cboXoaKhungGio.FormattingEnabled = true;
            cboXoaKhungGio.Location = new Point(208, 120);
            cboXoaKhungGio.Name = "cboXoaKhungGio";
            cboXoaKhungGio.Size = new Size(242, 40);
            cboXoaKhungGio.TabIndex = 3;
            // 
            // lblChonKhungGio
            // 
            lblChonKhungGio.AutoSize = true;
            lblChonKhungGio.Location = new Point(25, 128);
            lblChonKhungGio.Name = "lblChonKhungGio";
            lblChonKhungGio.Size = new Size(127, 32);
            lblChonKhungGio.TabIndex = 2;
            lblChonKhungGio.Text = "Khung Giờ";
            // 
            // cboXoaSan
            // 
            cboXoaSan.FormattingEnabled = true;
            cboXoaSan.Location = new Point(208, 49);
            cboXoaSan.Name = "cboXoaSan";
            cboXoaSan.Size = new Size(242, 40);
            cboXoaSan.TabIndex = 1;
            // 
            // lblChonSan
            // 
            lblChonSan.AutoSize = true;
            lblChonSan.Location = new Point(22, 52);
            lblChonSan.Name = "lblChonSan";
            lblChonSan.Size = new Size(117, 32);
            lblChonSan.TabIndex = 0;
            lblChonSan.Text = "Chọn Sân";
            // 
            // btnXoaSan
            // 
            btnXoaSan.Location = new Point(66, 353);
            btnXoaSan.Name = "btnXoaSan";
            btnXoaSan.RightToLeft = RightToLeft.Yes;
            btnXoaSan.Size = new Size(150, 46);
            btnXoaSan.TabIndex = 1;
            btnXoaSan.Text = "Xóa Sân";
            btnXoaSan.UseVisualStyleBackColor = true;
            btnXoaSan.Click += btnXoaSan_Click;
            // 
            // dgvDanhSachSan
            // 
            dgvDanhSachSan.AllowUserToAddRows = false;
            dgvDanhSachSan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSan.Location = new Point(66, 122);
            dgvDanhSachSan.MultiSelect = false;
            dgvDanhSachSan.Name = "dgvDanhSachSan";
            dgvDanhSachSan.ReadOnly = true;
            dgvDanhSachSan.RowHeadersWidth = 82;
            dgvDanhSachSan.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDanhSachSan.Size = new Size(969, 193);
            dgvDanhSachSan.TabIndex = 4;
            // 
            // dgvDanhSachXoa
            // 
            dgvDanhSachXoa.AllowUserToAddRows = false;
            dgvDanhSachXoa.AllowUserToResizeColumns = false;
            dgvDanhSachXoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachXoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachXoa.Location = new Point(66, 424);
            dgvDanhSachXoa.Name = "dgvDanhSachXoa";
            dgvDanhSachXoa.ReadOnly = true;
            dgvDanhSachXoa.RowHeadersWidth = 82;
            dgvDanhSachXoa.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDanhSachXoa.Size = new Size(969, 289);
            dgvDanhSachXoa.TabIndex = 4;
            // 
            // FormThemSan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2047, 968);
            Controls.Add(grpXoaSan);
            Controls.Add(grpThemSan);
            Controls.Add(label2);
            Controls.Add(dgvDanhSachXoa);
            Controls.Add(dgvDanhSachSan);
            Controls.Add(label1);
            Controls.Add(btnXoaSan);
            Controls.Add(btnThemSan);
            Name = "FormThemSan";
            Text = "ThemSan";
            grpThemSan.ResumeLayout(false);
            grpThemSan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGiaTien).EndInit();
            grpXoaSan.ResumeLayout(false);
            grpXoaSan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachXoa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThemSan;
        private Label label1;
        private Label label2;
        private GroupBox grpThemSan;
        private Label lblLoaiSan;
        private TextBox txtTenSan;
        private Label lblTenSan;
        private CheckedListBox clbKhungGio;
        private Label lblKhungGio;
        private ComboBox cboLoaiSan;
        private NumericUpDown nudGiaTien;
        private Label lblGiaTien;
        private Button btnHuy;
        private Button btnLuuThem;
        private GroupBox grpXoaSan;
        private Label lblLoaiSanXoa;
        private Label lblThongTinLoai;
        private ComboBox cboXoaKhungGio;
        private Label lblChonKhungGio;
        private ComboBox cboXoaSan;
        private Label lblChonSan;
        private Button btnHuyXoa;
        private Button btnXacNhanXoar;
        private Label lblGiaTienXoa;
        private Label lblThongTinGia;
        private Button btnXoaSan;
        private DataGridView dgvDanhSachSan;
        private DataGridView dgvDanhSachXoa;
    }
}