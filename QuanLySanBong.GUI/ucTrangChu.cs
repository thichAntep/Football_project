using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using QuanLySanBong.BUS;
namespace QuanLySanBong.GUI

{
    public partial class ucTrangChu : UserControl
    {
        public ucTrangChu()
        {
            InitializeComponent();
            this.Load += ucTrangChu_Load;
            CauHinhLuoi();
            dtpNgay.ValueChanged += (s, e) => LoadLichSan();
            LoadLichSan();
        }
        private const int SO_KHUNG_HIEN = 5;   // hôm nay: hiện tối đa 3 khung gần nhất
        private Timer timerLich;
        private void lblNgay_Click(object sender, EventArgs e)
        {

        }
        private void btnThemSan_Click(object sender, EventArgs e)
        {
            using (FormThemSan f = new FormThemSan())
            {
                f.ShowDialog();
            }

            // code chạy sau khi FormB đóng (ví dụ load lại dữ liệu)
        }

        private void tnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadKhachHangDangCho();
            LoadSoSanTrong();

        }
        private void LoadSoSanTrong()
        {
            int soSan = new SanBongBUS().SoSanBongTrong();
            lblSanTrong.Text = $"Sân Trống :{soSan}";
        }
        private void LoadThongKe() //Số Sân Đặt Hôm Nay
        {
            int soSan = new PhieuDatSanBUS().LaySoSanDaDatHomNay();
            lblSanDaDat.Text = $"Số Sân Đã Đặt Hôm Nay : {soSan}";
        }
        private void LoadKhachHangDangCho()
        {
            int khachCho = new KhachHangBUS().LaySoKhachHangCho();
            lblKhachMoi.Text = $"Khách Đang Chờ : {khachCho}";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CauHinhLuoi()
        {
            dgvLich.AllowUserToAddRows = false;
            dgvLich.ReadOnly = true;
            dgvLich.RowHeadersVisible = false;
            dgvLich.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvLich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLich.RowTemplate.Height = 70;
            dgvLich.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLich.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLich.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLich.EnableHeadersVisualStyles = false;

            // tự làm mới mỗi phút để trạng thái "Đang sử dụng" cập nhật theo giờ
            timerLich = new Timer { Interval = 60000 };
            timerLich.Tick += (s, e) => LoadLichSan();
            timerLich.Start();
        }

        public void LoadLichSan()
        {
            DataTable dt = new LichSanBUS().GetLichTheoNgay(dtpNgay.Value)/* gọi BUS: GetLichTheoNgay(dtpNgay.Value) */;
            DateTime ngay = dtpNgay.Value.Date;
            bool laHomNay = ngay == DateTime.Today;
            TimeSpan now = DateTime.Now.TimeOfDay;

            // danh sách khung giờ (cột)
            var khungGio = dt.AsEnumerable()
                .Select(r => new
                {
                    Ma = r.Field<int>("MaKhungGio"),
                    Bd = r.Field<TimeSpan>("GioBatDau"),
                    Kt = r.Field<TimeSpan>("GioKetThuc")
                })
                .Distinct()
                .OrderBy(x => x.Bd)
                .ToList();

            // hôm nay: bỏ khung đã qua, chỉ lấy vài khung gần nhất
            if (laHomNay)
                khungGio = khungGio.Where(x => x.Kt > now).Take(SO_KHUNG_HIEN).ToList();

            dgvLich.Rows.Clear();
            dgvLich.Columns.Clear();
            dgvLich.Columns.Add("colSan", "Sân");
            foreach (var kg in khungGio)
            {
                int i = dgvLich.Columns.Add("kg" + kg.Ma,
                    kg.Bd.ToString(@"hh\:mm") + " - " + kg.Kt.ToString(@"hh\:mm"));
                dgvLich.Columns[i].Tag = kg.Ma;
            }

            // khung giờ gần nhất (đang diễn ra hoặc sắp tới) → tô đậm tiêu đề cột
            if (laHomNay && khungGio.Count > 0)
                dgvLich.Columns[1].HeaderCell.Style.BackColor = Color.Gold;

            // tra nhanh theo (MaSan, MaKhungGio)
            var tra = dt.AsEnumerable().ToDictionary(
                r => (r.Field<int>("MaSan"), r.Field<int>("MaKhungGio")));

            var dsSan = dt.AsEnumerable()
                .GroupBy(r => r.Field<int>("MaSan"))
                .OrderBy(g => g.Key);

            foreach (var san in dsSan)
            {
                int idx = dgvLich.Rows.Add();
                var row = dgvLich.Rows[idx];
                row.Cells[0].Value = san.First().Field<string>("TenSan");
                row.Cells[0].Style.Font = new Font(dgvLich.Font, FontStyle.Bold);

                for (int c = 1; c < dgvLich.Columns.Count; c++)
                {
                    int maKG = (int)dgvLich.Columns[c].Tag;
                    var cell = row.Cells[c];

                    if (!tra.TryGetValue((san.Key, maKG), out var r))
                    {
                        cell.Value = "—";               // sân này không có khung giờ đó
                        cell.Style.BackColor = Color.WhiteSmoke;
                        continue;
                    }

                    TimeSpan bd = r.Field<TimeSpan>("GioBatDau");
                    TimeSpan kt = r.Field<TimeSpan>("GioKetThuc");
                    bool coPhieu = !r.IsNull("TrangThai");
                    bool dangDienRa = laHomNay && now >= bd && now < kt;
                    bool daQua = (laHomNay && now >= kt) || ngay < DateTime.Today;

                    if (!coPhieu)
                    {
                        cell.Value = daQua ? "—" : "Trống";
                        cell.Style.BackColor = daQua ? Color.Gainsboro : Color.Honeydew;
                        cell.Style.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        string ten = r.Field<string>("TenKH");
                        string sdt = r.Field<string>("SDT");

                        if (daQua)
                        {
                            cell.Value = $"{ten}\n{sdt}\nĐã kết thúc";
                            cell.Style.BackColor = Color.Gainsboro;
                        }
                        else if (dangDienRa)
                        {
                            cell.Value = $"{ten}\n{sdt}\nĐang sử dụng";
                            cell.Style.BackColor = Color.LightSkyBlue;
                        }
                        else
                        {
                            cell.Value = $"{ten}\n{sdt}\nĐã đặt";
                            cell.Style.BackColor = Color.PeachPuff;
                        }
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
