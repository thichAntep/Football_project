using System;
using System.Data;
using QuanLySanBong.DAL;

namespace QuanLySanBong.DAL
{
    public class PhieuDatSanDAL
    {
        // Đếm số sân đã được đặt trong ngày hôm nay
        public int DemSanDatHomNay()
        {
            string sql = @"
                SELECT COUNT(DISTINCT MaSan)
                FROM PHIEUDATSAN
                WHERE CAST(NgayDat AS DATE) = CAST(GETDATE() AS DATE)";

            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            return Convert.ToInt32(data.Rows[0][0]);
        }
    }
}