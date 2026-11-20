using System;
using System.Data;

namespace QuanLySanBong.DTO
{
    public class BaoCaoHoaDonDTO
    {
        public int MaHD { get; set; }
        public string TenSan { get; set; }
        public string TenKH { get; set; }
        public string NhanVienLap { get; set; }
        public DateTime? GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public decimal TienSan { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }

        public BaoCaoHoaDonDTO() { }

        public BaoCaoHoaDonDTO(DataRow row)
        {
            this.MaHD = Convert.ToInt32(row["MaHD"]);
            this.TenSan = row["TenSan"] != DBNull.Value ? row["TenSan"].ToString() : "Chưa xác định";
            this.TenKH = row["TenKH"] != DBNull.Value ? row["TenKH"].ToString() : "Khách vãng lai";
            this.NhanVienLap = row["NhanVien"] != DBNull.Value ? row["NhanVien"].ToString() : "";

            if (row["GioVao"] != DBNull.Value)
                this.GioVao = Convert.ToDateTime(row["GioVao"]);
            if (row["GioRa"] != DBNull.Value)
                this.GioRa = Convert.ToDateTime(row["GioRa"]);

            this.TienSan = row["TienSan"] != DBNull.Value ? Convert.ToDecimal(row["TienSan"]) : 0;
            this.TienDichVu = row["TienDichVu"] != DBNull.Value ? Convert.ToDecimal(row["TienDichVu"]) : 0;
            this.TongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0;
            this.TrangThai = row["TrangThai"] != DBNull.Value ? row["TrangThai"].ToString() : "";
        }
    }
}