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
    public partial class QuanAo : Form
    {
        public QuanAo()
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
        private void HienThiDSQuanAo()
        {
            MoKetNoi();

            //Cau lenh truy van
            string sql = "select * from tblQuanAo";

            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblHangHoa");
            dgvQuanAo.DataSource = ds.Tables["tblHangHoa"];
        }

        private void TimKiemTheoMa(string maHang)
        {
            //Mow ket noi
            MoKetNoi();

            // thuc thi doi tuong truy vấn
            String sql = "select * from tblQuanAo where MaHang ='" + maHang + "'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblHangHoa");
            dgvQuanAo.DataSource = ds.Tables["tblHangHoa"];
        }

        private void TimKiemTheoTen(string ten)
        {
            String sql = "select * FROM tblHangHoa where TenHang like N'%" + ten + "%'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblHangHoa");
            dgvQuanAo.DataSource = ds.Tables["tblHangHoa"];
        }

        private void ThemTV(string maHang, string tenHang, string kc, string soLuong, string giaNhap, string giaBan,string anh, string ghiChu)
        {
            MoKetNoi();

            DataRow row = ds.Tables["tblHangHoa"].NewRow();
            row["MaHang"] = maHang;
            row["TenHang"] = tenHang;
            row["KichCo"] = kc;
            row["SoLuong"] = soLuong;
            row["GiaNhap"] = giaNhap;
            row["GiaBan"] = giaBan;
            row["Anh"]=anh;
            row["GhiChu"] = ghiChu;

            ds.Tables["tblHangHoa"].Rows.Add(row);

            int kq = adapter.Update(ds.Tables["tblHangHoa"]);
            if (kq > 0)
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");
                HienThiDSQuanAo();
            }
            else
                MessageBox.Show("Thêm sản phẩm thất bại!", "Thông báo");

        }

        //private void HuyKH()
        //{
        //    txtMaTV.Text = "";
        //    txtTenTV.Text = "";
        //    cbGioiTinh.Text = "";
        //    txtDiaChi.Text = "";
        //    mtbSDT.Text = "";
        //}
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //txtMaHang.Enabled = true;
            //txtTenHang.Enabled = true;
            //cbKichCo.Enabled= true;
            string tkMa = txtMaHang.Text.Trim();
            string tkTen = txtTenHang.Text.Trim();

            //Tim Kiem
            if (tkMa == "" && tkTen == "")
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm !");
                txtMaHang.Focus();
            }
            else if (tkMa != "" && tkTen == "")
            {
                TimKiemTheoMa(tkMa);
            }
            else if (tkMa == "" && tkTen != "")
            {
                TimKiemTheoTen(tkTen);
            }
            else if (tkMa != "" && tkTen != "")
            {
                TimKiemTheoMa(tkMa);
            }
        }

        
        
        private void QuanAo_Load(object sender, EventArgs e)
        {
            HienThiDSQuanAo();

            //groupBox1.Enabled = false;

            cbKichCo.Items.Add("S");
            cbKichCo.Items.Add("M");
            cbKichCo.Items.Add("L");
            cbKichCo.Items.Add("XL");
            cbKichCo.Items.Add("2XL");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;

            chucnang = 1;
        }

        //Bien kiem tra chuc nang
        int chucnang = 0;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucnang == 1)
            {
                // Lay du lieu tu giao dien
                string maHang = txtTenHang.Text.Trim();
                string tenHang = txtTenHang.Text.Trim();
                string kc = "";
                if (cbKichCo.SelectedIndex == 0)
                {
                    kc = "S";
                }
                else if (cbKichCo.SelectedIndex == 1)
                {
                    kc = "M";
                }
                else if (cbKichCo.SelectedIndex == 2)
                {
                    kc = "L";
                }
                else if (cbKichCo.SelectedIndex == 3)
                {
                    kc = "XL";
                }
                else if (cbKichCo.SelectedIndex == 4)
                {
                    kc = "2XL";
                }
                string soLuong = txtSoLuong.Text.Trim();
                string giaNhap = txtGiaNhap.Text.Trim();
                string giaBan = txtGiaBan.Text.Trim();
                string anh=txtLinkAnh.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                ThemTV(maHang, tenHang, kc, soLuong, giaNhap, giaBan,anh,ghiChu);
            }
            else if (chucnang == 2)
            {
                if (vtri == -1) return;

                DataRow row = ds.Tables["tblHangHoa"].Rows[vtri];

                row.BeginEdit();
                row["MaHang"] = txtMaHang.Text.Trim();
                row["TenHang"] = txtTenHang.Text.Trim();
                if (cbKichCo.SelectedIndex == 0)
                {
                    row["KickCo"] = "S";
                }
                else if (cbKichCo.SelectedIndex == 1)
                {
                    row["KickCo"] = "M";
                }
                else if (cbKichCo.SelectedIndex == 2)
                {
                    row["KickCo"] = "L";
                }
                else if (cbKichCo.SelectedIndex == 3)
                {
                    row["KickCo"] = "XL";
                }
                else if (cbKichCo.SelectedIndex == 4)
                {
                    row["KickCo"] = "2XL";
                }
                row["SoLuong"] = txtSoLuong.Text.Trim();
                row["GiaNhap"] = txtGiaNhap.Text.Trim();
                row["GiaBan"] = txtGiaBan.Text.Trim();
                row["Anh"] = txtLinkAnh.Text.Trim();
                row["GhiChu"] = txtGhiChu.Text.Trim();
                row.EndEdit();

                int kq = adapter.Update(ds.Tables["tblHangHoa"]);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thông tin sản phẩm thành công!", "Thông báo");
                    HienThiDSQuanAo();

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
            HienThiDSQuanAo();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
            GiaoDienChinh dn = new GiaoDienChinh();
            dn.ShowDialog();
        }

        private void dgvQuanAo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vtri = e.RowIndex;
            if (vtri == -1) return;
            DataRow row = ds.Tables["tblHangHoa"].Rows[vtri];
            txtMaHang.Text = row["MaHang"].ToString();
            txtTenHang.Text = row["TenHang"].ToString();
            string kc = row["KichCo"].ToString();
            if (kc == "S")
            {
                cbKichCo.SelectedIndex = 0;
            }
            else if (kc == "M")
            {
                cbKichCo.SelectedIndex = 1;
            }
            else if (kc == "L")
            {
                cbKichCo.SelectedIndex = 2;
            }
            else if (kc == "XL")
            {
                cbKichCo.SelectedIndex = 3;
            }
            else if (kc == "2XL")
            {
                cbKichCo.SelectedIndex = 4;
            }
            txtSoLuong.Text = row["SoLuong"].ToString();
            txtGiaNhap.Text = row["GiaNhap"].ToString();
            txtGiaBan.Text = row["GiaBan"].ToString();
            txtLinkAnh.Text = row["Anh"].ToString();
            txtGhiChu.Text = row["GhiChu"].ToString();
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtLinkAnh.Text = dlgOpen.FileName;
            }
        }
    }
}
