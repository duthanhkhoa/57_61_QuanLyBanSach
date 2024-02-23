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
    public partial class frmloaisach : Form
    {
        public frmloaisach()
        {
            InitializeComponent();
        }

        void xuly_textbox(Boolean t)
        {
            txtMaLoai.ReadOnly = t;
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
            txtMaLoai.Enabled = a;
            txtTenLoai.Enabled = a;
            
            cmbTrangThai.Enabled = a;
        }

        private void clear()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            cmbTrangThai.Text = "";
        }

        cls57_61_QuanLyBanSach loaisach = new cls57_61_QuanLyBanSach();
        DataSet ds = new DataSet();

        int viTri = 0;
        int flag = 0;

        Boolean flagds = false;
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = loaisach.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }

        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMaLoai.Text = ds.Tables[0].Rows[vt]["MaLoai"].ToString();
            txtTenLoai.Text = ds.Tables[0].Rows[vt]["TenLoai"].ToString();

            string trangThai = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            cmbTrangThai.Text = trangThai;
        }

        string phatsinhma()
        {
            string manv = "";
            manv = (ds.Tables[0].Rows.Count + 1).ToString();
            return "LS" + manv;
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
            xuly_textbox(true);
            clear();
            txtMaLoai.Text = phatsinhma();
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

        private void frmloaisach_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);

            danhsach_datagridview(dgvDanhSach, "select * from LoaiSach Where TrangThai = 1");
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
            if(flag == 1 )
            {
                sql = "insert into LoaiSach values ('" + txtMaLoai.Text + "', N'" + txtTenLoai.Text + "', '" + 1 + "')";
            }

            if (flag == 2)
            {
                sql = "update LoaiSach set TenLoai = '" + txtTenLoai.Text + "', TrangThai = '" + cmbTrangThai.SelectedIndex + "' where MaNV = '" + txtMaLoai.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update LoaiSach set TrangThai = '" + 0 + "' where MaLoai = '" + txtMaLoai.Text + "'";
            }
            if (loaisach.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                frmloaisach_Load(sender, e);
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
                    string maloai = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenloai = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string trangthai = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string sql = "update LoaiSach set TenLoai = N'" + tenloai + "', TrangThai = '" + trangthai + "' where MaLoai = '" + maloai + "'";
                    if (loaisach.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        viTri = 0;
                        frmloaisach_Load(sender, e);
                    }
                }
        }

        private void frmloaisach_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult kq = new DialogResult();
            //kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (kq == DialogResult.No)
            //    e.Cancel = true;
        }
    }
}
