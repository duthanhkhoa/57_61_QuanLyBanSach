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
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
        }
        cls57_61_QuanLyBanSach nhanvien = new cls57_61_QuanLyBanSach();
        DataSet ds = new DataSet();

        int viTri = 0;
        Boolean flagds = false;
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = nhanvien.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }

        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMaNV.Text = ds.Tables[0].Rows[vt]["MaNV"].ToString();
            txtTenNV.Text = ds.Tables[0].Rows[vt]["TenNV"].ToString();
            txtSDT.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["DChi"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[vt]["Mail"].ToString();

            string trangThai = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            cmbTrangThai.Text = trangThai;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viTri = e.RowIndex;
            hienThiTextBox(ds, viTri);
        }

        void xuly_textbox(Boolean t)
        {
            txtTenNV.ReadOnly = t;
        }

        string phatsinhma()
        {
            string manv = "";
            manv = (ds.Tables[0].Rows.Count + 1).ToString();
            return "NV0" + manv;
        }
        int flag = 0;


        private void xulychucnang(Boolean a)
        {
            btnLuu.Enabled = !a;
            btnHuy.Enabled = !a;
            btnThem.Enabled = a;
            btnXoa.Enabled = a;
            btnSua.Enabled = a;
        }

        private void xulytextbox(Boolean a)
        {
            txtMaNV.Enabled = a;
            txtTenNV.Enabled = a;
            txtSDT.Enabled = a;
            txtDiaChi.Enabled = a;
            txtEmail.Enabled = a;
            cmbTrangThai.Enabled = a;
        }

        private void clear()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cmbTrangThai.Text = "";
        }
        
        private void kiemTraLoi()
        {
            try
            {
                if(txtMaNV.Text == "")
                {
                    MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNV.Focus();
                }
                else if(txtTenNV.Text == ""){
                    MessageBox.Show("Chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNV.Focus();
                }else if(txtSDT.Text == "")
                {
                    MessageBox.Show("Chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }else if(txtDiaChi.Text == "")
                {
                    MessageBox.Show("Chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Focus();
                }else if(txtEmail.Text == "")
                {
                    MessageBox.Show("Chưa nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }else if(cmbTrangThai.Text == "")
                {
                    MessageBox.Show("Chưa chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTrangThai.Focus();
                }else if(txtSDT.Text.Length > 10)
                {
                    MessageBox.Show("Số điện thoại không quá 10 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }else if(txtMaNV.Text.Length > 5) {
                    MessageBox.Show("Mã nhân viên không quá 10 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);
            clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytextbox(true);
            xuly_textbox(false);
            clear();
            txtMaNV.Text = phatsinhma();
            cmbTrangThai.SelectedIndex = 1;
            flag = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytextbox(true);
            flag = 3;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytextbox(true);
            xuly_textbox(false);
            flag = 2;
        }

        

        private void frmnhanvien_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);
            danhsach_datagridview(dgvDanhSach, "select * from NhanVien Where TrangThai = 1");
            hienThiTextBox(ds, viTri);
            flagds = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);
            //clear();
            xuly_textbox(true);
            string sql = "";
            if(flag == 1)
            {
                sql = "insert into NhanVien values ('" + txtMaNV.Text + "', N'" + txtTenNV.Text + "', '" + txtSDT.Text + "', N'" + txtDiaChi.Text + "', '" + txtEmail.Text + "', '" + 1 + "')";
            }
            if (flag == 2)
            {
                sql = "update NhanVien set TenNV = N'" + txtTenNV.Text + "',SDT = '" + txtSDT.Text + "', DChi = N'" + txtDiaChi.Text + "', Mail = '" + txtEmail.Text + "', TrangThai = '" + cmbTrangThai.SelectedIndex + "' where MaNV = '" + txtMaNV.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update NhanVien set TrangThai = '" + 0 + "' where MaNV = '" + txtMaNV.Text + "'";
            }
            if (nhanvien.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                frmnhanvien_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagds)
            if(e.ColumnIndex >= 1)
            {
                int vt = dgvDanhSach.CurrentRow.Index;
                string manv = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                string tennv = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                string sdt = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                string dchi = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                string mail = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                string trangthai = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();

                string sql = "update NhanVien set TenNV = N'" + tennv + "',SDT = '" + sdt + "', DChi = N'" + dchi + "', Mail = '" + mail + "', TrangThai = '" + trangthai + "' where MaNV = '" + manv + "'";
                if (nhanvien.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    viTri = 0;
                    frmnhanvien_Load(sender, e);
                }
            }
        }

    }
}
