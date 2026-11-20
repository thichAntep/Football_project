using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySanBong.GUI
{
    public partial class Form_Main : Form
    {
        ucHoaDon HoaDon = new ucHoaDon();
        ucTrangChu TrangChu = new ucTrangChu();
        ucDatSan DatSan = new ucDatSan();
        ucDichVu DichVu = new ucDichVu();
        public Form_Main()
        {
            InitializeComponent();
        }


        private void Form_Main_Load(object sender, EventArgs e)
        {
            btnTrangChu_Click(sender, e);
        }
        private void btnThemSan_Click(object sender, EventArgs e)
        {
            using (FormThemSan f = new FormThemSan())
            {
                f.ShowDialog();
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            TrangChu.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(TrangChu);

        }
        private void btnDatSan_Click(object sender,EventArgs e)
        {
            pnlContent.Controls.Clear();
            DatSan.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(DatSan);
        }
        private void btnDichuVu_Click(object sender,EventArgs e)
        {
            pnlContent.Controls.Clear();
            DichVu.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(DichVu);

        }
        private void btnHoaDon_Click(object sender,EventArgs e)
        {
            pnlContent.Controls.Clear();
            HoaDon.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(HoaDon);
        }
    }
}
