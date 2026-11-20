using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanBong.DTO
{
    public class ChiTietDichVuDTO
    {
        public int MaHD { get; set; }
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }

    public class SanDangDaDTO
    {
        public int MaSan { get; set; }
        public string TenSan { get; set; }
        public int? MaHD { get; set; }

        public override string ToString() => TenSan;
    }
}