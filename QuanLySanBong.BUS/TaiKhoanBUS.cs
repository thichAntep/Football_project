
using QuanLySanBong.DAL;
using System;
using System.Data;

namespace QuanLySanBong.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        // Đăng nhập
        public DataTable DangNhap(string tenDangNhap, string matKhau)
        {    // .IsNullOrWhiteSpace(value);
            // Parameters : Value -> String    | Returns = Boolean
            // Hàm trả về "True" với giá trị rỗng trong value
            // Hàm Trả về "Flase" với giá trị ký tự hoặc khoảng trắng
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return null;

            if (string.IsNullOrWhiteSpace(matKhau))
                return null;

            return taiKhoanDAL.DangNhap(tenDangNhap, matKhau);
        }

        // Đăng ký
        public int DangKy(
            string tenDangNhap,
            string matKhau,
            string hoTen)
        {
            // Bước 1: Kiểm tra thông tin trống
            if (string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau) ||
                string.IsNullOrWhiteSpace(hoTen))
            {   // Throw phát hiện ném 1 ngoại lệ
                throw new ArgumentException( // ArgumentExceptrion tạo ra lỗi
                    "Vui lòng nhập đầy đủ thông tin!");
            }

            // Bước 2: Loại bỏ khoảng trắng ở đầu và cuối
            // Câu lệnh 
            tenDangNhap = tenDangNhap.Trim(); // .Trim() Loại Bỏ khoảng trắng đầu cuối
            hoTen = hoTen.Trim();

            // Bước 3: Kiểm tra tên đăng nhập đã tồn tại chưa
            if (taiKhoanDAL.KiemTraTenDangNhap(tenDangNhap))
            {
                throw new ArgumentException(
                    "Tên đăng nhập đã tồn tại!");
            }

            // Bước 4: Thêm tài khoản với quyền Khách Hàng
            return taiKhoanDAL.DangKy(
                tenDangNhap,
                matKhau,
                hoTen,
                "NhanVien");
        }
    }
}

