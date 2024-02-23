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
    public partial class frmTKHoaDonNhap : Form
    {
        public frmTKHoaDonNhap()
        {
            InitializeComponent();
        }

        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();

        DataSet dsHoaDonNhap = new DataSet();
        DataSet dsNhanVien = new DataSet();
        DataSet dsNhaXuatban = new DataSet();

        Boolean flag = false;


        private void xuLyComBoBox(ComboBox cmb, string ten, string ma, DataSet ds)
        {
            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
            cmb.SelectedIndex = -1;
        }

        private void frmTKHoaDonNhap_Load(object sender, EventArgs e)
        {
            dsHoaDonNhap = c.layDuLieu("select * from HoaDonNhap");
            xuLyComBoBox(cmbHoaNhap, "MaHDNhap", "MaHDNhap", dsHoaDonNhap);

            dsNhanVien = c.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbNhanVien, "TenNV", "MaNV", dsNhanVien);

            dsNhaXuatban = c.layDuLieu("select * from NhaXuatBan");
            xuLyComBoBox(cmbNhaXuatBan, "TenNXB", "MaNXB", dsNhaXuatban);

            dgvDanhSach.DataSource = dsHoaDonNhap.Tables[0];
            flag = true;
        }

        private void cmbHoaNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbHoaNhap.SelectedIndex != -1)
                {
                    cmbNhanVien.SelectedIndex = -1;
                    cmbNhaXuatBan.SelectedIndex = -1;

                    string mahd = cmbHoaNhap.SelectedValue.ToString();
                    string sql = "select * from HoaDonNhap where MaHDNhap='" + mahd + "'";
                    dsHoaDonNhap = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsHoaDonNhap.Tables[0];
                }
            }
        }

        private void cmbNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbNhaXuatBan.SelectedIndex != -1)
                {
                    cmbHoaNhap.SelectedIndex = -1;
                    cmbNhanVien.SelectedIndex = -1;

                    string manxb = cmbNhaXuatBan.SelectedValue.ToString();
                    string sql = "select a.* from HoaDonNhap a inner join NhaXuatBan b on a.MaNXB = b.MaNXB where b.MaNXb like N'%" + manxb + "%'";
                    dsHoaDonNhap = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsHoaDonNhap.Tables[0];
                }
            }
        }

        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbNhanVien.SelectedIndex != -1)
                {
                    cmbHoaNhap.SelectedIndex = -1;
                    cmbNhaXuatBan.SelectedIndex = -1;

                    string manv = cmbNhanVien.SelectedValue.ToString();

                    string sql = "select a.* from HoaDonNhap a inner join NhanVien b on a.MaNV = b.MaNV where b.MaNV like N'%" + manv + "%'";

                    dsNhanVien = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsNhanVien.Tables[0];
                }
            }
        }

        private void dateNgayLap_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select * from HoaDonNhap where NgayLapHD= '" + dateNgayLap.Text + "'";
            dsHoaDonNhap = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsHoaDonNhap.Tables[0];
        }

        private void btnAllHoaDon_Click(object sender, EventArgs e)
        {
            string sql = "select * from HoaDonNhap";
            dsHoaDonNhap = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsHoaDonNhap.Tables[0];
        }
    }
}
