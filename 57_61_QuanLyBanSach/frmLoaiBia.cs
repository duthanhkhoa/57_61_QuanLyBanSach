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
    public partial class frmLoaiBia : Form
    {
        public frmLoaiBia()
        {
            InitializeComponent();
        }
        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();
        DataSet dsLoaiBia = new DataSet();
        int vitri = 0;
        Boolean bl = false;
        int flag = 0;
        void danhsach_datagridview(DataGridView d,string sql)
        {
            dsLoaiBia = c.layDuLieu(sql);
            d.DataSource = dsLoaiBia.Tables[0];
        }
        private void xuLyChuNang(Boolean a)
        {
            btnThem.Enabled = a;
            btnSua.Enabled = a;
            btnXoa.Enabled = a;
            btnLuu.Enabled = !a;
            btnHuy.Enabled = !a;
        }
        private void xuLyTextBox(Boolean a)
        {
            txtTen.ReadOnly= a;
        }
        private Boolean ktraLoi()
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Chưa nhập tên bìa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return true;
            }
            else if (cmbTrangThai.Text == "")
            {
                MessageBox.Show("Chưa nhập chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTrangThai.Focus();
                return true;
            }
            else if (txtTen.Text != "")
            {
                for(int i = 0; i < dsLoaiBia.Tables[0].Rows.Count; i++)
                {
                    if (txtTen.Text == dsLoaiBia.Tables[0].Rows[i]["TenBia"].ToString() && flag == 1)
                    {
                        MessageBox.Show("Tên Bìa đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMa.Focus();
                        return true;
                    }
                }
                
            }
            else
                return false;
            return false;
        }
        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMa.Text = ds.Tables[0].Rows[vt]["MaBia"].ToString();
            txtTen.Text = ds.Tables[0].Rows[vt]["TenBia"].ToString();
            cmbTrangThai.Text = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienThiTextBox(dsLoaiBia, vitri);

        }
        string phatsinh()
        {
            string maBia = "";
            maBia = "LB" + (dsLoaiBia.Tables[0].Rows.Count + 1).ToString();
            return maBia;
        }
        private void frmLoaiBia_Load(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            danhsach_datagridview(dgvDanhSach, "select * from LoaiBia where TrangThai = 1");
            hienThiTextBox(dsLoaiBia, 0);
            bl = true;
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            txtMa.Text = phatsinh();
            cmbTrangThai.SelectedIndex = 1;
            flag = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            string sql = "";
            if (ktraLoi() == true)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (flag == 1)
                {
                    sql = "insert into LoaiBia values('" + txtMa.Text + "',N'" + txtTen.Text + "','" + 1 + "')";
                }
                if (flag == 2)
                {
                    sql = "update LoaiBia set TenBia = N'" + txtTen.Text + "',TrangThai =" + cmbTrangThai.SelectedIndex + "where MaBia ='" + txtMa.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update LoaiBia set TrangThai ='" + 0 + "'where MaBia ='" + txtMa.Text + "'";
                }
                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("cập nhật thành công");
                    frmLoaiBia_Load(sender, e);
                }
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(false);    
        }
        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bl == true)
            {
                string sql = "";
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string maBia = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenBia = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    sql = "update LoaiBia set TenBia = N'" + tenBia + "'where MaBia ='" + maBia + "'";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cập nhật thành công");
                        frmLoaiBia_Load(sender, e);
                    }
                }
            }
        }
    }
}
