using System;

namespace QuanLySanBong.DTO
{
    public class PhieuDatSanDTO
    {
        public int MaPhieu { get; set; }
        public int MaKH { get; set; }
        public int MaSan { get; set; }
        public int MaTK { get; set; }
        public DateTime NgayDat { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal DonGia { get; set; }
        public decimal TienCoc { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        // Dùng khi xem chi tiết phiếu
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
    }
}