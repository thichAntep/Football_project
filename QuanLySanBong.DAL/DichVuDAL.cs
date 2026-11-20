using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySanBong.DTO;

namespace QuanLySanBong.DAL
{
    public class DichVuDAL
    {
        // 1. Lấy danh sách sân đang hoạt động
        public List<SanDangDaDTO> LayDSSanDangDa()
        {
            var list = new List<SanDangDaDTO>();
            string query = @"
                SELECT s.MaSan, s.TenSan, h.MaHD 
                FROM SanBong s
                LEFT JOIN HoaDon h ON s.MaSan = h.MaSan AND h.TrangThai = N'Chưa thanh toán'
                WHERE s.TrangThai IN (N'Đang sử dụng', N'Đang đá', N'Có người') OR h.MaHD IS NOT NULL";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count == 0)
            {
                // Dự phòng nếu chưa có sân nào set trạng thái thì lấy tất cả
                dt = DataProvider.Instance.ExecuteQuery("SELECT MaSan, TenSan, NULL AS MaHD FROM SanBong");
            }

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new SanDangDaDTO
                {
                    MaSan = Convert.ToInt32(r["MaSan"]),
                    TenSan = r["TenSan"].ToString(),
                    MaHD = r["MaHD"] != DBNull.Value ? Convert.ToInt32(r["MaHD"]) : (int?)null
                });
            }
            return list;
        }

        // 2. Lấy danh sách Đơn Vị Tính (Loại) từ bảng DichVu
        public List<string> LayDSDonViTinh()
        {
            var list = new List<string>();
            string query = "SELECT DISTINCT DVT FROM DichVu WHERE DVT IS NOT NULL AND DVT <> ''";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow r in dt.Rows)
                list.Add(r["DVT"].ToString());
            return list;
        }

        // 3. Lấy tất cả dịch vụ
        public List<DichVuDTO> LayTatCaDichVu()
        {
            var list = new List<DichVuDTO>();
            string query = "SELECT MaDV, TenDV, DVT, DonGia, SoLuongTon FROM DichVu";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new DichVuDTO
                {
                    MaDV = Convert.ToInt32(r["MaDV"]),
                    TenDV = r["TenDV"].ToString(),
                    DVT = r["DVT"] != DBNull.Value ? r["DVT"].ToString() : "",
                    DonGia = Convert.ToDecimal(r["DonGia"]),
                    SoLuongTon = r["SoLuongTon"] != DBNull.Value ? Convert.ToInt32(r["SoLuongTon"]) : 0
                });
            }
            return list;
        }

        // 4. Lấy hoặc tạo mới hóa đơn cho sân
        public int LayHoacTaoHoaDon(int maSan)
        {
            string query = "SELECT TOP 1 MaHD FROM HoaDon WHERE MaSan = @MaSan AND TrangThai = N'Chưa thanh toán' ORDER BY MaHD DESC";
            object obj = DataProvider.Instance.ExecuteScalar(query, new SqlParameter[] { new SqlParameter("@MaSan", maSan) });

            if (obj != null && obj != DBNull.Value)
                return Convert.ToInt32(obj);

            string sqlTao = @"
                INSERT INTO HoaDon (MaSan, GioVao, TienSan, TienDichVu, TongTien, TrangThai)
                VALUES (@MaSan, GETDATE(), 0, 0, 0, N'Chưa thanh toán');
                SELECT SCOPE_IDENTITY();";

            object newMaHD = DataProvider.Instance.ExecuteScalar(sqlTao, new SqlParameter[] { new SqlParameter("@MaSan", maSan) });
            DataProvider.Instance.ExecuteNonQuery("UPDATE SanBong SET TrangThai = N'Đang sử dụng' WHERE MaSan = " + maSan);

            return Convert.ToInt32(newMaHD);
        }

        // 5. Lấy danh sách chi tiết dịch vụ của hóa đơn
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

        // 6. Thêm hoặc tăng số lượng món
        public void ThemChiTietDichVu(int maHD, int maDV, decimal donGia)
        {
            string checkSql = "SELECT SoLuong FROM ChiTietDichVu WHERE MaHD = @MaHD AND MaDV = @MaDV";
            SqlParameter[] p = { new SqlParameter("@MaHD", maHD), new SqlParameter("@MaDV", maDV) };
            object sl = DataProvider.Instance.ExecuteScalar(checkSql, p);

            if (sl != null)
            {
                int slMoi = Convert.ToInt32(sl) + 1;
                decimal ttMoi = slMoi * donGia;
                string update = "UPDATE ChiTietDichVu SET SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE MaHD = @MaHD AND MaDV = @MaDV";
                DataProvider.Instance.ExecuteNonQuery(update, new SqlParameter[] {
                    new SqlParameter("@SoLuong", slMoi),
                    new SqlParameter("@ThanhTien", ttMoi),
                    new SqlParameter("@MaHD", maHD),
                    new SqlParameter("@MaDV", maDV)
                });
            }
            else
            {
                string insert = "INSERT INTO ChiTietDichVu (MaHD, MaDV, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaDV, 1, @DonGia, @DonGia)";
                DataProvider.Instance.ExecuteNonQuery(insert, new SqlParameter[] {
                    new SqlParameter("@MaHD", maHD),
                    new SqlParameter("@MaDV", maDV),
                    new SqlParameter("@DonGia", donGia)
                });
            }

            // Trừ kho
            DataProvider.Instance.ExecuteNonQuery("UPDATE DichVu SET SoLuongTon = SoLuongTon - 1 WHERE MaDV = " + maDV);
            // Cập nhật tổng tiền vào HoaDon
            DongBoTienHoaDon(maHD);
        }

        // 7. Giảm số lượng hoặc xóa món
        public void XoaChiTietDichVu(int maHD, int maDV, int soLuongHienTai, decimal donGia, bool giamMot)
        {
            if (giamMot && soLuongHienTai > 1)
            {
                int slMoi = soLuongHienTai - 1;
                decimal ttMoi = slMoi * donGia;
                string update = "UPDATE ChiTietDichVu SET SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE MaHD = @MaHD AND MaDV = @MaDV";
                DataProvider.Instance.ExecuteNonQuery(update, new SqlParameter[] {
                    new SqlParameter("@SoLuong", slMoi),
                    new SqlParameter("@ThanhTien", ttMoi),
                    new SqlParameter("@MaHD", maHD),
                    new SqlParameter("@MaDV", maDV)
                });
                DataProvider.Instance.ExecuteNonQuery("UPDATE DichVu SET SoLuongTon = SoLuongTon + 1 WHERE MaDV = " + maDV);
            }
            else
            {
                DataProvider.Instance.ExecuteNonQuery($"DELETE FROM ChiTietDichVu WHERE MaHD = {maHD} AND MaDV = {maDV}");
                DataProvider.Instance.ExecuteNonQuery($"UPDATE DichVu SET SoLuongTon = SoLuongTon + {soLuongHienTai} WHERE MaDV = {maDV}");
            }
            DongBoTienHoaDon(maHD);
        }

        // 8. Đồng bộ tổng tiền dịch vụ vào HoaDon
        private void DongBoTienHoaDon(int maHD)
        {
            string query = @"
                UPDATE HoaDon 
                SET TienDichVu = ISNULL((SELECT SUM(ThanhTien) FROM ChiTietDichVu WHERE MaHD = @MaHD), 0),
                    TongTien = ISNULL(TienSan, 0) + ISNULL((SELECT SUM(ThanhTien) FROM ChiTietDichVu WHERE MaHD = @MaHD), 0)
                WHERE MaHD = @MaHD";
            DataProvider.Instance.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@MaHD", maHD) });
        }

        // 9. Thanh toán hóa đơn
        public bool ThanhToan(int maSan, int maHD, out decimal tongTien)
        {
            tongTien = 0;
            string query = "SELECT TienSan, TienDichVu FROM HoaDon WHERE MaHD = " + maHD;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return false;

            decimal tienSan = dt.Rows[0]["TienSan"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TienSan"]) : 0;
            decimal tienDV = dt.Rows[0]["TienDichVu"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TienDichVu"]) : 0;
            tongTien = tienSan + tienDV;

            string sqlUpdate = @"
                UPDATE HoaDon 
                SET GioRa = GETDATE(), TongTien = @TongTien, TrangThai = N'Đã thanh toán' 
                WHERE MaHD = @MaHD;
                UPDATE SanBong SET TrangThai = N'Trống' WHERE MaSan = @MaSan;";

            return DataProvider.Instance.ExecuteNonQuery(sqlUpdate, new SqlParameter[] {
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@MaSan", maSan)
            }) > 0;
        }
    }
}