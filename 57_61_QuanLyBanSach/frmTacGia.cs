using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  them using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _57_61_QuanLyBanSach
{
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        cls57_61_QuanLyBanSach tacGia = new cls57_61_QuanLyBanSach();
        DataSet ds = new DataSet();
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = tacGia.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void xuLyChuNang(Boolean a)
        {
            btnThem.Enabled = a;
            btnSua.Enabled = a;
            btnXoa.Enabled = a;
            btnLuu.Enabled = !a;
        }
        private void xuLyTextBox(Boolean a)
        {
            txtTen.ReadOnly = a;
            txtMail.ReadOnly = a;
            txtDiaChi.ReadOnly = a;
            txtSDT.ReadOnly = a;
            txtNgSinh.ReadOnly = a;
        }
        private void ktraLoi()
        {
            try
            {
                if (txtTen.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTen.Focus();
                }
                else if (cmbTrangThai.Text == "")
                {
                    MessageBox.Show("Chưa chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTrangThai.Focus();
                }
                else if(txtSDT.Text.Length > 10)
                {
                    MessageBox.Show("SDT không được nhập quá 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmTacGia_Load(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            danhsach_datagridview(dgvDanhSach, "select * from TacGia");
            hienThiTextBox(ds, 0);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            flag = 3;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            flag = 2;
        }
        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            cmbTrangThai.SelectedIndex = 0;
            txtMa.Text = phatsinh();
            flag = 1;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into TacGia values('" + txtMa.Text + "',N'" + txtTen.Text + "','" + txtNgSinh.Text + "','" + txtSDT.Text + "','" + txtDiaChi.Text + "','" + txtMail.Text + "','" + 1 + "')";
            }
            if (flag == 2)
            {
                sql = "update TacGia set TenTG = N'" + txtTen.Text + "',NGSinh = '" + txtNgSinh.Text + "',SDT = '" + txtSDT.Text + "',DChi = N'" + txtDiaChi.Text + "',Mail = '" + txtMail.Text + "',TrangThai =" + cmbTrangThai.SelectedIndex + "where MaTG = '" + txtMa.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update TacGia set TrangThai ='" + 0 + "'where MaTG ='" + txtMa.Text + "'";
            }
            if (tacGia.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Them thanh cong");
                frmTacGia_Load(sender, e);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
        }
        int vitri = 0;
        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMa.Text = ds.Tables[0].Rows[vt]["MaTG"].ToString();
            txtTen.Text = ds.Tables[0].Rows[vt]["TenTG"].ToString();
            txtNgSinh.Text = ds.Tables[0].Rows[vt]["NGSinh"].ToString();
            txtSDT.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["DChi"].ToString();
            txtMail.Text = ds.Tables[0].Rows[vt]["Mail"].ToString();
            cmbTrangThai.Text = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienThiTextBox(ds, vitri);
            xuLyTextBox(true);
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        string phatsinh()
        {
            string maBia = "";
            maBia = "TG" + (ds.Tables[0].Rows.Count + 1).ToString();
            return maBia;
        }
    }
}
