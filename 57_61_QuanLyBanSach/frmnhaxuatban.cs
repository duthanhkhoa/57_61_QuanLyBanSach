using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _57_61_QuanLyBanSach
{
    public partial class frmnhaxuatban : Form
    {
        public frmnhaxuatban()
        {
            InitializeComponent();
        }

        void xuly_textbox(Boolean t)
        {
            txtMaNXB.ReadOnly = t;
        }

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
            txtMaNXB.Enabled = a;
            txtTenNXB.Enabled = a;
            txtSDT.Enabled = a;
            txtDiaChi.Enabled = a;
            txtEmail.Enabled = a;
            cmbTrangThai.Enabled = a;
        }

        private void clear()
        {
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cmbTrangThai.Text = "";
        }

        cls57_61_QuanLyBanSach nhaxuatban = new cls57_61_QuanLyBanSach();
        DataSet ds = new DataSet();

        int viTri = 0;
        int flag = 0;

        Boolean flagds = false;
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = nhaxuatban.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }

        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMaNXB.Text = ds.Tables[0].Rows[vt]["MaNXB"].ToString();
            txtTenNXB.Text = ds.Tables[0].Rows[vt]["TenNXB"].ToString();
            txtSDT.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["DChi"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[vt]["Mail"].ToString();

            string trangThai = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            cmbTrangThai.Text = trangThai;
        }

        string phatsinhma()
        {
            string ma = "";
            ma = (ds.Tables[0].Rows.Count + 1).ToString();
            return "NXB" + ma;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);
            clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            xulychucnang(false);
            xulytextbox(true);
            xuly_textbox(true);
            txtMaNXB.Text = phatsinhma();
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
            xuly_textbox(true);
            flag = 2;
        }

        private void frmnhaxuatban_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);

            danhsach_datagridview(dgvDanhSach, "select * from NhaXuatBan Where TrangThai = 1");
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
            if (flag == 1)
            {
                sql = "insert into NhaXuatBan values ('" + txtMaNXB.Text + "', N'" + txtTenNXB.Text + "', '" + txtSDT.Text + "', N'" + txtDiaChi.Text + "', '" + txtEmail.Text + "', '" + 1 + "')";
            }
            if (flag == 2)
            {
                sql = "update NhaXuatBan set TenNXB = N'" + txtTenNXB.Text + "',SDT = '" + txtSDT.Text + "', DChi = N'" + txtDiaChi.Text + "', Mail = '" + txtEmail.Text + "', TrangThai = '" + cmbTrangThai.SelectedIndex + "' where MaNXB = '" + txtMaNXB.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update NhaXuatBan set TrangThai = '" + 0 + "' where MaNXB = '" + txtMaNXB.Text + "'";
            }
            if (nhaxuatban.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                frmnhaxuatban_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viTri = e.RowIndex;
            hienThiTextBox(ds, viTri);
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagds)
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string manxb = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tennxb = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string sdt = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string dchi = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string mail = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    string trangthai = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();

                    string sql = "update NhaXuatBan set TenNXB = N'" + tennxb + "',SDT = '" + sdt + "', DChi = N'" + dchi + "', Mail = '" + mail + "', TrangThai = '" + trangthai + "' where MaNXB = '" + manxb + "'";
                    if (nhaxuatban.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        viTri = 0;
                        frmnhaxuatban_Load(sender, e);
                    }
                }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
