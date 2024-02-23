using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _57_61_QuanLyBanSach
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

            Application.Run(new frmMenuMain());


            //Application.Run(new frmnhanvien());
            //Application.Run(new frmnhaxuatban());
            //Application.Run(new frmNhaCungcap());
            //Application.Run(new frmloaisach());
            //Application.Run(new frmhoadonban());
            //Application.Run(new frmTKHoaDonBan());
            //Application.Run(new frmTKHoaDonNhap());
            //Application.Run(new frmTKSach());

            //Application.Run(new frmKhachHang());
            //Application.Run(new frmCTHoaDonNhap());
            //Application.Run(new frmLoaiBia());
            //Application.Run(new frmSach());
            //Application.Run(new frmTacGia());
            //Application.Run(new frmThongKeHDBan());
            //Application.Run(new frmThongKeHDNhap());




        }
    }
}
