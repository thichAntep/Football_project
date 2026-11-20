using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;

namespace QuanLySanBong.BUS
{
    public class DatSanBUS
    {
        private readonly DatSanDAL dal = new DatSanDAL();

        public List<LoaiSanDTO> LayLoaiSan()
        {
            return dal.LayDanhSachLoaiSan();
        }

        // Khung giờ có thể kết thúc sau 0h (vd 23:45 -> 01:15) nên cộng thêm 24h khi giờ kết thúc <= giờ bắt đầu
        private static DateTime BatDau(DateTime ngay, TimeSpan gioBd)
        {
            return ngay.Date + gioBd;
        }

        private static DateTime KetThuc(DateTime ngay, TimeSpan gioBd, TimeSpan gioKt)
        {
            TimeSpan dai = gioKt > gioBd ? gioKt - gioBd : gioKt - gioBd + TimeSpan.FromHours(24);
            return ngay.Date + gioBd + dai;
        }

        /// <summary>Lấy sơ đồ rồi quyết định màu (Trống / Đã đặt / Đang đá / Bảo trì) cho từng ô.</summary>
        public List<OSanDTO> LaySoDo(DateTime ngay, int maLoai)
        {
            var ds = dal.LaySoDo(ngay, maLoai);
            DateTime now = DateTime.Now;

            foreach (var o in ds)
            {
                if (o.SanBaoTri)
                {
                    o.TrangThai = TrangThaiO.BaoTri;
                }
                else if (o.MaPhieu.HasValue)
                {
                    DateTime bd = BatDau(ngay, o.GioBatDau);
                    DateTime kt = KetThuc(ngay, o.GioBatDau, o.GioKetThuc);
                    o.TrangThai = (now >= bd && now < kt) ? TrangThaiO.DangDa : TrangThaiO.DaDat;
                }
                else
                {
                    o.TrangThai = TrangThaiO.Trong;
                }
            }
            return ds;
        }

        public KhachHangDTO TimKhach(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return null;
            return dal.TimKhachTheoSDT(sdt.Trim());
        }

        public PhieuDatSanDTO LayPhieu(int maPhieu)
        {
            return dal.LayPhieu(maPhieu);
        }

        public bool DatSan(OSanDTO o, DateTime ngay, string sdt, string ten,
                           decimal tienCoc, string ghiChu, out string loi)
        {
            loi = "";

            if (PhienDangNhap.MaTK <= 0) { loi = "Chưa đăng nhập (PhienDangNhap.MaTK chưa được gán)."; return false; }
            if (o == null) { loi = "Hãy chọn một ô sân trống trên sơ đồ."; return false; }
            if (o.SanBaoTri) { loi = "Sân đang bảo trì."; return false; }
            if (o.MaPhieu.HasValue) { loi = "Khung giờ này đã có người đặt."; return false; }

            sdt = (sdt ?? "").Trim();
            ten = (ten ?? "").Trim();
            if (!Regex.IsMatch(sdt, @"^\d{9,11}$")) { loi = "Số điện thoại phải gồm 9-11 chữ số."; return false; }
            if (ten.Length == 0) { loi = "Vui lòng nhập tên khách hàng."; return false; }
            if (tienCoc < 0 || tienCoc > o.DonGia) { loi = "Tiền cọc phải từ 0 đến đơn giá."; return false; }

            if (KetThuc(ngay, o.GioBatDau, o.GioKetThuc) <= DateTime.Now)
            {
                loi = "Khung giờ này đã qua, không thể đặt.";
                return false;
            }

            KhachHangDTO kh = dal.TimKhachTheoSDT(sdt);
            int maKH = kh != null ? kh.MaKH : dal.ThemKhach(ten, sdt);

            var p = new PhieuDatSanDTO
            {
                MaKH = maKH,
                MaSan = o.MaSan,
                MaTK = PhienDangNhap.MaTK,
                NgayDat = ngay.Date,
                GioBatDau = o.GioBatDau,
                GioKetThuc = o.GioKetThuc,
                DonGia = Math.Round(o.DonGia, 0),
                TienCoc = Math.Round(tienCoc, 0),
                TrangThai = HangSo.PHIEU_DA_DAT,
                GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim()
            };

            if (dal.ThemPhieu(p) == 0)
            {
                loi = "Khung giờ này vừa có người khác đặt. Hãy bấm Tìm Kiếm để tải lại.";
                return false;
            }
            return true;
        }

        public bool HuyPhieu(int maPhieu)
        {
            return dal.HuyPhieu(maPhieu);
        }
    }
}