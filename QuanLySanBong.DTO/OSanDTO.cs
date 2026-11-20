using System;

namespace QuanLySanBong.DTO
{
    public enum TrangThaiO { Trong, DaDat, DangDa, BaoTri }

    /// <summary>Một ô trên sơ đồ = 1 sân x 1 khung giờ trong 1 ngày.</summary>
    public class OSanDTO
    {
        public int MaSan { get; set; }
        public string TenSan { get; set; }
        public int MaKhungGio { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal DonGia { get; set; }
        public bool SanBaoTri { get; set; }
        public int? MaPhieu { get; set; }          // null = chưa có phiếu đặt
        public string TenKhachDat { get; set; }
        public TrangThaiO TrangThai { get; set; }  // BUS tính

        public string TenKhungGio
        {
            get { return GioBatDau.ToString(@"hh\:mm") + " - " + GioKetThuc.ToString(@"hh\:mm"); }
        }
    }
}