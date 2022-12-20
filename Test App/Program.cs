using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//<<<<<<< HEAD
            Application.Run(new DangNhap());
//=======
            //Application.Run(new KhachHang());
            //Application.Run(new ThanhVien());
//>>>>>>> bede6ffa2911694d2a151b6aa2a1ee24e96d1372
        }
    }
}
