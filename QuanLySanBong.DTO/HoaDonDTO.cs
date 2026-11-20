using System;

namespace QuanLySanBong.DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int? MaSan { get; set; }
        public int? MaKH { get; set; }
        public int? MaTK { get; set; }
        public DateTime GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public decimal TienSan { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}