using System;
using System.Collections.Generic;

namespace QuanLySanBong.DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int MaSan { get; set; }
        public string TenSan { get; set; }
        public int? MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public decimal DonGiaGio { get; set; }  // Giá sân / giờ
        public decimal TienSan { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TienCoc { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }

        // Danh sách các dịch vụ kèm theo của hóa đơn này
        public List<ChiTietDichVuDTO> DanhSachDichVu { get; set; } = new List<ChiTietDichVuDTO>();

        // Tính thời gian đá thực tế (tính theo giờ)
        public double SoGioDa
        {
            get
            {
                DateTime ketThuc = GioRa ?? DateTime.Now;
                double tongPhut = (ketThuc - GioVao).TotalMinutes;
                if (tongPhut <= 0) return 1.0; // Tối thiểu tính 1h hoặc làm tròn
                return Math.Round(tongPhut / 60.0, 2);
            }
        }
    }
}