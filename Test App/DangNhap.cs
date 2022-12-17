using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
        
             //MoKetNoi();

            GiaoDienChinh khachHang = new GiaoDienChinh();
            this.Hide();
            khachHang.ShowDialog();
        
        }
    }
}
