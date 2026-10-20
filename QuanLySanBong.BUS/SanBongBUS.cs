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

        private SanBongBUS()
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

            int result = SanBongDAL.Instance.Insert(sanBong);

            return result > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "Mã sân không hợp lệ.");
            }

            int result = SanBongDAL.Instance.Delete(id);

            return result > 0;
        }
    }
}