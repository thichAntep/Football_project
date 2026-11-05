
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySanBong.DAL
{
    public class LichSanDAL
    {
        private static LichSanDAL instance;

        public static LichSanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LichSanDAL();

                return instance;
            }
        }

        public LichSanDAL()
        {
        }

        // 1. Lấy tất cả khung giờ đang hoạt động
        public DataTable GetAllKhungGio()
        {
            string query = @"
                SELECT
                    MaKhungGio,
                    GioBatDau,
                    GioKetThuc
                FROM KhungGio
                WHERE TrangThai = 1
                ORDER BY GioBatDau";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 2. Lấy khung giờ của một sân
        public DataTable GetByMaSan(int maSan)
        {
            string query = @"
                SELECT
                    sbk.MaID,
                    s.MaSan,
                    s.TenSan,
                    s.MaLoai,
                    l.TenLoai,
                    kg.MaKhungGio,
                    kg.GioBatDau,
                    kg.GioKetThuc,
                    sbk.GiaTien
                FROM SanBong_KhungGio sbk

                INNER JOIN SanBong s
                    ON sbk.MaSan = s.MaSan

                INNER JOIN LoaiSan l
                    ON s.MaLoai = l.MaLoai

                INNER JOIN KhungGio kg
                    ON sbk.MaKhungGio = kg.MaKhungGio

                WHERE s.MaSan = @MaSan
                ORDER BY kg.GioBatDau";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSan", maSan)
            };

            return DataProvider.Instance.ExecuteQuery(
                query, parameters);
        }

        // 3. Lấy toàn bộ sân và khung giờ
        public DataTable GetAll()
        {
            string query = @"
                SELECT
                    sbk.MaID,
                    s.MaSan,
                    s.TenSan,
                    l.TenLoai,
                    kg.MaKhungGio,
                    kg.GioBatDau,
                    kg.GioKetThuc,
                    sbk.GiaTien
                FROM SanBong_KhungGio sbk

                INNER JOIN SanBong s
                    ON sbk.MaSan = s.MaSan

                INNER JOIN LoaiSan l
                    ON s.MaLoai = l.MaLoai

                INNER JOIN KhungGio kg
                    ON sbk.MaKhungGio = kg.MaKhungGio

                ORDER BY s.MaSan, kg.GioBatDau";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 4. Kiểm tra sân đã có khung giờ này chưa
        public bool Exists(int maSan, int maKhungGio)
        {
            string query = @"
                SELECT COUNT(*)
                FROM SanBong_KhungGio
                WHERE MaSan = @MaSan
                AND MaKhungGio = @MaKhungGio";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSan", maSan),
                new SqlParameter("@MaKhungGio", maKhungGio)
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(
                query, parameters);

            return Convert.ToInt32(data.Rows[0][0]) > 0;
        }

        // 5. Thêm nhiều khung giờ cho một sân
        public int InsertMany(
            int maSan,
            List<int> danhSachMaKhungGio,
            decimal giaTien)
        {
            if (danhSachMaKhungGio == null ||
                danhSachMaKhungGio.Count == 0)
            {
                throw new Exception("Bạn chưa chọn khung giờ.");
            }

            if (giaTien < 0)
                throw new Exception("Giá tiền không hợp lệ.");

            // Loại bỏ mã khung giờ bị lặp
            List<int> danhSach =
                new List<int>(new HashSet<int>(danhSachMaKhungGio));

            string query = @"
                SET NOCOUNT ON;

                BEGIN TRY
                    BEGIN TRANSACTION;
            ";

            List<SqlParameter> parameters =
                new List<SqlParameter>();

            parameters.Add(
                new SqlParameter("@MaSan", maSan));

            parameters.Add(
                new SqlParameter("@GiaTien", giaTien));

            int count = 0;

            for (int i = 0; i < danhSach.Count; i++)
            {
                string paramName = "@MaKhungGio" + i;

                query += $@"
                    IF NOT EXISTS
                    (
                        SELECT 1
                        FROM SanBong_KhungGio
                        WHERE MaSan = @MaSan
                        AND MaKhungGio = {paramName}
                    )
                    BEGIN
                        INSERT INTO SanBong_KhungGio
                            (MaSan, MaKhungGio, GiaTien)
                        VALUES
                            (@MaSan, {paramName}, @GiaTien);

                        SET @SoLuong = @SoLuong + 1;
                    END;
                ";

                parameters.Add(
                    new SqlParameter(paramName, danhSach[i]));

                count++;
            }

            query += @"
                    COMMIT TRANSACTION;

                    SELECT @SoLuong AS SoLuong;
                END TRY

                BEGIN CATCH
                    IF @@TRANCOUNT > 0
                        ROLLBACK TRANSACTION;

                    THROW;
                END CATCH;
            ";

            parameters.Add(
                new SqlParameter("@SoLuong", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                });

            DataProvider.Instance.ExecuteQuery(
                query, parameters.ToArray());

            return Convert.ToInt32(
                parameters[parameters.Count - 1].Value);
        }

        // 6. Xóa khung giờ và tự xóa sân nếu không còn khung giờ
        public DataTable DeleteAndCheckSan(int maID)
        {
            string query = @"
                SET NOCOUNT ON;

                DECLARE @MaSan INT;
                DECLARE @DaXoaSan BIT = 0;

                BEGIN TRY
                    BEGIN TRANSACTION;

                    SELECT @MaSan = MaSan
                    FROM SanBong_KhungGio
                    WHERE MaID = @MaID;

                    IF @MaSan IS NULL
                        THROW 50001, N'Không tìm thấy khung giờ.', 1;

                    DELETE FROM SanBong_KhungGio
                    WHERE MaID = @MaID;

                    IF NOT EXISTS
                    (
                        SELECT 1
                        FROM SanBong_KhungGio
                        WHERE MaSan = @MaSan
                    )
                    BEGIN
                        DELETE FROM SanBong
                        WHERE MaSan = @MaSan;

                        SET @DaXoaSan = 1;
                    END;

                    COMMIT TRANSACTION;

                    SELECT
                        1 AS DaXoaKhungGio,
                        @DaXoaSan AS DaXoaSan;
                END TRY

                BEGIN CATCH
                    IF @@TRANCOUNT > 0
                        ROLLBACK TRANSACTION;

                    THROW;
                END CATCH;
            ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaID", maID)
            };

            return DataProvider.Instance.ExecuteQuery(
                query, parameters);
        }
        //Lấy 1 Bảng Khung Giờ
        // 7. Lấy lịch sân theo ngày: mỗi dòng = 1 (sân, khung giờ), kèm phiếu đặt nếu có
        public DataTable GetLichTheoNgay(DateTime ngay)
        {
            string query = @"

            SELECT
                s.MaSan,
                s.TenSan,
                kg.MaKhungGio,
                kg.GioBatDau,
                kg.GioKetThuc,
                p.TrangThai,
                k.TenKH,
                k.SoDienThoai

            FROM SanBong_KhungGio sbk

            INNER JOIN SanBong s
                ON sbk.MaSan = s.MaSan

            INNER JOIN KhungGio kg
                ON sbk.MaKhungGio = kg.MaKhungGio

            LEFT JOIN PhieuDatSan p
                ON p.MaSan = sbk.MaSan
                AND p.GioBatDau = kg.GioBatDau
                AND p.GioKetThuc = kg.GioKetThuc
                AND p.NgayDat = @Ngay
                AND p.TrangThai <> N'Đã hủy'

            LEFT JOIN KhachHang k
                ON k.MaKH = p.MaKH

            WHERE kg.TrangThai = 1

            ORDER BY
                s.MaSan,
                kg.GioBatDau";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Ngay", ngay.Date)
    };

            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
    }
}
