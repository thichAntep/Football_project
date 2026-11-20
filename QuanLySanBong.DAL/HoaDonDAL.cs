using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySanBong.DTO;

namespace QuanLySanBong.DAL
{
    public class HoaDonDAL
    {
        public List<HoaDonDTO> LayDSHoaDonChuaThanhToan()
        {
            var list = new List<HoaDonDTO>();
            string query = @"
                SELECT 
                    h.MaHD, h.MaSan, s.TenSan,
                    h.MaKH, ISNULL(k.TenKH, N'Khách vãng lai') AS TenKH, 
                    ISNULL(k.SoDienThoai, '') AS SoDienThoai,
                    h.GioVao, h.GioRa,
                    ISNULL(ls.DonGiaGio , 0) AS DonGiaGio ,
                    ISNULL(h.TienSan, 0) AS TienSan,
                    ISNULL(h.TienDichVu, 0) AS TienDichVu,
                    ISNULL(h.TongTien, 0) AS TongTien,
                    h.TrangThai
                FROM HoaDon h
                JOIN SanBong s ON h.MaSan = s.MaSan
                LEFT JOIN LoaiSan ls ON s.MaLoai = ls.MaLoai
                LEFT JOIN KhachHang k ON h.MaKH = k.MaKH
                WHERE h.TrangThai = N'Chưa thanh toán'
                ORDER BY h.GioVao DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new HoaDonDTO
                {
                    MaHD = Convert.ToInt32(r["MaHD"]),
                    MaSan = Convert.ToInt32(r["MaSan"]),
                    TenSan = r["TenSan"].ToString(),
                    MaKH = r["MaKH"] != DBNull.Value ? Convert.ToInt32(r["MaKH"]) : (int?)null,
                    TenKH = r["TenKH"].ToString(),
                    SoDienThoai = r["SoDienThoai"].ToString(),
                    GioVao = Convert.ToDateTime(r["GioVao"]),
                    GioRa = r["GioRa"] != DBNull.Value ? Convert.ToDateTime(r["GioRa"]) : (DateTime?)null,
                    DonGiaGio = Convert.ToDecimal(r["DonGiaGio "]),
                    TienSan = Convert.ToDecimal(r["TienSan"]),
                    TienDichVu = Convert.ToDecimal(r["TienDichVu"]),
                    TongTien = Convert.ToDecimal(r["TongTien"]),
                    TrangThai = r["TrangThai"].ToString()
                });
            }
            return list;
        }

        public List<ChiTietDichVuDTO> LayChiTietDichVu(int maHD)
        {
            var list = new List<ChiTietDichVuDTO>();
            string query = @"
                SELECT ct.MaHD, ct.MaDV, dv.TenDV, ct.SoLuong, ct.DonGia
                FROM ChiTietDichVu ct
                JOIN DichVu dv ON ct.MaDV = dv.MaDV
                WHERE ct.MaHD = @MaHD";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChiTietDichVuDTO
                {
                    MaHD = Convert.ToInt32(r["MaHD"]),
                    MaDV = Convert.ToInt32(r["MaDV"]),
                    TenDV = r["TenDV"].ToString(),
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    DonGia = Convert.ToDecimal(r["DonGia"])
                });
            }
            return list;
        }

        public bool ThanhToanHoaDon(int maHD, int maSan, DateTime gioRa, decimal tienSan, decimal tienDV, decimal tongTien)
        {
            string query = @"
                UPDATE HoaDon 
                SET GioRa = @GioRa,
                    TienSan = @TienSan,
                    TienDichVu = @TienDichVu,
                    TongTien = @TongTien,
                    TrangThai = N'Đã thanh toán'
                WHERE MaHD = @MaHD;

                UPDATE SanBong SET TrangThai = N'Trống' WHERE MaSan = @MaSan;";

            SqlParameter[] p = {
                new SqlParameter("@GioRa", gioRa),
                new SqlParameter("@TienSan", tienSan),
                new SqlParameter("@TienDichVu", tienDV),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@MaSan", maSan)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, p) > 0;
        }
    }
}