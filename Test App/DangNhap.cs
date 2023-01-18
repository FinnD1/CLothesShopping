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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.Net\test UI clothes\Test App\Test App\QuanLyShop.mdf;Integrated Security = True";

        //DOi tuong ket noi
        SqlConnection sqlCon = null;

        SqlDataAdapter adapter = null;

        DataSet ds = null;

        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            MoKetNoi();

            //String sql = "select * from tblNhanVien where MaNV ='" + maTV + "'";
            //adapter = new SqlDataAdapter(sql, sqlCon);
            //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            if (txtTaiKhoan.Text != string.Empty || txtMatKhau.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from tblDangNhap where username='" + txtTaiKhoan.Text + "' and password='" + txtMatKhau.Text + "'", sqlCon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Đăng nhập thành công !", "Form", MessageBoxButtons.OK);
                    dr.Close();
                    this.Hide();
                    GiaoDienChinh khachHang = new GiaoDienChinh();
                    this.Hide();
                    khachHang.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Không tìm thấy tài khoản hoặc mật khẩu không hợp lệ ! Vui Lòng nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Không được để trống !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //MoKetNoi();



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
