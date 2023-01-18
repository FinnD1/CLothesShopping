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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.Net\test UI clothes\Test App\Test App\QuanLyShop.mdf;Integrated Security = True";

        //DOi tuong ket noi
        SqlConnection sqlCon = null;

        SqlDataAdapter adapter = null;

        DataSet ds = null;

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

        //Ham hien thi DS thành viên
        private void HienThiDSHoaDon()
        {
            MoKetNoi();

            //Cau lenh truy van
            string sql = "select * from tblHDBan";

            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblHoaDon");
            dgvDanhSach.DataSource = ds.Tables["tblHoaDon"];



        }

        private void TimKiemTheoMa(string maHang)
        {
            //Mow ket noi
            MoKetNoi();

            // thuc thi doi tuong truy vấn
            String sql = "select * from tblHDBan where MaHDBan ='" + maHang + "'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblHoaDon");
            dgvDanhSach.DataSource = ds.Tables["tblHoaDon"];
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            HienThiDSHoaDon();

            groupBox4.Enabled=false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tkMa = txtTKMaHD.Text.Trim();

            //Tim Kiem
            if (tkMa == "" )
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm !");
                txtTKMaHD.Focus();
            }
            else if (tkMa != "" )
            {
                TimKiemTheoMa(tkMa);
            }
        }

        private void ThemTV(string maHoaDon,string MaNV,string ngayBan,string maKH,string tong)
        {
            MoKetNoi();

            DataRow row = ds.Tables["tblHoaDon"].NewRow();
            row["MaHDBan"] = maHoaDon;
            row["MaNV"] = MaNV;
            row["NgayBan"] = ngayBan;
            row["MaKH"] = maKH;
            row["TongTien"] = tong;

            ds.Tables["tblHoaDon"].Rows.Add(row);

            int kq = adapter.Update(ds.Tables["tblHoaDon"]);
            if (kq > 0)
            {
                MessageBox.Show("Thêm hoá đơn thành công!", "Thông báo");
                HienThiDSHoaDon();
            }
            else
                MessageBox.Show("Thêm hoá đơn thất bại!", "Thông báo");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;

            chucnang = 1;
        }
        //Bien kiem tra chuc nang
        int chucnang = 0;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucnang == 1)
            {
                // Lay du lieu tu giao dien
                string maHoaDon = txtMaHD.Text.Trim();
                string maNV = txtMaNV.Text.Trim();
                string ngayBan = dtpNgayBan.Value.Year + "/" + dtpNgayBan.Value.Month + "/" + dtpNgayBan.Value.Day;
                string maKH = txtMaKH.Text.Trim();
                string tong = txtTongTien.Text.Trim();

                ThemTV(maHoaDon, maNV, ngayBan, maKH, tong);
            }
            else if (chucnang == 2)
            {
                if (vtri == -1) return;

                DataRow row = ds.Tables["tblHoaDon"].Rows[vtri];

                row.BeginEdit();
                row["MaHDBan"] = txtMaHD.Text.Trim();
                row["MaNV"] = txtMaNV.Text.Trim();
                row["NgayBan"] = dtpNgayBan.Value.ToString("MM/dd/yyyy"); ;
                row["MaKH"] = txtMaKH.Text.Trim();
                row["TongTien"] = txtTongTien.Text.Trim();
                row.EndEdit();

                int kq = adapter.Update(ds.Tables["tblHoaDon"]);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thông tin hoá đơn thành công!", "Thông báo");
                    HienThiDSHoaDon();

                    //HuyKH();
                    //btnSua.Enabled = false;
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sửa thông tin sản phẩm thất bại!", "Thông báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            chucnang = 2;
        }

        //Tao bien chua vi tri click
        int vtri = -1;

        private void btnHTDS_Click(object sender, EventArgs e)
        {
            HienThiDSHoaDon();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
            GiaoDienChinh dn = new GiaoDienChinh();
            dn.ShowDialog();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vtri = e.RowIndex;
            if (vtri == -1) return;
            DataRow row = ds.Tables["tblHoaDon"].Rows[vtri];
            txtMaHD.Text = row["MaHDBan"].ToString();
            txtMaNV.Text = row["MaNV"].ToString();
            string[] ns = row["NgayBan"].ToString().Split('/');
            dtpNgayBan.Value = new DateTime(int.Parse(ns[2].Substring(0, 4)), int.Parse(ns[1]), int.Parse(ns[0]));
            txtMaKH.Text = row["MaKH"].ToString();
            txtTongTien.Text = row["TongTien"].ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["tblHoaDon"].Rows[vtri];
            row.Delete();
            int kq = adapter.Update(ds.Tables["tblHoaDon"]);
            if (kq > 0)
            {
                MessageBox.Show("Xóa hoá đơn thành công!", "Thông báo");
                HienThiDSHoaDon();
            }
            else
            {
                MessageBox.Show("Xóa hoá đơn thất bại!", "Thông báo");
            }
        }
    }
}
