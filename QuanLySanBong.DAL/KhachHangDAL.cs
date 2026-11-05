using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuanLySanBong.DAL
{
    public class KhachHangDAL
    {
        public int KhachHangDangCho()
        {
            string sql = @"SELECT COUNT(*)
                   FROM PHIEUDATSAN
                   WHERE TrangThai = N'Chờ Xác Nhận'";

            int soLuong = Convert.ToInt32(
                DataProvider.Instance.ExecuteScalar(sql)
            );

            return soLuong;
        }

    }
}
