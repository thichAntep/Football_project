using System;
using System.Data;
using Microsoft.Data.SqlClient;//Cung cấp các lớp kết nối SQL Server như SqlConnection, SqlCommand,SqlParameter
                             // Nếu dùng .NET mới thì cài NuGet: Microsoft.Data.SqlClient

namespace QuanLySanBong.DAL
{
    public class DataProvider
    {
        // 1 Field (trường dữ liệu)  connectionSTR =  "..." 
        /*
         Phạm Vi: private (vì chuỗi kết nối không cần thay đổi )
        */
        private string connectionSTR = @"Server=.;Database=QuanLySanBong;Trusted_Connection=True;TrustServerCertificate=True;";
        /*
         Phạm Vi: private(chỉ truy cập bên trong class)
         thuộc tính : static 
         kiểu dữ liệu là DataProvider */
        private static DataProvider instance; // 1 field (Trường dữ liệu)
        public static DataProvider Instance // 1 property Không phải method
        {
            get { 
                /*
                 Kiểm tra xem instance đã có chưa nếu chưa tạo 1 đối đượng mới */
                if (instance == null) 
                    instance = new DataProvider(); 
                return instance; // Trả về đổi tượng đc lưu 
            }
            private set
            {
                instance = value;
            }
        }

        private DataProvider() { } // 1 contructer

        // Dùng cho câu lệnh SELECT (trả về bảng dữ liệu DataTable)
        public DataTable ExecuteQuery( 
            string query,                       // Tham số chứa câu lệnh SQL
            SqlParameter[] parameters = null)   //  Mảng các tham số SQL nếu ko truyền vào mặc định là null
        {   // Câu lệnh SqlParameter-> truyền giá trị tham số vào câu SQL
            DataTable data = new DataTable();   // Tạo 1 đối tượng DataTable để chứa kết quả truy vấn
            // Tạo kết nối với SQL SERVER
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open(); // Mở Kết nối    // query là câu lệnh cần thưc hiện // connection là đường kết nối đến server
                SqlCommand command = new SqlCommand(query, connection); // SqlCommand 1 class trong thư viện Microsoft.Data.SqlClient 
                // SqlCommand dùng để gửi và thực thi câu lệnh 
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        // Dùng cho câu lệnh INSERT, UPDATE, DELETE (trả về số dòng bị ảnh hưởng)
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection); 
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                data = command.ExecuteNonQuery();
            }
            return data;
        }
    }
}