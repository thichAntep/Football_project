using System;
using System.Collections.Generic;
using System.Text;
using QuanLySanBong.DAL;
namespace QuanLySanBong.BUS
{
    public class KhachHangBUS
    {
        public int LaySoKhachHangCho()
        {
            return new KhachHangDAL().KhachHangDangCho();
        }
    }
}
