using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanBong.DTO
{
    /// <summary>
    /// CÁC GIÁ TRỊ CHỮ LƯU TRONG DB. Phải KHỚP với dữ liệu thật trong bảng của bạn.
    /// </summary>
    public static class HangSo
    {
        public const string SAN_BAO_TRI = "Bảo trì";   // SanBong.TrangThai khi sân đang bảo trì
        public const string PHIEU_DA_DAT = "Đã đặt";   // PHIEUDATSAN.TrangThai khi mới đặt (tối đa 20 ký tự)
        public const string PHIEU_DA_HUY = "Đã hủy";   // PHIEUDATSAN.TrangThai khi hủy
    }

    /// <summary>Lưu tài khoản đang đăng nhập. Gán sau khi đăng nhập thành công: PhienDangNhap.MaTK = ...;</summary>
    public static class PhienDangNhap
    {
        public static int MaTK { get; set; }
    }
}