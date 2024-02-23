using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Windows.Forms.VisualStyles;

namespace _57_61_QuanLyBanSach
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }
        DataSet dsNhaXuatBan = new DataSet();
        DataSet dsLoaiSach = new DataSet();
        DataSet dsTacGia = new DataSet();
        DataSet dsSach = new DataSet();
        DataSet dsCTSach = new DataSet();
        DataSet dsNCC = new DataSet();
        DataSet dsBia = new DataSet();
        int flag = 0;
        Boolean f = false;
        Boolean bl = false;
        int vitri = 0;
        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();
        void danhsach_datagridview(DataGridView d, string sql)
        {
            
            dsSach = c.layDuLieu(sql);
            d.DataSource = null;
            dgvDanhSach.Columns.Clear();
            d.DataSource = dsSach.Tables[0];
        }
        private void xuLyChuNang(Boolean a)
        {
            btnThem.Enabled = a;
            btnSua.Enabled = a;           
            btnXoa.Enabled = a;
            btnLuu.Enabled = !a;
            btnHuy.Enabled = !a;
            btnOK.Enabled = !a;
        }
        private void xuLyTextBox(Boolean a)
        {
            txtTen.ReadOnly = a;
            txtDonGia.ReadOnly = a;

        }
        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMa.Text = ds.Tables[0].Rows[vt]["MaSach"].ToString();
            txtTen.Text = ds.Tables[0].Rows[vt]["TenSach"].ToString();
            txtDonGia.Text = ds.Tables[0].Rows[vt]["DonGia"].ToString();
            txtSoLuong.Text = ds.Tables[0].Rows[vt]["SoLuong"].ToString();
            string maLoai = ds.Tables[0].Rows[vt]["MaLoai"].ToString();
            string maNXB = ds.Tables[0].Rows[vt]["MaNXB"].ToString();
            string maTG = ds.Tables[0].Rows[vt]["MaTG"].ToString();
            string hinhAnh = ds.Tables[0].Rows[vt]["HinhAnh"].ToString();
            string trangThai = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            cmbTrangThai.Text = trangThai;
            txtHinh.Text = hinhAnh;


            locDuLieuComBoBox(cmbMaloai, "TenLoai", "MaLoai", dsLoaiSach, maLoai);
            locDuLieuComBoBox(cmbManxb, "TenNXB", "MaNXB", dsNhaXuatBan, maNXB);
            locDuLieuComBoBox(cmbTg, "TenTG", "MaTG", dsTacGia, maTG);

            string tenhinh = ds.Tables[0].Rows[vt]["HinhAnh"].ToString();
            string tenfile = Path.GetFullPath("image_book") + @"\" + tenhinh;
            taoAnh(picHInhAnh, tenfile);

            load_ctsptheoMaSP(ds.Tables[0].Rows[vt]["MaSach"].ToString());

            txtMaSach.Text = txtMa.Text;
            txtHinhAnh.Text = hinhAnh;
            txtCTDonGia.ReadOnly = false;
            txtCTSoLuong.ReadOnly = false;
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienThiTextBox(dsSach, vitri);
        }
        string phatsinh()
        {
            string ma = "";
            ma = "S" + (dsSach.Tables[0].Rows.Count + 1).ToString();
            return ma;
        }

        private void locDuLieuComBoBox(ComboBox cmb, string ten, string ma, DataSet ds,string giatri)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + " ='" + giatri + "'";
            cmb.DataSource = dv;
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
        }
        private void xuLyComBoBox(ComboBox cmb, string ten, string ma,DataSet ds)
        {
            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
            cmb.SelectedIndex = -1;
        }
        private string xuLyThem(string sql, string ma)
        {
            string kqua = "";
            DataSet maThem = new DataSet();
            maThem = c.layDuLieu(sql);
            kqua = maThem.Tables[0].Rows[0][ma].ToString();
            return kqua;
        }
        private void taoAnh(PictureBox pic,string file)
        {
            Bitmap a = new Bitmap(file);
            pic.Image = a;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void load_ctsptheoMaSP(string ma)
        {
            string sql = "select * from ChiTietSach where MaSach = '" + ma + "'";
            dsCTSach = c.layDuLieu(sql);
            dgvChiTiet.DataSource = null;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.DataSource = dsCTSach.Tables[0];
        }
        private void clear()
        {
            txtTen.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
        }
        private int tinhTongSoLuong()
        {
            int soLuong = 0;
            for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
            {
                soLuong += int.Parse(dgvChiTiet.Rows[i].Cells[5].Value.ToString());
            }
            return soLuong;
        }
        void taoCotCTSP()
        {
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add("MaCTSach", "MaCTSach");
            dgvChiTiet.Columns.Add("MaSach", "MaSach");
            dgvChiTiet.Columns.Add("MaBia", "MaBia");
            dgvChiTiet.Columns.Add("MaNCC", "MaNCC");
            dgvChiTiet.Columns.Add("DonGia", "DonGia");
            dgvChiTiet.Columns.Add("SoLuong", "SoLuong");
            dgvChiTiet.Columns.Add("HinhAnh", "HinhAnh");
            dgvChiTiet.Columns.Add("TrangThai", "TrangThai");

        }
        void taoCotSP()
        {
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.Columns.Add("MaSach", "MaSach");
            dgvDanhSach.Columns.Add("TenSach", "Tên Sách");
            dgvDanhSach.Columns.Add("DonGia", "Đơn Giá");
            dgvDanhSach.Columns.Add("SoLuong", "Số Lượng");
            dgvDanhSach.Columns.Add("MaLoai", "Mã Loại");
            dgvDanhSach.Columns.Add("MaNXB", "Mã NXB");
            dgvDanhSach.Columns.Add("MaTG", "Mã Tác Giả");
            dgvDanhSach.Columns.Add("HinhAnh", "Hình Ảnh");
            dgvDanhSach.Columns.Add("TrangThai", "Trang Thái");

        }
        private void frmSach_Load(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            txtHinh.Hide();
            danhsach_datagridview(dgvDanhSach, "select * from Sach");

            dsNhaXuatBan = c.layDuLieu("select * from NhaXuatBan");
            xuLyComBoBox(cmbManxb, "TenNXB", "MaNXB", dsNhaXuatBan);
            dsLoaiSach = c.layDuLieu("select * from LoaiSach");
            xuLyComBoBox(cmbMaloai, "TenLoai", "MaLoai", dsLoaiSach);
            dsTacGia = c.layDuLieu("select * from TacGia");
            xuLyComBoBox(cmbTg, "TenTG", "MaTG", dsTacGia);
            dsNCC = c.layDuLieu("select * from NhaCungCap");
            xuLyComBoBox(cmbMaNCC, "TenNCC", "MaNCC", dsNCC);
            dsBia = c.layDuLieu("select * from LoaiBia");
            xuLyComBoBox(cmbMaBia, "TenBia", "MaBia", dsBia);


            hienThiTextBox(dsSach, vitri);
            cmbCTTrangThai.SelectedIndex = 1;
            btnCTThem.Enabled= false;
            btnTaoMa.Enabled = false;
            bl = true;
            f = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            xuLyChuNang(false);
            xuLyTextBox(false);
            cmbTrangThai.SelectedIndex = 1;
            txtMa.Text = phatsinh();

            xuLyComBoBox(cmbManxb, "TenNXB", "MaNXB", dsNhaXuatBan);
            xuLyComBoBox(cmbMaloai, "TenLoai", "MaLoai", dsLoaiSach);
            xuLyComBoBox(cmbTg, "TenTG", "MaTG", dsTacGia);
            dgvChiTiet.DataSource = null;
            dgvDanhSach.DataSource = null;
            taoCotCTSP();
            taoCotSP();
            flag = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);

            //dsNhaXuatBan = c.layDuLieu("select * from NhaXuatBan");
            xuLyComBoBox(cmbManxb, "TenNXB", "MaNXB", dsNhaXuatBan);
            //dsLoaiSach = c.layDuLieu("select * from LoaiSach");
            xuLyComBoBox(cmbMaloai, "TenLoai", "MaLoai", dsLoaiSach);
            //dsTacGia = c.layDuLieu("select * from TacGia");
            xuLyComBoBox(cmbTg, "TenTG", "MaTG", dsTacGia);
            btnOK.Enabled = false;
            flag = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLyChuNang(false);
            xuLyTextBox(false);
            flag = 3;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            string sql = "";
            string sql1 = "";
            string maNXB = xuLyThem("select MaNXB from NhaXuatBan where TenNXB = N'" + cmbManxb.Text + "'", "MaNXB");
            string maLoai = xuLyThem("select MaLoai from LoaiSach where TenLoai = N'" + cmbMaloai.Text + "'", "MaLoai");
            string maTG = xuLyThem("select MaTG from TacGia where TenTG = N'" + cmbTg.Text + "'", "MaTG");


            if (flag == 1)
            {
                sql = "insert into Sach values ( '" + txtMa.Text + "', N'" + txtTen.Text + "', " + txtDonGia.Text + "," + txtSoLuong.Text + ", '" + maLoai + "', '" + maNXB + "','" + maTG + "','" + txtHinh.Text + "'," + cmbTrangThai.SelectedIndex + ")";
                
            }
            if (flag == 2)
            {
                sql = "update Sach set TenSach=N'" + txtTen.Text + "',DonGia = " + txtDonGia.Text + ",SoLuong = " + txtSoLuong.Text + ",MaLoai = '" + maLoai + "',MaNXB = '" + maNXB + "',MaTG = '" + maTG + "',HinhAnh ='" + txtHinh.Text + "',TrangThai =" + cmbTrangThai.SelectedIndex + " where MaSach = '" + txtMa.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update Sach set TrangThai ='" + 0 + "'where MaSach ='" + txtMa.Text + "'";   
            }
            if (c.capnhatdulieu(sql) > 0)
            {
                if (flag == 1)
                {
                    for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
                    {
                        string maCTSach = dgvChiTiet.Rows[i].Cells[0].Value.ToString();
                        string maSach = dgvChiTiet.Rows[i].Cells[1].Value.ToString();
                        string maBia = dgvChiTiet.Rows[i].Cells[2].Value.ToString();
                        string maNCC = dgvChiTiet.Rows[i].Cells[3].Value.ToString();
                        string donGia = dgvChiTiet.Rows[i].Cells[4].Value.ToString();
                        string soLuong = dgvChiTiet.Rows[i].Cells[5].Value.ToString();
                        string hinhAnh = dgvChiTiet.Rows[i].Cells[6].Value.ToString();
                        sql1 = "insert into ChiTietSach values ('" + maCTSach + "','" + maSach + "','" + maBia + "','" + maNCC + "'," + donGia + "," + soLuong + ",'" + hinhAnh + "'," + 1 + ")";
                        if (c.capnhatdulieu(sql1) > 0)
                        {
                            //MessageBox.Show("cập nhật thành công");
                            continue;

                        }
                    }
                }
                if(flag == 3)
                {
                    for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
                    {
                        string maSach = dgvChiTiet.Rows[i].Cells[1].Value.ToString();
                        sql1 = "update ChiTietSach set TrangThai ='" + 0 + "'where MaSach ='" + maSach + "'";
                        if (c.capnhatdulieu(sql1) > 0)
                        {
                            //MessageBox.Show("cập nhật thành công");
                            continue;

                        }
                    }
                }
                MessageBox.Show("cập nhật thành công");
                frmSach_Load(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            frmSach_Load(sender, e);
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bl == true)
            {
                string sql = "";
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string maSach = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenSach = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string donGia = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string soLuong = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string maLoai = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    string maNXB = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                    sql = "update Sach set TenSach=N'" + tenSach + "',DonGia = " + donGia + ",SoLuong = " + soLuong + ",MaLoai = '" + maLoai + "',MaNXB = '" + maNXB + "' where MaSach = '" + maSach + "'";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cập nhật thành công");
                        frmSach_Load(sender, e);
                    }
                }
            }
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog hinhAnh = new OpenFileDialog();
            hinhAnh.InitialDirectory = Path.GetFullPath("image_book") + @"\";
            hinhAnh.ShowDialog();
            string tenFile = hinhAnh.FileName;
            string[] tenhinh = tenFile.Split('\\');
            string a = tenhinh[9] + "\\" + tenhinh[10];
            Bitmap anh = new Bitmap(tenFile);
            picHInhAnh.Image = anh;
            picHInhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            txtHinh.Text = a;
        }
        private void btnCTThem_Click(object sender, EventArgs e)
        {
            int tongSL = 0;
            int a = 0;
            string maBia = xuLyThem("select MaBia from LoaiBia where TenBia = N'" + cmbMaBia.Text + "'", "MaBia");
            string maNCC = xuLyThem("select MaNCC from NhaCungCap where TenNCC = N'" + cmbMaNCC.Text + "'", "MaNCC");
            object[] d = new object[10];
            d[0] = txtMaCTSach.Text;
            d[1] = txtMaSach.Text;
            d[2] = maBia;
            d[3] = maNCC;
            d[4] = txtCTDonGia.Text;
            d[5] = txtCTSoLuong.Text;
            d[6] = txtHinhAnh.Text;
            d[7] = cmbCTTrangThai.Text;          
            
            for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
            {
                if (txtMaCTSach.Text == dgvChiTiet.Rows[i].Cells[0].Value.ToString())
                {
                    MessageBox.Show("CT Sản Phẩm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    a = 1;
                    break;
                }
            }
            if(a != 1)
                dgvChiTiet.Rows.Add(d);
            tongSL = tinhTongSoLuong();
            txtSoLuong.Text = tongSL.ToString();
            txtMaCTSach.Text = "";
            btnCTThem.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f == true)
            {
                if (flag == 1)
                {
                    int tongSl = 0;
                    if (e.ColumnIndex == 5)
                    {
                        string soLuong = dgvChiTiet.CurrentRow.Cells[5].Value.ToString();
                        tongSl = tinhTongSoLuong();
                        txtSoLuong.Text = tongSl.ToString();
                    }
                }
            }
               
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            string maBia = xuLyThem("select MaBia from LoaiBia where TenBia = N'" + cmbMaBia.Text + "'", "MaBia");
            string maNCC = xuLyThem("select MaNCC from NhaCungCap where TenNCC = N'" + cmbMaNCC.Text + "'", "MaNCC");
            string mactSach = txtMaSach.Text + "." + maBia + "." + maNCC;
            txtMaCTSach.Text = mactSach.ToString();
            btnCTThem.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnTaoMa.Enabled = true;
            string maNXB = xuLyThem("select MaNXB from NhaXuatBan where TenNXB = N'" + cmbManxb.Text + "'", "MaNXB");
            string maLoai = xuLyThem("select MaLoai from LoaiSach where TenLoai = N'" + cmbMaloai.Text + "'", "MaLoai");
            string maTG = xuLyThem("select MaTG from TacGia where TenTG = N'" + cmbTg.Text + "'", "MaTG");
            object[] d = new object[10];
            d[0] = txtMa.Text;
            d[1] = txtTen.Text;
            d[2] = txtDonGia.Text;
            d[3] = txtSoLuong.Text;
            d[4] = maLoai;
            d[5] = maNXB;
            d[6] = maTG;
            d[7] = txtHinhAnh.Text;
            d[8] = cmbTrangThai.Text;
            dgvDanhSach.Rows.Add(d);
            txtMaSach.Text = txtMa.Text;
            txtCTDonGia.ReadOnly= false;
            txtCTSoLuong.ReadOnly= false;
            btnOK.Enabled = false;
            xuLyTextBox(true);

            locDuLieuComBoBox(cmbMaloai, "TenLoai", "MaLoai", dsLoaiSach, maLoai);
            locDuLieuComBoBox(cmbManxb, "TenNXB", "MaNXB", dsNhaXuatBan, maNXB);
            locDuLieuComBoBox(cmbTg, "TenTG", "MaTG", dsTacGia, maTG);
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCTDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCTSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
