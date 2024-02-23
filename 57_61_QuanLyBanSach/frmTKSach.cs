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
    public partial class frmTKSach : Form
    {
        public frmTKSach()
        {
            InitializeComponent();
        }
        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();
 
        DataSet dsSach = new DataSet();
        DataSet dsLoai = new DataSet();

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
            txtTenSach.Text = "";
            cmbLoaiSach.SelectedIndex = -1;
        }

        private void frmTKSach_Load(object sender, EventArgs e)
        {
            dsLoai = c.layDuLieu("select * from LoaiSach");
            xuLyComBoBox(cmbLoaiSach, "TenLoai", "MaLoai", dsLoai);

            string sql = "select * from Sach";
            dsSach = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsSach.Tables[0];
            flag = true;

        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {

            string sql = "select * from Sach where TenSach like N'%" + txtTenSach.Text + "%'";
            dsSach = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsSach.Tables[0];
            cmbLoaiSach.SelectedIndex = -1;

        }

        private void cmbLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                if (cmbLoaiSach.SelectedIndex != -1)
                {
                    string maloai = cmbLoaiSach.SelectedValue.ToString();
                    string sql = "select * from Sach where MaLoai='" + maloai + "'";
                    dsSach = c.layDuLieu(sql);
                    dgvDanhSach.DataSource = dsSach.Tables[0];
                }
            }
            txtTenSach.Clear();
        }

        private void btnAllBook_Click(object sender, EventArgs e)
        {
            clear();
            string sql = "select * from Sach";
            dsSach = c.layDuLieu(sql);
            dgvDanhSach.DataSource = dsSach.Tables[0];
        }
    }
}
