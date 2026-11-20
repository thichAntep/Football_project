using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;

namespace QuanLySanBong.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        public List<HoaDonDTO> LayDanhSachHoaDonChuaThanhToan()
        {
            return dal.LayDSHoaDonChuaThanhToan();
        }

        public List<ChiTietDichVuDTO> LayChiTietDichVu(int maHD)
        {
            return dal.LayChiTietDichVu(maHD);
        }

        // Tính tiền sân theo phút thực tế x GiaTheoGio / 60
        public decimal TinhTienSan(DateTime gioVao, DateTime gioRa, decimal giaTheoGio)
        {
            double tongPhut = (gioRa - gioVao).TotalMinutes;
            if (tongPhut <= 0) tongPhut = 60; // Mặc định tối thiểu 1 tiếng

            decimal tien = (decimal)(tongPhut / 60.0) * giaTheoGio;
            return Math.Round(tien / 1000) * 1000; // Làm tròn đến hàng nghìn VNĐ
        }

        public bool ThanhToan(HoaDonDTO hd, DateTime gioRa, out string loi)
        {
            loi = "";
            try
            {
                decimal tienSan = TinhTienSan(hd.GioVao, gioRa, hd.DonGiaGio);
                decimal tienDV = hd.DanhSachDichVu.Sum(x => x.ThanhTien);
                decimal tongTien = tienSan + tienDV;

                return dal.ThanhToanHoaDon(hd.MaHD, hd.MaSan, gioRa, tienSan, tienDV, tongTien);
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }
    }
}