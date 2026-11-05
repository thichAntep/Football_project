//using System.Data;
//using Microsoft.Data.SqlClient;
//using QuanLySanBong.DTO;

//namespace QuanLySanBong.DAL
//{
//    public class SanBongDAL
//    {
//        private static SanBongDAL instance;

//        public static SanBongDAL Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = new SanBongDAL();
//                }

//                return instance;
//            }
//        }

//        private SanBongDAL()
//        {
//        }

//        public DataTable GetAll()
//        {
//            string query = @"
//                SELECT
//                    s.ID,
//                    s.TenSan,
//                    s.LoaiSanID,
//                    l.TenLoaiSan,
//                    s.GiaThue,
//                    s.TrangThai
//                FROM SanBong s
//                INNER JOIN LoaiSan l
//                    ON s.LoaiSanID = l.ID
//                ORDER BY s.ID";

//            return DataProvider.Instance.ExecuteQuery(query);
//        }

//        public int Insert(SanBongDTO sanBong)
//        {
//            string query = @"
//                INSERT INTO SanBong
//                    (TenSan, LoaiSanID, GiaThue, TrangThai)
//                VALUES
//                    (@TenSan, @LoaiSanID, @GiaThue, @TrangThai)";

//            SqlParameter[] parameters =
//            {
//                new SqlParameter("@TenSan", sanBong.TenSan),
//                new SqlParameter("@LoaiSanID", sanBong.LoaiSanID),
//                new SqlParameter("@GiaThue", sanBong.GiaThue),
//                new SqlParameter("@TrangThai", sanBong.TrangThai)
//            };

//            return DataProvider.Instance.ExecuteNonQuery(
//                query,
//                parameters);
//        }

//        public int Delete(int id)
//        {
//            string query = @"
//                DELETE FROM SanBong
//                WHERE ID = @ID";

//            SqlParameter[] parameters =
//            {
//                new SqlParameter("@ID", id)
//            };

//            return DataProvider.Instance.ExecuteNonQuery(
//                query,
//                parameters);
//        }
//    }
//}

using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySanBong.DAL
{
    public class SanBongDAL
    {
        public static SanBongDAL instance;

        public static SanBongDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SanBongDAL();

                return instance;
            }
        }

        public SanBongDAL()
        {
        }

        // 1. Lấy danh sách sân và loại sân
        public DataTable GetAll()
        {
            string query = @"
                SELECT
                    s.MaSan,
                    s.TenSan,
                    s.MaLoai,
                    l.TenLoai,
                    s.TrangThai
                FROM SanBong s
                INNER JOIN LoaiSan l
                    ON s.MaLoai = l.MaLoai
                ORDER BY s.MaSan";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 2. Lấy danh sách sân kèm các khung giờ và giá tiền
        public DataTable GetAllWithKhungGio()
        {
            string query = @"
                SELECT
                    s.MaSan,
                    s.TenSan,
                    s.MaLoai,
                    l.TenLoai,
                    s.TrangThai,
                    kg.MaKhungGio,
                    CONVERT(VARCHAR(5), kg.GioBatDau, 108)
                    + ' - ' +
                    CONVERT(VARCHAR(5), kg.GioKetThuc, 108)
                    AS KhungGio,
                    sbk.GiaTien
                FROM SanBong s

                INNER JOIN LoaiSan l
                    ON s.MaLoai = l.MaLoai

                LEFT JOIN SanBong_KhungGio sbk
                    ON s.MaSan = sbk.MaSan

                LEFT JOIN KhungGio kg
                    ON sbk.MaKhungGio = kg.MaKhungGio

                ORDER BY s.MaSan, kg.GioBatDau";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 3. Kiểm tra tên sân đã tồn tại chưa
        public bool ExistsName(string tenSan)
        {
            string query = @"
                SELECT COUNT(*)
                FROM SanBong
                WHERE TenSan = @TenSan";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenSan", tenSan)
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(
                query, parameters);

            return Convert.ToInt32(data.Rows[0][0]) > 0;
        }

        // 4. Thêm sân và trả về MaSan vừa tạo
        public int Insert(string tenSan, int maLoai, string trangThai)
        {
            string query = @"
                INSERT INTO SanBong
                    (TenSan, MaLoai, TrangThai)
                OUTPUT INSERTED.MaSan
                VALUES
                    (@TenSan, @MaLoai, @TrangThai)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenSan", tenSan),
                new SqlParameter("@MaLoai", maLoai),
                new SqlParameter("@TrangThai", trangThai)
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(
                query, parameters);

            if (data.Rows.Count == 0)
                throw new Exception("Không lấy được mã sân vừa tạo.");

            return Convert.ToInt32(data.Rows[0]["MaSan"]);
        }

        // 5. Lấy giá mặc định theo loại sân
        public decimal GetDefaultPrice(int maLoai)
        {
            string query = @"
                SELECT DonGiaGio
                FROM LoaiSan
                WHERE MaLoai = @MaLoai";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaLoai", maLoai)
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(
                query, parameters);

            if (data.Rows.Count == 0)
                throw new Exception("Không tìm thấy loại sân.");

            return Convert.ToDecimal(data.Rows[0]["DonGiaGio"]);
        }

        // 6. Tìm sân theo tên
        public DataTable GetByName(string tenSan)
        {
            string query = @"
                SELECT
                    s.MaSan,
                    s.TenSan,
                    s.MaLoai,
                    l.TenLoai,
                    s.TrangThai
                FROM SanBong s
                INNER JOIN LoaiSan l
                    ON s.MaLoai = l.MaLoai
                WHERE s.TenSan = @TenSan";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenSan", tenSan)
            };

            return DataProvider.Instance.ExecuteQuery(
                query, parameters);
        }

        // 7. Chỉ xóa sân khi không còn khung giờ liên kết
        public int DeleteIfNoKhungGio(int maSan)
        {
            string query = @"
                DELETE FROM SanBong
                WHERE MaSan = @MaSan
                AND NOT EXISTS
                (
                    SELECT 1
                    FROM SanBong_KhungGio
                    WHERE MaSan = @MaSan
                )";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSan", maSan)
            };

            return DataProvider.Instance.ExecuteNonQuery(
                query, parameters);
        }
        // Lấy Danh Sách Sân Bóng Đang trống
        public int LaySanBongDangTrong()
        {
            string sql = @"SELECT COUNT(*)
                           FROM SANBONG
                           WHERE TrangThai = N'Trống'";
            int soLuong = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(sql));
            return soLuong;
        }
        // Lấy Lịch Theo Ngày 
        
    }
}
