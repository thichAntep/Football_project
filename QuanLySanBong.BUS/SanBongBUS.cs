using System;
using System.Data;
using QuanLySanBong.DAL;
using QuanLySanBong.DTO;

namespace QuanLySanBong.BUS
{
    public class SanBongBUS
    {
        private static SanBongBUS instance;

        public static SanBongBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanBongBUS();
                }

                return instance;
            }
        }

        public SanBongBUS()
        {
        }

        public DataTable GetAll()
        {
            return SanBongDAL.Instance.GetAll();
        }

        public bool Insert(SanBongDTO sanBong)
        {
            if (sanBong == null)
            {
                throw new ArgumentException(
                    "Dữ liệu sân bóng không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(sanBong.TenSan))
            {
                throw new ArgumentException(
                    "Vui lòng nhập tên sân.");
            }

            if (sanBong.LoaiSanID <= 0)
            {
                throw new ArgumentException(
                    "Vui lòng chọn loại sân.");
            }

            if (sanBong.GiaThue <= 0)
            {
                throw new ArgumentException(
                    "Giá thuê phải lớn hơn 0.");
            }

            int result = SanBongDAL.Instance.Insert(sanBong.TenSan,sanBong.ID,sanBong.TrangThai);

            return result > 0;
        }

        public bool Delete(SanBongDTO sanBong)
        {
            
            if (sanBong.ID <= 0)
            {
                throw new ArgumentException(
                    "Mã sân không hợp lệ.");
            }

            int result = SanBongDAL.Instance.DeleteIfNoKhungGio(sanBong.LoaiSanID);

            return result > 0;
        }
        public int SoSanBongTrong()
        {
            return new SanBongDAL().LaySanBongDangTrong();
        }
    }
}