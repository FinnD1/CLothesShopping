using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App
{
    public partial class GiaoDienChinh : Form
    {
        public GiaoDienChinh()
        {
            InitializeComponent();
        }

        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.Net\test UI clothes\Test App\Test App\QuanLyShop.mdf;Integrated Security = True";

        //DOi tuong ket noi
        SqlConnection sqlCon = null;

        //ham mo ket noi
        private void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        //Ham dong ket noi
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            MoKetNoi();

            ThanhVien thanhVien = new ThanhVien();
            this.Hide();
            thanhVien.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            MoKetNoi();

            KhachHang khachHang = new KhachHang();
            this.Hide();
            khachHang.ShowDialog();
        }

        private void btnQuanAo_Click(object sender, EventArgs e)
        {
            MoKetNoi();

            QuanAo quanAo = new QuanAo();
            this.Hide();
            quanAo.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MoKetNoi();

            HoaDon quanAo = new HoaDon();
            this.Hide();
            quanAo.ShowDialog();
        }
    }
}
