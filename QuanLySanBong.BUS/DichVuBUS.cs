using System.Collections.Generic;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;

namespace QuanLySanBong.BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL dal = new DichVuDAL();

        public List<SanDangDaDTO> LayDanhSachSan() => dal.LayDSSanDangDa();

        public List<string> LayDanhSachDVT() => dal.LayDSDonViTinh();

        public List<DichVuDTO> LayDanhSachDichVu() => dal.LayTatCaDichVu();

        public List<ChiTietDichVuDTO> LayChiTiet(int maSan, out int maHD)
        {
            maHD = dal.LayHoacTaoHoaDon(maSan);
            return dal.LayChiTietDichVu(maHD);
        }

        public bool ThemDichVu(int maSan, DichVuDTO dv, out string thongBao)
        {
            thongBao = "";
            if (dv.SoLuongTon <= 0)
            {
                thongBao = $"Dịch vụ '{dv.TenDV}' đã hết hàng trong kho!";
                return false;
            }

            int maHD = dal.LayHoacTaoHoaDon(maSan);
            dal.ThemChiTietDichVu(maHD, dv.MaDV, dv.DonGia);
            return true;
        }

        public void XoaDichVu(int maSan, int maDV, int soLuongHienTai, decimal donGia, bool giamMot)
        {
            int maHD = dal.LayHoacTaoHoaDon(maSan);
            dal.XoaChiTietDichVu(maHD, maDV, soLuongHienTai, donGia, giamMot);
        }

        public bool ThanhToan(int maSan, out decimal tongTien, out string thongBao)
        {
            thongBao = "";
            tongTien = 0;
            int maHD = dal.LayHoacTaoHoaDon(maSan);

            bool ketQua = dal.ThanhToan(maSan, maHD, out tongTien);
            if (!ketQua)
            {
                thongBao = "Không tìm thấy hóa đơn cần thanh toán!";
                return false;
            }
            return true;
        }
    }
}