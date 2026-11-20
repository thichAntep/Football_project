using System;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySanBong.DTO;

namespace QuanLySanBong.DAL
{
    public class HoaDonDAL
    {
        // Danh sách hóa đơn (có lọc) - hiển thị lên dgvHoaDon
        public DataTable TimHoaDon(DateTime tu, DateTime den, string trangThai, string tuKhoa)
        {
            string query = @"
                SELECT h.MaHD, s.TenSan, k.TenKH, h.GioVao, h.GioRa,
                       ISNULL(h.TongTien, 0) AS TongTien, h.TrangThai
                FROM HoaDon h
                LEFT JOIN SanBong s   ON h.MaSan = s.MaSan
                LEFT JOIN KhachHang k ON h.MaKH  = k.MaKH
                WHERE h.GioVao >= @Tu AND h.GioVao < @Den
                  AND (@TrangThai = N'' OR h.TrangThai = @TrangThai)
                  AND (s.TenSan LIKE @TuKhoa OR k.TenKH LIKE @TuKhoa
                       OR CAST(h.MaHD AS nvarchar(20)) LIKE @TuKhoa)
                ORDER BY h.GioVao DESC";

            return DataProvider.Instance.ExecuteQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Tu", tu.Date),
                new SqlParameter("@Den", den.Date.AddDays(1)),
                new SqlParameter("@TrangThai", trangThai ?? ""),
                new SqlParameter("@TuKhoa", "%" + (tuKhoa ?? "") + "%")
            });
        }

        // Chi tiết dịch vụ của 1 hóa đơn - hiển thị lên dgvChiTiet
        public DataTable GetChiTietDichVu(int maHD)
        {
            string query = @"
                SELECT d.TenDV, d.DVT, c.SoLuong, c.DonGia, c.ThanhTien
                FROM ChiTietDichVu c
                JOIN DichVu d ON c.MaDV = d.MaDV
                WHERE c.MaHD = @MaHD";

            return DataProvider.Instance.ExecuteQuery(query,
                new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
        }

        // Lấy 1 hóa đơn theo mã
        public HoaDonDTO GetById(int maHD)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM HoaDon WHERE MaHD = @MaHD",
                new SqlParameter[] { new SqlParameter("@MaHD", maHD) });

            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];

            return new HoaDonDTO
            {
                MaHD = (int)r["MaHD"],
                MaSan = r["MaSan"] == DBNull.Value ? (int?)null : (int)r["MaSan"],
                MaKH = r["MaKH"] == DBNull.Value ? (int?)null : (int)r["MaKH"],
                MaTK = r["MaTK"] == DBNull.Value ? (int?)null : (int)r["MaTK"],
                GioVao = (DateTime)r["GioVao"],
                GioRa = r["GioRa"] == DBNull.Value ? (DateTime?)null : (DateTime)r["GioRa"],
                TienSan = r["TienSan"] == DBNull.Value ? 0 : (decimal)r["TienSan"],
                TienDichVu = r["TienDichVu"] == DBNull.Value ? 0 : (decimal)r["TienDichVu"],
                TongTien = r["TongTien"] == DBNull.Value ? 0 : (decimal)r["TongTien"],
                TrangThai = r["TrangThai"] == DBNull.Value ? "" : r["TrangThai"].ToString()
            };
        }

        // Đơn giá giờ của sân (SanBong -> LoaiSan)
        public decimal GetDonGiaGio(int maSan)
        {
            object v = DataProvider.Instance.ExecuteScalar(@"
                SELECT l.DonGiaGio FROM SanBong s
                JOIN LoaiSan l ON s.MaLoai = l.MaLoai
                WHERE s.MaSan = @MaSan",
                new SqlParameter[] { new SqlParameter("@MaSan", maSan) });

            return v == null || v == DBNull.Value ? 0 : Convert.ToDecimal(v);
        }

        public decimal TongTienDichVu(int maHD)
        {
            object v = DataProvider.Instance.ExecuteScalar(
                "SELECT ISNULL(SUM(ThanhTien), 0) FROM ChiTietDichVu WHERE MaHD = @MaHD",
                new SqlParameter[] { new SqlParameter("@MaHD", maHD) });

            return Convert.ToDecimal(v);
        }

        public int CapNhatThanhToan(int maHD, DateTime gioRa, decimal tienSan,
                                    decimal tienDichVu, decimal tongTien, string trangThai)
        {
            string query = @"
                UPDATE HoaDon
                SET GioRa = @GioRa, TienSan = @TienSan, TienDichVu = @TienDV,
                    TongTien = @TongTien, TrangThai = @TrangThai
                WHERE MaHD = @MaHD";

            return DataProvider.Instance.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@GioRa", gioRa),
                new SqlParameter("@TienSan", tienSan),
                new SqlParameter("@TienDV", tienDichVu),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaHD", maHD)
            });
        }
    }
}