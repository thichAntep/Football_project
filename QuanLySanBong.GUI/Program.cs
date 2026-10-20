
using System;
using System.Windows.Forms;

namespace QuanLySanBong.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormDangNhap());
        }
    }
}