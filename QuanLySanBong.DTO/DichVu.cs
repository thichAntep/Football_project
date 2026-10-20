using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanBong.DTO
{
    public  class DichVu
    {
        
        // thuộc tính (property của class DichVu)
        public int MaDV { get; set; }
        /*
         * public (private , protected,internal) phạm vi truy cập (Access Modifier) -> quy định nơi nào có thể truy cập vào class hoặc method
         * với public thì có thể truy cập từ bất kỳ đâu
         * int là kiểu 
         */
        public string TenDV { get; set; } // thuộc tính (property) Là thông tin của đối tượng (cung cấp cách đọc và ghi dự liệu )
        // 

        public string DVT { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        /*
         Một Số lưu ý 
         Một property structer: public int PropertyName{ get ; set ;}
         Property chỉ Đọc: public int PropertyName{get;}
         Property chỉ Ngi : public int ProperyName(set;)
        */
        /*
         B1:  tạo 1 property mới name_Class name_value = new name_Class();
         Cách Gán giá trị 
         B2: name_value.name_Property = value:
         Cách Lấy Giá trị:
         Console.WriteLine(name_value.name_Property)
         
        */

    }
}
