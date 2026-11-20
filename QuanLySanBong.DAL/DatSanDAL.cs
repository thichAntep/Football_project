using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySanBong.DTO;

namespace QuanLySanBong.DAL
{
    public class DatSanDAL
    {
        public List<LoaiSanDTO> LayDanhSachLoaiSan()
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT MaLoai, TenLoai, DonGiaGio FROM LoaiSan ORDER BY MaLoai");

            var ds = new List<LoaiSanDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new LoaiSanDTO
                {
                    MaLoai = Convert.ToInt32(r["MaLoai"]),
                    TenLoai = r["TenLoai"].ToString(),
                    DonGiaGio = r["DonGiaGio"] == DBNull.Value ? 0 : Convert.ToDecimal(r["DonGiaGio"])
                });
            }
            return ds;
        }

        /// <summary>
        /// Sơ đồ: mọi (sân x khung giờ) của loại sân đã chọn (maLoai = 0 => tất cả),
        /// kèm phiếu đặt (nếu có) trong ngày đó. PHIEUDATSAN lưu giờ trực tiếp nên
        /// khớp theo GioBatDau của khung giờ.
        /// </summary>
        public List<OSanDTO> LaySoDo(DateTime ngay, int maLoai)
        {
            const string sql = @"
                SELECT s.MaSan, s.TenSan, s.TrangThai AS TrangThaiSan,
                       k.MaKhungGio, k.GioBatDau, k.GioKetThuc,
                       ISNULL(sk.GiaTien, ISNULL(lo.DonGiaGio, 0) * 1.5) AS GiaTien,
                       p.MaPhieu, kh.TenKH
                FROM SanBong s
                LEFT JOIN LoaiSan lo ON lo.MaLoai = s.MaLoai
                CROSS JOIN KhungGio k
                LEFT JOIN SanBong_KhungGio sk
                       ON sk.MaSan = s.MaSan AND sk.MaKhungGio = k.MaKhungGio
                LEFT JOIN PHIEUDATSAN p
                       ON p.MaSan = s.MaSan
                      AND p.NgayDat = @Ngay
                      AND p.GioBatDau = k.GioBatDau
                      AND p.TrangThai <> @DaHuy
                LEFT JOIN KhachHang kh ON kh.MaKH = p.MaKH
                WHERE k.TrangThai = 1
                  AND (@MaLoai = 0 OR s.MaLoai = @MaLoai)
                ORDER BY s.MaSan, k.GioBatDau";

            var pr = new SqlParameter[]
            {
                new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date },
                new SqlParameter("@MaLoai", SqlDbType.Int) { Value = maLoai },
                new SqlParameter("@DaHuy", SqlDbType.NVarChar, 20) { Value = HangSo.PHIEU_DA_HUY }
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, pr);
            var ds = new List<OSanDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new OSanDTO
                {
                    MaSan = Convert.ToInt32(r["MaSan"]),
                    TenSan = r["TenSan"].ToString(),
                    MaKhungGio = Convert.ToInt32(r["MaKhungGio"]),
                    GioBatDau = (TimeSpan)r["GioBatDau"],
                    GioKetThuc = (TimeSpan)r["GioKetThuc"],
                    DonGia = r["GiaTien"] == DBNull.Value ? 0 : Convert.ToDecimal(r["GiaTien"]),
                    SanBaoTri = string.Equals(r["TrangThaiSan"] as string, HangSo.SAN_BAO_TRI,
                                              StringComparison.OrdinalIgnoreCase),
                    MaPhieu = r["MaPhieu"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["MaPhieu"]),
                    TenKhachDat = r["TenKH"] == DBNull.Value ? "" : r["TenKH"].ToString()
                });
            }
            return ds;
        }

        public KhachHangDTO TimKhachTheoSDT(string sdt)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT TOP 1 MaKH, TenKH, SoDienThoai FROM KhachHang WHERE SoDienThoai = @Sdt",
                new SqlParameter[] { new SqlParameter("@Sdt", SqlDbType.NVarChar, 20) { Value = sdt } });

            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new KhachHangDTO
            {
                MaKH = Convert.ToInt32(r["MaKH"]),
                TenKH = r["TenKH"].ToString(),
                SoDienThoai = r["SoDienThoai"].ToString()
            };
        }

        public int ThemKhach(string ten, string sdt)
        {
            object kq = DataProvider.Instance.ExecuteScalar(
                "INSERT INTO KhachHang(TenKH, SoDienThoai) VALUES(@Ten, @Sdt); SELECT CAST(SCOPE_IDENTITY() AS int);",
                new SqlParameter[]
                {
                    new SqlParameter("@Ten", SqlDbType.NVarChar, 100) { Value = ten },
                    new SqlParameter("@Sdt", SqlDbType.NVarChar, 20) { Value = sdt }
                });
            return Convert.ToInt32(kq);
        }

        /// <summary>Thêm phiếu. Trả về MaPhieu mới; trả 0 nếu khung giờ đó đã có người đặt (kiểm tra + thêm trong 1 câu lệnh).</summary>
        public int ThemPhieu(PhieuDatSanDTO p)
        {
            const string sql = @"
                IF EXISTS (SELECT 1 FROM PHIEUDATSAN
                           WHERE MaSan = @MaSan AND NgayDat = @NgayDat
                             AND GioBatDau = @GioBatDau AND TrangThai <> @DaHuy)
                    SELECT 0;
                ELSE
                BEGIN
                    INSERT INTO PHIEUDATSAN
                        (MaKH, MaSan, MaTK, NgayDat, GioBatDau, GioKetThuc, NgayLap, DonGia, TienCoc, TrangThai, GhiChu)
                    VALUES
                        (@MaKH, @MaSan, @MaTK, @NgayDat, @GioBatDau, @GioKetThuc, GETDATE(), @DonGia, @TienCoc, @TrangThai, @GhiChu);
                    SELECT CAST(SCOPE_IDENTITY() AS int);
                END";

            var pr = new SqlParameter[]
            {
                new SqlParameter("@MaKH", SqlDbType.Int) { Value = p.MaKH },
                new SqlParameter("@MaSan", SqlDbType.Int) { Value = p.MaSan },
                new SqlParameter("@MaTK", SqlDbType.Int) { Value = p.MaTK },
                new SqlParameter("@NgayDat", SqlDbType.Date) { Value = p.NgayDat.Date },
                new SqlParameter("@GioBatDau", SqlDbType.Time) { Value = p.GioBatDau },
                new SqlParameter("@GioKetThuc", SqlDbType.Time) { Value = p.GioKetThuc },
                new SqlParameter("@DonGia", SqlDbType.Decimal) { Precision = 18, Scale = 0, Value = p.DonGia },
                new SqlParameter("@TienCoc", SqlDbType.Decimal) { Precision = 18, Scale = 0, Value = p.TienCoc },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 20) { Value = p.TrangThai },
                new SqlParameter("@GhiChu", SqlDbType.NVarChar, 200) { Value = (object)p.GhiChu ?? DBNull.Value },
                new SqlParameter("@DaHuy", SqlDbType.NVarChar, 20) { Value = HangSo.PHIEU_DA_HUY }
            };

            object kq = DataProvider.Instance.ExecuteScalar(sql, pr);
            return Convert.ToInt32(kq);
        }

        public PhieuDatSanDTO LayPhieu(int maPhieu)
        {
            const string sql = @"
                SELECT p.MaPhieu, p.MaKH, p.MaSan, p.NgayDat, p.GioBatDau, p.GioKetThuc,
                       p.DonGia, p.TienCoc, p.TrangThai, p.GhiChu, kh.TenKH, kh.SoDienThoai
                FROM PHIEUDATSAN p
                JOIN KhachHang kh ON kh.MaKH = p.MaKH
                WHERE p.MaPhieu = @MaPhieu";

            DataTable dt = DataProvider.Instance.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@MaPhieu", SqlDbType.Int) { Value = maPhieu } });

            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new PhieuDatSanDTO
            {
                MaPhieu = Convert.ToInt32(r["MaPhieu"]),
                MaKH = Convert.ToInt32(r["MaKH"]),
                MaSan = Convert.ToInt32(r["MaSan"]),
                NgayDat = Convert.ToDateTime(r["NgayDat"]),
                GioBatDau = (TimeSpan)r["GioBatDau"],
                GioKetThuc = (TimeSpan)r["GioKetThuc"],
                DonGia = r["DonGia"] == DBNull.Value ? 0 : Convert.ToDecimal(r["DonGia"]),
                TienCoc = r["TienCoc"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TienCoc"]),
                TrangThai = r["TrangThai"].ToString(),
                GhiChu = r["GhiChu"] == DBNull.Value ? "" : r["GhiChu"].ToString(),
                TenKH = r["TenKH"].ToString(),
                SoDienThoai = r["SoDienThoai"] == DBNull.Value ? "" : r["SoDienThoai"].ToString()
            };
        }

        public bool HuyPhieu(int maPhieu)
        {
            int n = DataProvider.Instance.ExecuteNonQuery(
                "UPDATE PHIEUDATSAN SET TrangThai = @DaHuy WHERE MaPhieu = @MaPhieu AND TrangThai <> @DaHuy",
                new SqlParameter[]
                {
                    new SqlParameter("@DaHuy", SqlDbType.NVarChar, 20) { Value = HangSo.PHIEU_DA_HUY },
                    new SqlParameter("@MaPhieu", SqlDbType.Int) { Value = maPhieu }
                });
            return n > 0;
        }
    }
}