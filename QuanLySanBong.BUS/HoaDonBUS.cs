using System;
using System.Data;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;

namespace QuanLySanBong.BUS
{
    public class HoaDonBUS
    {
        public const string CHUA_THANH_TOAN = "Chưa thanh toán";
        public const string DA_THANH_TOAN = "Đã thanh toán";

        private readonly HoaDonDAL dal = new HoaDonDAL();

        public DataTable TimHoaDon(DateTime tu, DateTime den, string trangThai, string tuKhoa)
        {
            if (tu.Date > den.Date)
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
            return dal.TimHoaDon(tu, den, trangThai, tuKhoa);
        }

        public DataTable GetChiTietDichVu(int maHD) => dal.GetChiTietDichVu(maHD);

        public HoaDonDTO GetById(int maHD) => dal.GetById(maHD);

        public HoaDonDTO ThanhToan(int maHD)
        {
            HoaDonDTO hd = dal.GetById(maHD);
            if (hd == null) throw new Exception("Không tìm thấy hóa đơn.");
            if (hd.TrangThai == DA_THANH_TOAN) throw new Exception("Hóa đơn này đã thanh toán.");

            DateTime gioRa = DateTime.Now;
            decimal gio = (decimal)(gioRa - hd.GioVao).TotalHours;
            decimal donGia = hd.MaSan.HasValue ? dal.GetDonGiaGio(hd.MaSan.Value) : 0;

            hd.GioRa = gioRa;
            hd.TienSan = Math.Round(gio * donGia, 0);
            hd.TienDichVu = dal.TongTienDichVu(maHD);
            hd.TongTien = hd.TienSan + hd.TienDichVu;
            hd.TrangThai = DA_THANH_TOAN;

            dal.CapNhatThanhToan(maHD, gioRa, hd.TienSan, hd.TienDichVu, hd.TongTien, hd.TrangThai);
            return hd;
        }
    }
}