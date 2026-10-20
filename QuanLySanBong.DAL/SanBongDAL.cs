using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySanBong.DTO;

namespace QuanLySanBong.DAL
{
    public class SanBongDAL
    {
        private static SanBongDAL instance;

        public static SanBongDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanBongDAL();
                }

                return instance;
            }
        }

        private SanBongDAL()
        {
        }

        public DataTable GetAll()
        {
            string query = @"
                SELECT
                    s.ID,
                    s.TenSan,
                    s.LoaiSanID,
                    l.TenLoaiSan,
                    s.GiaThue,
                    s.TrangThai
                FROM SanBong s
                INNER JOIN LoaiSan l
                    ON s.LoaiSanID = l.ID
                ORDER BY s.ID";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int Insert(SanBongDTO sanBong)
        {
            string query = @"
                INSERT INTO SanBong
                    (TenSan, LoaiSanID, GiaThue, TrangThai)
                VALUES
                    (@TenSan, @LoaiSanID, @GiaThue, @TrangThai)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenSan", sanBong.TenSan),
                new SqlParameter("@LoaiSanID", sanBong.LoaiSanID),
                new SqlParameter("@GiaThue", sanBong.GiaThue),
                new SqlParameter("@TrangThai", sanBong.TrangThai)
            };

            return DataProvider.Instance.ExecuteNonQuery(
                query,
                parameters);
        }

        public int Delete(int id)
        {
            string query = @"
                DELETE FROM SanBong
                WHERE ID = @ID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", id)
            };

            return DataProvider.Instance.ExecuteNonQuery(
                query,
                parameters);
        }
    }
}