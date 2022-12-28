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
        private void HienThiDSThanhVien()
        {
            MoKetNoi();

            //Cau lenh truy van
            string sql = "select * from tblNhanVien";

            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblNhanVien");
            dgvThanhVien.DataSource = ds.Tables["tblNhanVien"];
        }

        private void TimKiemTheoMa(string maTV)
        {
            //Mow ket noi
            MoKetNoi();

            // thuc thi doi tuong truy vấn
            String sql = "select * from tblNhanVien where MaNV ='" + maTV + "'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblTV");
            dgvThanhVien.DataSource = ds.Tables["tblTV"];
        }

        private void TimKiemTheoTen(string ten)
        {
            String sql = "select *FROM tblNhanVien where TenNV like N'%" + ten + "%'";
            adapter = new SqlDataAdapter(sql, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "tblTV");
            dgvThanhVien.DataSource = ds.Tables["tblTV"];
        }

        private void ThemTV(string maTV, string tenTV, string ngaySinh, string gt, string diaChi, string sdt)
        {
            MoKetNoi();

            DataRow row = ds.Tables["tblNhanVien"].NewRow();
            row["MaNV"] = maTV;
            row["TenNV"] = tenTV;
            row["NgaySinh"] = ngaySinh;
            row["GioiTinh"] = gt;
            row["DiaChi"] = diaChi;
            row["SDT"] = sdt;

            ds.Tables["tblNhanVien"].Rows.Add(row);

            int kq = adapter.Update(ds.Tables["tblNhanVien"]);
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành viên thành công!", "Thông báo");
                HienThiDSThanhVien();
            }
            else
                MessageBox.Show("Thêm thành viên thất bại!", "Thông báo");

        }

        private void HuyKH()
        {
            txtMaTV.Text = "";
            txtTenTV.Text = "";
            cbGioiTinh.Text = "";
            txtDiaChi.Text = "";
            mtbSDT.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tkMatv = tkMaTV.Text.Trim();
            string tkTentv = tkTenTV.Text.Trim();

            //Tim Kiem
            if (tkMatv == "" && tkTentv == "")
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm !");
                tkMaTV.Focus();
            }
            else if (tkMatv != "" && tkTentv == "")
            {
                TimKiemTheoMa(tkMatv);
            }
            else if (tkMatv == "" && tkTentv != "")
            {
                TimKiemTheoTen(tkTentv);
            }
            else if (tkMatv != "" && tkTentv != "")
            {
                TimKiemTheoMa(tkMatv);               
            }
        }

        private void ThanhVien_Load(object sender, EventArgs e)
        {
            HienThiDSThanhVien();
            groupBox1.Enabled= false;

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
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
                string maKH = txtMaTV.Text.Trim();
                string tenKH = txtTenTV.Text.Trim();
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

                ThemTV(maKH, tenKH, ngaySinh, gt, diaChi, sdt);
            }
            else if (chucnang == 2)
            {
                if (vtri == -1) return;

                DataRow row = ds.Tables["tblNhanVien"].Rows[vtri];

                row.BeginEdit();
                row["MaNV"] = txtMaTV.Text.Trim();
                row["TenNV"] = txtTenTV.Text.Trim();
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
                    MessageBox.Show("Sửa thông tin thành viên thành công!", "Thông báo");
                    HienThiDSThanhVien();

                    HuyKH();
                    //btnSua.Enabled = false;
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Sửa thông tin thành viên thất bại!", "Thông báo");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HuyKH();
            groupBox1.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            chucnang = 2;
        }

        //Tao bien chua vi tri click
        int vtri = -1;

        private void dgvThanhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vtri = e.RowIndex;
            if (vtri == -1) return;
            DataRow row = ds.Tables["tblNhanVien"].Rows[vtri];
            txtMaTV.Text = row["MaNV"].ToString();
            txtTenTV.Text = row["TenNV"].ToString();
            string gioiTinh = row["GioiTinh"].ToString();
            if (gioiTinh == "Nam")
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else if (gioiTinh == "Nữ")
            {
                cbGioiTinh.SelectedIndex = 1;
            }
            string[] ns = row["NgaySinh"].ToString().Split('/');
            dtpNgaySinh.Value = new DateTime(int.Parse(ns[2].Substring(0, 4)), int.Parse(ns[0]), int.Parse(ns[1]));
            txtDiaChi.Text = row["DiaChi"].ToString();
            mtbSDT.Text = row["SDT"].ToString();
        }

        private void XoaKH()
        {
            DataRow row = ds.Tables["tblNhanVien"].Rows[vtri];
            row.Delete();
            int kq = adapter.Update(ds.Tables["tblNhanVien"]);
            if (kq > 0)
            {
                MessageBox.Show("Xóa thành viên thành công!", "Thông báo");
                HienThiDSThanhVien();
            }
            else
            {
                MessageBox.Show("Xóa thành viên thất bại!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            if (vtri == -1) return;
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                XoaKH();
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
            GiaoDienChinh dn = new GiaoDienChinh();
            dn.ShowDialog();
        }
    }
}
