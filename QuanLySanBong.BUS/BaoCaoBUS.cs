using System;
using System.Collections.Generic;
using System.Data;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;

namespace QuanLySanBong.BUS
{
    public class BaoCaoBUS
    {
        private static BaoCaoBUS instance;
        public static BaoCaoBUS Instance
        {
            get { if (instance == null) instance = new BaoCaoBUS(); return instance; }
            private set { instance = value; }
        }

        private BaoCaoBUS() { }

        public DataTable GetDanhSachSanBong()
        {
            return BaoCaoDAL.Instance.GetDanhSachSanBong();
        }

        public List<BaoCaoHoaDonDTO> GetDanhSachHoaDon(DateTime tuNgay, DateTime denNgay, int maSan)
        {
            List<BaoCaoHoaDonDTO> list = new List<BaoCaoHoaDonDTO>();
            DataTable data = BaoCaoDAL.Instance.GetDanhSachHoaDonBaoCao(tuNgay, denNgay, maSan);

            foreach (DataRow item in data.Rows)
            {
                list.Add(new BaoCaoHoaDonDTO(item));
            }

            return list;
        }

        public DataTable GetThongKeDichVu(DateTime tuNgay, DateTime denNgay)
        {
            return BaoCaoDAL.Instance.GetThongKeDichVu(tuNgay, denNgay);
        }
    }
}