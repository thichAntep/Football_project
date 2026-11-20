using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySanBong.DAL
{
    public class BaoCaoDAL
    {
        private static BaoCaoDAL instance;
        public static BaoCaoDAL Instance
        {
            get { if (instance == null) instance = new BaoCaoDAL(); return instance; }
            private set { instance = value; }
        }

        private BaoCaoDAL() { }

        // 1. Lấy danh sách sân bóng cho ComboBox lọc
        public DataTable GetDanhSachSanBong()
        {
            string query = "SELECT MaSan, TenSan FROM SanBong";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // 2. Lấy dữ liệu hóa đơn theo khoảng thời gian và sân
        public DataTable GetDanhSachHoaDonBaoCao(DateTime tuNgay, DateTime denNgay, int maSan = 0)
        {
            string query = @"
                SELECT 
                    hd.MaHD,
                    sb.TenSan,
                    ISNULL(kh.TenKH, N'Khách vãng lai') AS TenKH,
                    tk.HoTen AS NhanVien,
                    hd.GioVao,
                    hd.GioRa,
                    ISNULL(hd.TienSan, 0) AS TienSan,
                    ISNULL(hd.TienDichVu, 0) AS TienDichVu,
                    ISNULL(hd.TongTien, 0) AS TongTien,
                    hd.TrangThai
                FROM HoaDon hd
                LEFT JOIN SanBong sb ON hd.MaSan = sb.MaSan
                LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                LEFT JOIN TaiKhoan tk ON hd.MaTK = tk.MaTK
                WHERE (ISNULL(hd.GioRa, hd.GioVao) >= @TuNgay AND ISNULL(hd.GioRa, hd.GioVao) <= @DenNgay)
                  AND (@MaSan = 0 OR hd.MaSan = @MaSan)
                ORDER BY hd.GioRa DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay),
                new SqlParameter("@MaSan", maSan)
            };

            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }

        // 3. Thống kê dịch vụ tiêu thụ (tùy chọn)
        public DataTable GetThongKeDichVu(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT 
                    dv.TenDV,
                    dv.DVT,
                    SUM(ct.SoLuong) AS TongSoLuong,
                    SUM(ct.ThanhTien) AS TongTien
                FROM ChiTietDichVu ct
                JOIN DichVu dv ON ct.MaDV = dv.MaDV
                JOIN HoaDon hd ON ct.MaHD = hd.MaHD
                WHERE (ISNULL(hd.GioRa, hd.GioVao) >= @TuNgay AND ISNULL(hd.GioVao, hd.GioRa) <= @DenNgay)
                GROUP BY dv.TenDV, dv.DVT
                ORDER BY TongTien DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay)
            };

            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
    }
}