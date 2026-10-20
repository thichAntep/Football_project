using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySanBong.DAL
{
    public class TaiKhoanDAL
    {
        public DataTable DangNhap(string tenDangNhap, string matKhau) // Kiểu dữ liệu trả về của hàm DataTable Chứa kết quả truy vấn từ database
        {
            string query = @"SELECT MaTK , TenDangNhap,HoTen,VaiTro
                                 FROM TaiKhoan
                                 WHERE TenDangNhap = @TenDangNhap      
                                 AND MatKhau = @MatKhau"; // Câu Lệnh SQL -> dùng tham số @String
            SqlParameter[] parameters =    //Khai Báo 1 Mảng SqlParameter       //Parameter : Tham số
            {      //new SqlParameter("@parameter",value)  lệnh này tạo 1 tham số SQL bao gồm @tenDangNhap || giá trị thu thập từ biến tenDangNhap
                   //Ex: string tenDangNhap = "admin"  thì tham số tương thích @TenDangNhap = "admin"
                     new SqlParameter("@TenDangNhap",tenDangNhap),  // -> gán dữ liệu người dùng vào tham số SQL @TenDangNhap -> tenDangNhap
                     new SqlParameter("@MatKhau",matKhau)           // Tương tự  @MatKhau -> matKhau
                };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }

        public int  DangKy(
            string tenDangNhap,
            string matKhau,
            string hoTen,
            string vaiTro
            )
        {
            string query = @"
                            INSERT INTO TaiKhoan
                                (TenDangNhap,MatKhau,HoTen,VaiTro)
                            VALUES
                                (@TenDangNhap,@MatKhau,@HoTen,@VaiTro)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@TenDangNhap",tenDangNhap),
                new SqlParameter("@MatKhau",matKhau),
                new SqlParameter("@HoTen",hoTen),
                new SqlParameter("@VaiTro",vaiTro)
            };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters);

        }
        public bool KiemTraTenDangNhap(string tenDangNhap)
        {
            string query = @"
                            SELECT COUNT(*)
                            FROM TaiKhoan
                            WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameter =
            {
                new SqlParameter("@TenDangNhap",tenDangNhap)
            };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameter);
            return Convert.ToInt32(data.Rows[0][0]) > 0;
        }
    }
}
