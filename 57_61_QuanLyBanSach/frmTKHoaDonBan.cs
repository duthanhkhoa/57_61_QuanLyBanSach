using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _57_61_QuanLyBanSach
{
    public partial class frmTKHoaDonBan : Form
    {
        public frmTKHoaDonBan()
        {
            InitializeComponent();
        }

        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();

        DataSet dsHoaDonBan = new DataSet();
        DataSet dsNhanVien = new DataSet();
        DataSet dsKhachHang= new DataSet();

        Boolean flag = false;

        private void xuLyComBoBox(ComboBox cmb, string ten, string ma, DataSet ds)
        {
            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
            cmb.SelectedIndex = -1;
        }

        private void clear()
        {
            cmbHoaDon.SelectedIndex = -1;
            cmbKhachHang.SelectedIndex = -1;
            cmbNhanVien.SelectedIndex = -1;
        }

        private void xulytextbox(Boolean a)
        {
            cmbHoaDon.Enabled = a;
            cmbKhachHang.Enabled = a;
            cmbNhanVien.Enabled = a;
            dateNgayLap.Enabled = a;
            txtNhanVien.Enabled = a;
            txtTenKH.Enabled = a;
        }

        private void frmTKHoaDonBan_Load(object sender, EventArgs e)
        {


            dsHoaDonBan = c.layDuLieu("select * from HoaDonBan");
            xuLyComBoBox(cmbHoaDon, "MaHDBan", "MaHDBan", dsHoaDonBan);

            dsNhanVien = c.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbNhanVien, "TenNV", "MaNV", dsNhanVien);

            dsKhachHang = c.layDuLieu("select * from KhachHang");
            xuLyComBoBox(cmbKhachHang, "TenKh", "MaKH", dsKhachHang);

            dgvDanhSach.DataSource = dsHoaDonBan.Tables[0];
            flag = true;
        }

        private void cmbHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbHoaDon.SelectedIndex != -1)
                {
                    cmbKhachHang.SelectedIndex = -1;
                    cmbNhanVien.SelectedIndex = -1;

                    string mahd = cmbHoaDon.SelectedValue.ToString();
                    string sql = "select * from HoaDonBan where MaHDBan='" + mahd + "'";
                    dsHoaDonBan = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsHoaDonBan.Tables[0];
                }
            }
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbKhachHang.SelectedIndex != -1)
                {
                    cmbHoaDon.SelectedIndex = -1;
                    cmbNhanVien.SelectedIndex = -1;

                    string makh = cmbKhachHang.SelectedValue.ToString();

                    string sql = "select a.* from HoaDonBan a inner join KhachHang b on a.MaKH = b.MaKH where b.MaKH like N'%" + makh + "%'";

                    dsKhachHang = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsKhachHang.Tables[0];
                }
            }
        }

        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbNhanVien.SelectedIndex != -1)
                {
                    cmbHoaDon.SelectedIndex = -1;
                    cmbKhachHang.SelectedIndex = -1;

                    string manv = cmbNhanVien.SelectedValue.ToString();

                    string sql = "select a.* from HoaDonBan a inner join NhanVien b on a.MaNV = b.MaNV where b.MaNV like N'%" + manv + "%'";

                    dsNhanVien = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsNhanVien.Tables[0];
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            clear();

            txtTenKH.Clear();
            txtNhanVien.Clear();
            string sql = "select * from HoaDonBan where NgayLapHD= '" + dateNgayLap.Text + "'";
            dsHoaDonBan = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsHoaDonBan.Tables[0];
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            clear();
            txtNhanVien.Clear();
            dgvDanhSach.DataSource = null;

            string sql = "select a.* from HoaDonBan a inner join KhachHang b on a.MaKH = b.MaKH where b.TenKh like N'%" + txtTenKH.Text + "%'";

            dsKhachHang = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsKhachHang.Tables[0];
        }

        private void txtNhanVien_TextChanged(object sender, EventArgs e)
        {
            clear();
            txtTenKH.Clear();

            string sql = "select a.* from HoaDonBan a inner join NhanVien b on a.MaNV = b.MaNV where b.TenNV like N'%" + txtNhanVien.Text + "%'";

            dsNhanVien = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsNhanVien.Tables[0];
        }


        private void btnAllHoaDon_Click(object sender, EventArgs e)
        {
            clear();
            txtNhanVien.Clear();
            txtTenKH.Clear();
            string sql = "select * from HoaDonban";
            dsHoaDonBan = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsHoaDonBan.Tables[0];
        }
    }
}
