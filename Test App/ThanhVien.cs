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
    public partial class ThanhVien : Form
    {
        public ThanhVien()
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
                MessageBox.Show("ket noi thanh cong!");

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

        private void TimKiemTheoMa(string maTV)
        {
            //Mow ket noi
            MoKetNoi();

            //Thuc thi doi tuong truy van

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType= CommandType.Text;
            sqlCmd.CommandText= "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tkMatv = tkMaTV.Text.Trim();
            string tkTentv=tkMaTV.Text.Trim();

            //Tim Kiem
            if (tkMatv == "" && tkTentv == "")
            {
                MessageBox.Show("Chua nhap thong tin tim kiem !");
            }
            else if (tkMatv != "" && tkTentv == "")
            {
                TimKiemTheoMa(tkMatv);
            }
            else if (tkMatv == "" && tkTentv != "")
            {
                TimKiemTheoTen(tkMatv);
            }
            else if (tkMatv != "" && tkTentv != "")
            {
                TimKiemTheoMa(tkMatv);
            }
        }
    }
}
