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

namespace _57_61_QuanLyBanSach
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        cls57_61_QuanLyBanSach khachHang = new cls57_61_QuanLyBanSach();
        DataSet ds = new DataSet();
        int vitri = 0;
        Boolean bl = false;
        int flag = 0;

        public string makh1;
        public string tenkh1;
        public string sdt1;

        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = khachHang.layDuLieu(sql);
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
            txtTen.ReadOnly= a;
            txtSDT.ReadOnly= a;
            txtDiaChi.ReadOnly= a;
            txtMail.ReadOnly= a;
        }
        private void clear()
        {
            txtDiaChi.Text = "";
            txtMail.Text = "";
            txtSDT.Text = "";
            txtTen.Text = "";
        }
        private Boolean ktraLoi()
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return true;
            }
            else if (cmbTrangThai.Text == "")
            {
                MessageBox.Show("Chưa chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTrangThai.Focus();
                return true;
            }
            else if (txtSDT.Text.Length > 10)
            {
                MessageBox.Show("SDT không được nhập quá 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return true;
            }
            return false;
        }
        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMa.Text = ds.Tables[0].Rows[vt]["MaKH"].ToString();
            txtTen.Text = ds.Tables[0].Rows[vt]["TenKH"].ToString();
            txtSDT.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["DChi"].ToString();
            txtMail.Text = ds.Tables[0].Rows[vt]["Mail"].ToString();
            cmbTrangThai.Text = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
        }
        private void dgvDanhSach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienThiTextBox(ds, vitri);
        }
        string phatsinh()
        {
            string maBia = "";
            maBia = "KH" + (ds.Tables[0].Rows.Count + 1).ToString();
            return maBia;
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            danhsach_datagridview(dgvDanhSach, "select * from KhachHang where TrangThai = 1");
            hienThiTextBox(ds, 0);
            bl = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);

            makh1 = txtMa.Text;
            tenkh1 = txtTen.Text;
            sdt1 = txtSDT.Text;

            if (ktraLoi() == true)
            {
                try
                {
                    if (btnLuu.DialogResult == DialogResult.OK)
                    {
                        btnThem_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);   
                }
            }
            else
            {
                string sql = "";
                if (flag == 1)
                {
                    sql = "insert into KhachHang values('" + txtMa.Text + "',N'" + txtTen.Text + "','" + txtSDT.Text + "','" + txtDiaChi.Text + "','" + txtMail.Text + "','" + 1 + "')";
                }
                if (flag == 2)
                {
                    sql = "update KhachHang set TenKH = N'" + txtTen.Text + "',SDT = '" + txtSDT.Text + "',DChi = N'" + txtDiaChi.Text + "',Mail = '" + txtMail.Text + "',TrangThai =" + cmbTrangThai.SelectedIndex + "where MaKH = '" + txtMa.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update KhachHang set TrangThai ='" + 0 + "'where MaTG ='" + txtMa.Text + "'";
                }
                if (khachHang.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("cập nhật thành công");
                    frmKhachHang_Load(sender, e);
                }
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            xuLyChuNang(false);
            xuLyTextBox(false);
            cmbTrangThai.SelectedIndex = 1;
            txtMa.Text = phatsinh();
            flag = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            flag = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            flag = 3;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
        }
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bl == true)
            {
                string sql = "";
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string maKH = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenKH = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string dChi = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sdt = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string mail = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    sql = "update KhachHang set TenKH = N'" + tenKH + "',SDT = '" + sdt + "',DChi = N'" + dChi + "',Mail = '" + mail + "'where MaKH = '" + maKH + "'";
                    if (khachHang.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cập nhật thành công");
                        frmKhachHang_Load(sender, e);
                    }
                }
            }
        }
    }
}
