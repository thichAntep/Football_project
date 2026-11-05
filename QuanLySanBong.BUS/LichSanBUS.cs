using QuanLySanBong.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using QuanLySanBong.DAL;
namespace QuanLySanBong.BUS;

public class LichSanBUS
{
    public DataTable GetLichTheoNgay(DateTime Ngay)
    {
        return LichSanDAL.Instance.GetLichTheoNgay(Ngay);
    
}

}
