using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _57_61_QuanLyBanSach
{
    public partial class frmCTHoaDonNhap : Form
    {
        public frmCTHoaDonNhap()
        {
            InitializeComponent();
        }
        DataSet dsHoaDonNhap = new DataSet();
        DataSet dsNXB = new DataSet();
        DataSet dsNV = new DataSet();
        DataSet dsSach = new DataSet();
        DataSet dsCTSach = new DataSet();
        DataSet dsBia= new DataSet();
        DataSet dsNCC =  new DataSet();
        DataSet dsChiTietHDNhap = new DataSet();
        int flag = 0;
        Boolean bl = false;
        Boolean f = true;
        int vitri = 0;
        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();
        private void xuLyChuNang(Boolean a)
        {
            btnThem.Enabled = a;
            btnSua.Enabled = a;
            btnXoa.Enabled = a;
            btnLuu.Enabled = !a;
            btnOK.Enabled = !a;
            btnHuy.Enabled = !a;
            
        }
        private void xuLyTextBox(Boolean a)
        {
            txtCTSoLuong.ReadOnly = a;
            txtMaCTSach.ReadOnly= a;
        }
        void danhsach_datagridview(DataGridView d, string sql)
        {
            dsHoaDonNhap = c.layDuLieu(sql);
            d.DataSource = null;
            dgvDanhSach.Columns.Clear();
            d.DataSource = dsHoaDonNhap.Tables[0];
        }
        void hienThiTextBox(DataSet ds, int vt)
        {
            txtMa.Text = ds.Tables[0].Rows[vt]["MaHDNhap"].ToString();
            dtpNgayLapHD.Text = ds.Tables[0].Rows[vt]["NgayLapHD"].ToString();
            txtTongTien.Text = ds.Tables[0].Rows[vt]["TongTien"].ToString();
            string maNV = ds.Tables[0].Rows[vt]["MaNV"].ToString();
            string maNXB = ds.Tables[0].Rows[vt]["MaNXB"].ToString();

            string trangThai = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            cmbTrangThai.Text = trangThai;

            locDuLieuComBoBox(cmbNV, "TenNV", "MaNV", dsNV, maNV);
            locDuLieuComBoBox(cmbNXB, "TenNXB", "MaNXB", dsNXB, maNXB);

            //string tenhinh = ds.Tables[0].Rows[vt]["HinhAnh"].ToString();
            //string tenfile = Path.GetFullPath("sach") + @"\" + tenhinh;
            //taoAnh(picHInhAnh, tenfile);

            load_ctsptheoMaSP(ds.Tables[0].Rows[vt]["MaHDNhap"].ToString());
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienThiTextBox(dsHoaDonNhap, vitri);
        }
        private void load_ctsptheoMaSP(string ma)
        {
            string sql = "select * from ChiTietHDNhap where MaHDNhap = '" + ma + "'";
            dsChiTietHDNhap = c.layDuLieu(sql);
            dgvChiTiet.DataSource = null;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.DataSource = dsChiTietHDNhap.Tables[0];
        }
        string phatsinh()
        {
            string ma = "";
            ma = "HD" + (dsHoaDonNhap.Tables[0].Rows.Count + 1).ToString();
            return ma;
        }
        private void locDuLieuComBoBox(ComboBox cmb, string ten, string ma, DataSet ds, string giatri)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + " ='" + giatri + "'";
            cmb.DataSource = dv;
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
        }
        private void xuLyComBoBox(ComboBox cmb, string ten, string ma, DataSet ds)
        {
            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
            cmb.SelectedIndex = -1;
        }
        private string xuLyThem(string sql, string ma,DataSet ds)
        {
            string kqua = "";
            ds = c.layDuLieu(sql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                kqua = 1.ToString();
                return kqua;
            }
            else
                kqua = ds.Tables[0].Rows[0][ma].ToString();
            return kqua;
        }
        private void clear()
        {
            txtMa.Clear();
            txtTongTien.Clear();
        }
        void taoCotHoaDonNhap()
        {
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.Columns.Add("MaHDNhap", "MaHDNhap");
            dgvDanhSach.Columns.Add("NgayLapHD", "NgayLapHD");
            dgvDanhSach.Columns.Add("TongTien", "TongTien");
            dgvDanhSach.Columns.Add("MaNXB", "MaNXB");
            dgvDanhSach.Columns.Add("MaNV", "MaNV");
            dgvDanhSach.Columns.Add("TrangThai", "TrangThai");

        }
        void taoCotCTHoaDonNhap()
        {
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add("MaCTSach", "MaCTSach");
            dgvChiTiet.Columns.Add("MaHDNhap", "MaHDNhap");
            dgvChiTiet.Columns.Add("SoLuong", "SoLuong");
            dgvChiTiet.Columns.Add("DonGia", "DonGia");
            dgvChiTiet.Columns.Add("ThanhTien", "ThanhTien");
            dgvChiTiet.Columns.Add("TrangThai", "TrangThai");

        }
        private void frmCTHoaDonNhap_Load(object sender, EventArgs e)
        {
            xuLyChuNang(true);
            xuLyTextBox(true);
            btnCTThem.Enabled = false;
            btnLayDonGia.Enabled = false;
            danhsach_datagridview(dgvDanhSach, "select * from HoaDonNhap");

            dsNXB = c.layDuLieu("select * from NhaXuatBan");
            xuLyComBoBox(cmbNXB, "TenNXB", "MaNXB", dsNXB);
            dsNV = c.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbNV, "TenNV", "MaNV", dsNV);
            dsSach = c.layDuLieu("select * from Sach");
            dsCTSach = c.layDuLieu("select * from ChiTietSach");
            dsNCC = c.layDuLieu("select * from NhaCungCap");
            xuLyComBoBox(cmbTenNCC, "TenNCC", "MaNCC", dsNCC);
            dsBia = c.layDuLieu("select * from LoaiBia");
            xuLyComBoBox(cmbTenBia, "TenBia", "MaBia", dsBia);

            dgvDsTen.DataSource = null;
            hienThiTextBox(dsHoaDonNhap, vitri);
            txtCTSoLuong.Text = "0";
            txtCTDonGia.Text = "0";
            int thanhTien = int.Parse(txtCTSoLuong.Text) * int.Parse(txtCTDonGia.Text);
            txtThanhTien.Text = thanhTien.ToString();
            bl = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            xuLyChuNang(false);
            xuLyTextBox(false);
            cmbTrangThai.SelectedIndex = 1;
            cmbCTTrangThai.SelectedIndex = 1;
            txtMa.Text = phatsinh();
            txtCTMaHDNhap.Text = phatsinh();

            xuLyComBoBox(cmbNXB, "TenNXB", "MaNXB", dsNXB);
            xuLyComBoBox(cmbNV, "TenNV", "MaNV", dsNV);
            dgvChiTiet.DataSource = null;
            dgvDanhSach.DataSource = null;
            taoCotHoaDonNhap();
            taoCotCTHoaDonNhap();
            flag = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            xuLyChuNang(false);
            xuLyTextBox(false);

            //dsNXB = c.layDuLieu("select * from NhaXuatBan");
            xuLyComBoBox(cmbNXB, "TenNXB", "MaNXB", dsNXB);
            //dsNV = c.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbNV, "TenNV", "MaNV", dsNV);
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
            string maNXB = "";
            string maNV = "";
            maNXB = xuLyThem("select MaNXB from NhaXuatBan where TenNXB = N'" + cmbNXB.Text + "'", "MaNXB",dsNXB);
            maNV = xuLyThem("select MaNV from NhanVien where TenNV = N'" + cmbNV.Text + "'", "MaNV",dsNV);
            string ngayLapHD = dtpNgayLapHD.Value.Month + "/" + dtpNgayLapHD.Value.Day + "/" + dtpNgayLapHD.Value.Year;

            if (flag == 1)
            {
                sql = "insert into HoaDonNhap values ( '" + txtMa.Text + "', N'" + ngayLapHD + "', " + txtTongTien.Text + ",'" + maNXB + "','" + maNV + "'," + cmbTrangThai.SelectedIndex + ")";
            }
            if (flag == 2)
            {
                sql = "update HoaDonNhap set NgayLapHD = N'" + ngayLapHD + "',TongTien = " + txtTongTien.Text + ",MaNXB = '" + maNXB + "',MaNV = '" + maNV + "', TrangThai =" + cmbTrangThai.SelectedIndex + " where MaHDNhap = '" + txtMa.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update HoaDonNhap set TrangThai ='" + 0 + "'where MaHDNhap ='" + txtMa.Text + "'";
            }
            if (c.capnhatdulieu(sql) > 0)
            {
                if (flag == 1)
                {
                    for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
                    {
                        string maCTSach = dgvChiTiet.Rows[i].Cells[0].Value.ToString();
                        string maHDNhap = dgvChiTiet.Rows[i].Cells[1].Value.ToString();
                        string soLuong = dgvChiTiet.Rows[i].Cells[2].Value.ToString();
                        string donGia = dgvChiTiet.Rows[i].Cells[3].Value.ToString();
                        string thanhTien = dgvChiTiet.Rows[i].Cells[4].Value.ToString();
                        sql1 = "insert into ChiTietHDNhap values ('" + maCTSach + "','" + maHDNhap + "','" + soLuong + "','" + donGia + "','" + thanhTien +"'," + cmbCTTrangThai.SelectedIndex + ")";
                        if (c.capnhatdulieu(sql1) > 0)
                        {
                            //MessageBox.Show("cập nhật thành công");
                            continue;

                        }
                    }
                }
                if (flag == 3)
                {
                    for (int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
                    {
                        string maHDNhap = dgvChiTiet.Rows[i].Cells[1].Value.ToString();
                        sql1 = "update ChiTietHDNhap set TrangThai ='" + 0 + "'where MaHDNhap ='" + maHDNhap + "'";
                        if (c.capnhatdulieu(sql1) > 0)
                        {
                            //MessageBox.Show("cập nhật thành công");
                            continue;

                        }
                    }
                }
                MessageBox.Show("cập nhật thành công");
                frmCTHoaDonNhap_Load(sender, e);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmCTHoaDonNhap_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bl == true)
            {
                string sql = "";
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string maHD = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string ngayLap = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string tongTien = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    string maNXB = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    string maNV = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    sql = "update HoaDonNhap set NgayLapHD = N'" + ngayLap + "',TongTien = " + tongTien + ",MaNXB = '" + maNXB + "',MaNV = '" + maNV + "' where MaHDNhap = '" + maHD + "'";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("cập nhật thành công");
                        frmCTHoaDonNhap_Load(sender, e);
                    }
                }
            }
        }

        private void txtCTSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                float soLuong  = float.Parse(txtCTSoLuong.Text);
                float donGia = float.Parse(txtCTDonGia.Text);
                txtThanhTien.Text = (soLuong*donGia).ToString();
            }
        }

        private void txtCTDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float soLuong = float.Parse(txtCTSoLuong.Text);
                float donGia = float.Parse(txtCTDonGia.Text);
                txtThanhTien.Text = (soLuong * donGia).ToString();
            }
        }

        private void Thêm_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            int a = 0;
            string maSach = xuLyThem("select MaSach from Sach where TenSach = N'" + txtMaCTSach.Text + "'", "MaSach",dsSach);
            string maBia = xuLyThem("select MaBia from LoaiBia where TenBia = N'" + cmbTenBia.Text + "'", "MaBia",dsBia);
            string maNCC = xuLyThem("select MaNCC from NhaCungCap where TenNCC = N'" + cmbTenNCC.Text + "'", "MaNCC",dsNCC);
            string maCT = xuLyThem("select MaCTSach from ChiTietSach where MaSach = '" + maSach + "' and MaBia = '" + maBia + "' and MaNCC = '" + maNCC + "'", "MaCTSach", dsCTSach);
            //string soLuong = xuLyThem("select SoLuong from ChiTietSach where MaCTSach = '" + maCT + "'", "SoLuong", dsCTSach);
            if (maCT == "1")
            {
                MessageBox.Show("Dữ liêu chưa có", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                float thanhTien = float.Parse(txtCTDonGia.Text) * float.Parse(txtCTSoLuong.Text);
                txtThanhTien.Text = thanhTien.ToString();
                object[] dsCT = new object[10];
                dsCT[0] = maCT;
                dsCT[1] = txtMa.Text;
                dsCT[2] = txtCTSoLuong.Text;
                dsCT[3] = txtCTDonGia.Text;
                dsCT[4] = txtThanhTien.Text;
                dsCT[5] = cmbCTTrangThai.SelectedIndex;
                for(int i = 0; i < dgvChiTiet.Rows.Count - 1; i++)
                {
                    if (dgvChiTiet.Rows[i].Cells[0].Value.ToString() == maCT)
                    {
                        MessageBox.Show("Chi tiết hóa đơn đã có", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        a = 1;
                        break;
                    }
                }
                if (a != 1)
                    dgvChiTiet.Rows.Add(dsCT);
                for (int i = 0;i < dgvChiTiet.Rows.Count - 1;i++)
                {
                    tongTien += int.Parse(dgvChiTiet.Rows[i].Cells[4].Value.ToString());
                }
                txtTongTien.Text = tongTien.ToString();
            }
            btnCTThem.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string maNXB = xuLyThem("select MaNXB from NhaXuatBan where TenNXB = N'" + cmbNXB.Text + "'", "MaNXB", dsNXB);
            string maNV = xuLyThem("select MaNV from NhanVien where TenNV = N'" + cmbNV.Text + "'", "MaNV", dsNV);
            string ngayLapHD = dtpNgayLapHD.Value.Month + "/" + dtpNgayLapHD.Value.Day + "/" + dtpNgayLapHD.Value.Year;
            object[] ds = new object[10];
            ds[0] = txtMa.Text;
            ds[1] = ngayLapHD;
            ds[2] = txtTongTien.Text;
            ds[3] = maNXB;
            ds[4] = maNV;
            ds[5] = cmbTrangThai.SelectedIndex;
            dgvDanhSach.Rows.Add(ds);

            locDuLieuComBoBox(cmbNV, "TenNV", "MaNV", dsNV, maNV);
            locDuLieuComBoBox(cmbNXB, "TenNXB", "MaNXB", dsNXB, maNXB);

            btnOK.Enabled= false;
            btnLayDonGia.Enabled = true;
        }

        private void txtCTSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnLayDonGia_Click(object sender, EventArgs e)
        {
            string maSach = xuLyThem("select MaSach from Sach where TenSach = N'" + txtMaCTSach.Text + "'", "MaSach", dsSach);
            string maBia = xuLyThem("select MaBia from LoaiBia where TenBia = N'" + cmbTenBia.Text + "'", "MaBia", dsBia);
            string maNCC = xuLyThem("select MaNCC from NhaCungCap where TenNCC = N'" + cmbTenNCC.Text + "'", "MaNCC", dsNCC);
            string maCT = xuLyThem("select MaCTSach from ChiTietSach where MaSach = '" + maSach + "' and MaBia = '" + maBia + "' and MaNCC = '" + maNCC + "'", "MaCTSach", dsCTSach);
            string donGia = xuLyThem("select DonGia from ChiTietSach where MaCTSach = N'" + maCT + "'", "DonGia", dsSach);
            txtCTDonGia.Text = donGia.ToString();
            btnCTThem.Enabled = true;
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bl == true)
            {
                string sql = "";
                string sql1 = "";
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string maCTSach = dgvChiTiet.CurrentRow.Cells[0].Value.ToString();
                    string soLuong = dgvChiTiet.CurrentRow.Cells[2].Value.ToString();
                    string donGia = xuLyThem("select DonGia from ChiTietSach where MaCTSach = '" + maCTSach + "'","DonGia",dsCTSach);
                    double thanhTien = double.Parse(soLuong.ToString()) * double.Parse(donGia.ToString());
                    sql = "update ChiTietHDNhap set SoLuong = " + soLuong + ",ThanhTien = '" + thanhTien.ToString() + "' where MaCTSach = '" + maCTSach + "' and MaHDNhap ='"+ txtMa.Text + "'" ;
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        frmCTHoaDonNhap_Load(sender, e);
                        double tongTien = 0;
                        for (int i = 0; i < dgvChiTiet.Rows.Count - 1;i++)
                        {
                            string thanhTien1 = dgvChiTiet.Rows[i].Cells[4].Value.ToString();
                            tongTien += double.Parse(thanhTien1.ToString());
                        }
                        sql1 = "update HoaDonNhap set TongTien ='" + tongTien.ToString() + "'where MaHDNhap ='" + txtMa.Text + "'";
                        if (c.capnhatdulieu(sql1) > 0)
                        {
                            MessageBox.Show("cập nhật thành công");
                        }
                        frmCTHoaDonNhap_Load(sender, e);
                    }
                }
            }
        }

        private void txtMaCTSach_TextChanged(object sender, EventArgs e)
        {
            string sql = "select MaSach,TenSach from Sach where TenSach like '%" + txtMaCTSach.Text + "%'";
            dsSach = c.layDuLieu(sql);
            dgvDsTen.DataSource = dsSach.Tables[0];
        }

        
    }
}
