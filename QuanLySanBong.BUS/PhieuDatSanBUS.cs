using System;
using System.Collections.Generic;
using System.Text;
using QuanLySanBong.DAL;
namespace QuanLySanBong.BUS
{
    public class PhieuDatSanBUS
    {
        public int LaySoSanDaDatHomNay()
        {
            return new PhieuDatSanDAL().DemSanDatHomNay();
        }
    }
}
