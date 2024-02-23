using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace _57_61_QuanLyBanSach
{
    public partial class frmMenuMain : Form
    {
        private IconButton currentBtn;
        private IconButton currentBtn_child;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private Timer timer = new Timer();
        private Random random = new Random();
        private string[] files;

        public frmMenuMain()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            customizeDesing();
            timerHome.Start();

            // Nền trong suốt
            lblbackcolor();

            // Ảnh ngẫu nhiên
            showImageRamdom();
        }

        

        private struct RGBDColors
        {
            public static Color color1 = Color.FromArgb(183, 19, 117);
            public static Color color2 = Color.FromArgb(252, 41, 71);
            public static Color color3 = Color.FromArgb(225, 18, 153);
            public static Color color4 = Color.FromArgb(31, 138, 112);
            public static Color color5 = Color.FromArgb(147, 132, 209);
            public static Color color6 = Color.FromArgb(201, 167, 235);
        }

        private void customizeDesing()
        {
            panelsub1.Visible = false;
            panelsub2.Visible = false;
            panelsub3.Visible = false;
            panelsub4.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelsub1.Visible == true)
                panelsub1.Visible = false;
            if (panelsub2.Visible == true)
                panelsub2.Visible = false;
            if (panelsub3.Visible == true)
                panelsub3.Visible = false;
            if (panelsub4.Visible == true)
                panelsub4.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void ActivateButton(object senderBtn, Color color, int location)
        {
            if(senderBtn != null)
            {
                DisablieButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(246, 255, 222);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                borderbtn(color, location);

                iconCurrentChild.IconChar = currentBtn.IconChar;
                iconCurrentChild.IconColor = color;
            }
        }

        private void borderbtn(Color color, int a)
        {
            leftBorderBtn.BackColor = color;
            leftBorderBtn.Location = new Point(0, a);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
        }

        private void ActivateButton_child(object senderBtn, Color color, int location)
        {
            if (senderBtn != null)
            {
                DisablieButton_child();

                currentBtn_child = (IconButton)senderBtn;
                currentBtn_child.BackColor = Color.FromArgb(182, 234, 250);
                currentBtn_child.ForeColor = color;
                currentBtn_child.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn_child.IconColor = color;
                currentBtn_child.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn_child.ImageAlign = ContentAlignment.MiddleRight;

                borderbtn(color, location);

                iconCurrentChild.IconChar = currentBtn_child.IconChar;
                iconCurrentChild.IconColor = color;
            }
        }

        private void DisablieButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 67);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void DisablieButton_child()
        {
            if (currentBtn_child != null)
            {
                currentBtn_child.BackColor = Color.FromArgb(54, 33, 74);
                currentBtn_child.ForeColor = Color.Gainsboro;
                currentBtn_child.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn_child.IconColor = Color.Gainsboro;
                currentBtn_child.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn_child.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblFormTitle.Text = childForm.Text;
            
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            hideSubMenu();
            Reset();
        }

        private void Reset()
        {
            DisablieButton();
            DisablieButton_child();
            leftBorderBtn.Visible = false;
            iconCurrentChild.IconChar = IconChar.Home;
            iconCurrentChild.IconColor = Color.MediumPurple;
            lblFormTitle.Text = "Home";
            txtTimKiem.Text = "";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWindow_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // SÁCH - LOẠI SÁCH - LOẠI BÌA - TÁC GIẢ

        private void btnSach_Click(object sender, EventArgs e)
        {
            int location = 137;
            showSubMenu(panelsub1);

            ActivateButton(sender, RGBDColors.color1, location);
        }

        private void btnCTSach_Click(object sender, EventArgs e)
        {
            int location = 197;
            ActivateButton_child(sender, RGBDColors.color2, location);

            OpenChildForm(new frmSach());
        }

        private void btnLoaiSach_Click(object sender, EventArgs e)
        {
            int location = 257;
            ActivateButton_child(sender, RGBDColors.color3, location);

            OpenChildForm(new frmloaisach());
        }

        private void btnBiaSach_Click(object sender, EventArgs e)
        {
            int location = 317;
            ActivateButton_child(sender, RGBDColors.color4, location);

            OpenChildForm(new frmLoaiBia());
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            int location = 377;
            ActivateButton_child(sender, RGBDColors.color5, location);

            OpenChildForm(new frmTacGia());

        }

        // HÓA ĐƠN BÁN - HÓA ĐƠN NHẬP

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            int location = 197;
            ActivateButton(sender, RGBDColors.color1, location);

            showSubMenu(panelsub2);

        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            int location = 257;
            ActivateButton_child(sender, RGBDColors.color2, location);

            OpenChildForm(new frmhoadonban());

        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            int location = 317;
            ActivateButton_child(sender, RGBDColors.color3, location);

            OpenChildForm(new frmCTHoaDonNhap());

        }

        // NHÂN VIÊN

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            int location = 257;
            ActivateButton(sender, RGBDColors.color1, location);

            OpenChildForm(new frmnhanvien());
            hideSubMenu();

        }

        // KHÁCH HÀNG

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            int location = 317;
            ActivateButton(sender, RGBDColors.color1, location);

            OpenChildForm(new frmKhachHang());
            hideSubMenu();

        }

        // NHÀ CUNG CẤP - NHÀ SẢN XUẤT

        private void btnNhaXuatBan_Click(object sender, EventArgs e)
        {
            int location = 377;
            ActivateButton(sender, RGBDColors.color1, location);

            showSubMenu(panelsub3);

        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            int location = 437;
            ActivateButton_child(sender, RGBDColors.color5, location);

            OpenChildForm(new frmNhaCungcap());
        }

        private void btnNhaSanXuat_Click(object sender, EventArgs e)
        {
            int location = 497;
            ActivateButton_child(sender, RGBDColors.color3, location);

            OpenChildForm(new frmnhaxuatban());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int location = 22;
            ActivateButton_child(sender, RGBDColors.color1, location);

            string str = RemoveSign4VietnameseString(txtTimKiem.Text);
            str = str.ToLower();
            str = str.Trim();
            str = Regex.Replace(str, @"\s+", "");

            if(str == "hoadonban" || str == "timkiemhoadonnhap")
            {
                frmTKHoaDonBan f = new frmTKHoaDonBan();
                txtTimKiem.Text = "";
                f.ShowDialog();
            }
            else if (str == "hoadonnhap" || str == "timkiemhoadonnhap")
            {
                frmTKHoaDonNhap f = new frmTKHoaDonNhap();
                txtTimKiem.Text = "";
                f.ShowDialog();
            }
            else if(str == "sach" || str == "timkiemsach")
            {
                frmTKSach f = new frmTKSach();
                txtTimKiem.Text = "";
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bảng cẩn tìm không có! Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtTimKiem.Text = "";
                txtTimKiem.Focus();
            }


            str = "";

            hideSubMenu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int location = 22;
            showSubMenu(panelsub4);
            ActivateButton_child(sender, RGBDColors.color1, location);

        }

        private void timerHome_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void lblbackcolor()
        {
            // Tên nhà sách
            lblNameHome.Parent = pictureBox1;
            lblNameHome.BackColor = Color.Transparent;

            // Giờ phút giây
            lblTimer.Parent = pictureBox1;
            lblTimer.BackColor = Color.Transparent;

            // Ngày tháng năm
            lblDate.Parent = pictureBox1;
            lblDate.BackColor = Color.Transparent;

            // Hình ảnh
            picRanDom1.Parent = pictureBox1;
            picRanDom1.BackColor = Color.Transparent;

            picRanDom2.Parent = pictureBox1;
            picRanDom2.BackColor = Color.Transparent;

            picRanDom3.Parent = pictureBox1;
            picRanDom3.BackColor = Color.Transparent;
        }

        private void showImageRamdom()
        {
            files = Directory.GetFiles(@"D:\Workspace\windows_form\do_an\form_qlbansach\57_61_QuanLyBanSach\bin\Debug\ramdom_img\");
            timer.Tick += new EventHandler(timer_Tick);

            timer.Interval = 3000; // Thời gian xuất hiện ngẫu nhiên của ảnh là 5 giây
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            picRanDom1.ImageLocation = files[random.Next(files.Length)];
            picRanDom3.ImageLocation = files[random.Next(files.Length)];
            picRanDom2.ImageLocation = files[random.Next(files.Length)];
        }

        private void frmMenuMain_Load(object sender, EventArgs e)
        {
            
        }

        private static readonly string[] VietnameseSigns = new string[]

        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"

        };

        public static string RemoveSign4VietnameseString(string str)

        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)

            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;
        }

        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int location = 22;

                string str = RemoveSign4VietnameseString(txtTimKiem.Text);
                str = str.ToLower();
                str = str.Trim();
                str = Regex.Replace(str, @"\s+", "");

                if (str == "hoadonban")
                {
                    frmTKHoaDonBan f = new frmTKHoaDonBan();
                    txtTimKiem.Text = "";
                    f.ShowDialog();
                }
                else if (str == "hoadonnhap")
                {
                    frmTKHoaDonNhap f = new frmTKHoaDonNhap();
                    txtTimKiem.Text = "";
                    f.ShowDialog();
                }
                else if (str == "sach")
                {
                    frmTKSach f = new frmTKSach();
                    txtTimKiem.Text = "";
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bảng cẩn tìm không có! Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtTimKiem.Text = "";
                    txtTimKiem.Focus();
                }


                str = "";

                hideSubMenu();
            }
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            int location = 437;
            ActivateButton(sender, RGBDColors.color1, location);

            showSubMenu(panelsub4);
        }

        private void btntkHDBan_Click(object sender, EventArgs e)
        {
            int location = 497;
            ActivateButton_child(sender, RGBDColors.color4, location);

            OpenChildForm(new frmThongKeHDBan());

        }

        private void btntkHDNhap_Click(object sender, EventArgs e)
        {
            int location = 557;
            ActivateButton_child(sender, RGBDColors.color5, location);

            OpenChildForm(new frmThongKeHDNhap());

        }

        private void frmMenuMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = new DialogResult();
            kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }


    }
}
