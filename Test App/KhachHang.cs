using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test_App
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        //ChuoiKetNoi
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\BTL_C#\CLothesShopping\CodeKH\Test App\QuanLyQuanAo.mdf"";Integrated Security=True";

        //Doi tuong ket noi
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;

        //Ham mo ket noi
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

        //Ham Hien Thi Danh sach khach hang
        private void HienThiDSKH()
        {
            MoKetNoi();

            //Cau lenh truy van
            string sql = "SELECT * FROM tblKhachHang";

            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblKhachHang");
            dgvDSKH.DataSource = ds.Tables["tblKhachHang"];
        }

        //Ham TimKiemMaKH
        private void TimKiemTheoMaKH(string TkMaKH)
        {
            MoKetNoi();
            String sql = "SELECT *FROM tblKhachHang WHERE MaKH ='" + TkMaKH + "'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblTk");
            dgvDSKH.DataSource = ds.Tables["tblTk"];
        }

        //Ham TimKiemTheoTenKH
        private void TimKiemTheoTenKH(string TkTenKH)
        {
            String sql = "SELECT *FROM tblKhachHang WHERE TenKH LIKE '%" + TkTenKH + "%'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblTk");
            dgvDSKH.DataSource = ds.Tables["tblTk"];
        }

        private void ThemKH(string maKH, string tenKH, string ngaySinh, string gt, string diaChi, string sdt)
        {
            MoKetNoi();

            DataRow row = ds.Tables["tblKhachHang"].NewRow();
            row["MaKH"] = maKH;
            row["TenKH"] = tenKH;
            row["NgaySinh"] = ngaySinh;
            row["GioiTinh"] = gt;
            row["DiaChi"] = diaChi;
            row["SDT"] = sdt;

            ds.Tables["tblKhachHang"].Rows.Add(row);

            int kq = adapter.Update(ds.Tables["tblKhachHang"]);
            if (kq > 0)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                HienThiDSKH();
            }
            else
                MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo");

        }

        private void HuyKH()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            cbGioiTinh.Text = "";
            txtDiaChi.Text = "";
            mtbSDT.Text = "";
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSKH();
            groupBox1.Enabled = false;
            //btnLuu.Enabled = false;
            //btnHuy.Enabled = false;

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Lay du lieu tu giao dien
            string TkMaKH = txtTkMaKH.Text.Trim();
            string TkTenKH = txtTkTenKH.Text.Trim();

            //Tim kiem
            if (TkMaKH == "" && TkTenKH == "")
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng trống!");
                txtTkMaKH.Focus();
            }

            else if (TkMaKH != "" && TkTenKH == "")
            {
                TimKiemTheoMaKH(TkMaKH);
            }

            else if (TkMaKH == "" && TkTenKH != "")
            {
                TimKiemTheoTenKH(TkTenKH);
            }

            else if (TkMaKH != "" && TkTenKH != "")
            {
                TimKiemTheoMaKH(TkMaKH);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;

            chucNang = 1;
        }

        // Bien kiem tra su dung chuc nang gi
        int chucNang = 0;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(chucNang == 1)
            {
                // Lay du lieu tu giao dien
                string maKH = txtMaKH.Text.Trim();
                string tenKH = txtTenKH.Text.Trim();
                string ngaySinh = dtpNgaySinh.Value.Year + "/" + dtpNgaySinh.Value.Month + "/" + dtpNgaySinh.Value.Day;
                string gt = "";
                if (cbGioiTinh.SelectedIndex == 0)
                {
                    gt = "Nam";
                }
                else if (cbGioiTinh.SelectedIndex == 1)
                {
                    gt = "Nữ";
                }
                string diaChi = txtDiaChi.Text.Trim();
                string sdt = mtbSDT.Text.Trim();

                ThemKH(maKH, tenKH, ngaySinh, gt, diaChi, sdt);
            }
            else if(chucNang == 2)
            {
                if(vtri == -1) return;

                DataRow row = ds.Tables["tblKhachHang"].Rows[vtri];

                row.BeginEdit();
                row["MaKH"] = txtMaKH.Text.Trim();
                row["TenKH"] =txtTenKH.Text.Trim();
                if (cbGioiTinh.SelectedIndex == 0)
                {
                    row["GioiTinh"] = "Nam";
                }
                else if (cbGioiTinh.SelectedIndex == 1)
                {
                    row["GioiTinh"] = "Nữ";
                }
                row["NgaySinh"] = dtpNgaySinh.Value.ToString("MM/dd/yyyy");
                row["DiaChi"] = txtDiaChi.Text.Trim();
                row["SDT"] = mtbSDT.Text.Trim();
                row.EndEdit();

                int kq = adapter.Update(ds.Tables["tblKhachHang"]);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo");
                    HienThiDSKH();

                    HuyKH();
                    //btnSua.Enabled = false;
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sửa thông tin khách hàng thất bại!", "Thông báo");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HuyKH();
            groupBox1.Enabled=false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            chucNang = 2;
        }

        //Tao bien chua vi tri click
        int vtri = -1;

        private void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vtri = e.RowIndex;
            if (vtri == -1) return;
            DataRow row = ds.Tables["tblKhachHang"].Rows[vtri];
            txtMaKH.Text = row["MaKH"].ToString();
            txtTenKH.Text = row["TenKH"].ToString();
            string gioiTinh = row["GioiTinh"].ToString();
            if (gioiTinh == "Nam")
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else if (gioiTinh == "Nữ")
            { 
                cbGioiTinh.SelectedIndex = 1;
            }
            string[] ngaySinh = row["NgaySinh"].ToString().Split('/');
            dtpNgaySinh.Value = new DateTime(int.Parse(ngaySinh[2].Substring(0, 4)), int.Parse(ngaySinh[0]), int.Parse(ngaySinh[1]));
            txtDiaChi.Text = row["DiaChi"].ToString();
            mtbSDT.Text = row["SDT"].ToString();

        }

        private void XoaKH()
        {
            DataRow row = ds.Tables["tblKhachHang"].Rows[vtri];
            row.Delete();
            int kq = adapter.Update(ds.Tables["tblKhachHang"]);
            if(kq > 0)
            {
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo");
                HienThiDSKH();
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại!", "Thông báo");
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            if(vtri == -1) return;
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?","Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                XoaKH();
            }
            else
            {
                btnXoa.Enabled = false;
            }    
        }

        private void txtMaKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
