using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLySanBong.DAL;

namespace QuanLySanBong.GUI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            try
            {
                DataTable data =
                    DataProvider.Instance.ExecuteQuery(
                        "SELLECT 1 AS KetQua"
                        );
                MessageBox.Show(
                    "Ket Noi SQL Server thanh cong!\n" +
                    "Ket Qua: " + data.Rows[0]["KetQua"],
                    "Thanh Cong"
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ket Noi that bai ! \n" + ex.Message,
                    "Loi SQL Server"
                    );
            }
        

        }
    }
}
