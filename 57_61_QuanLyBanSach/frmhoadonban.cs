using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; // 1
using System.Text.RegularExpressions; // 2
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods; //3
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar; //4
using System.Web;
using Syncfusion.Office;

namespace _57_61_QuanLyBanSach
{
    public partial class frmhoadonban : Form
    {
        public frmhoadonban()
        {
            InitializeComponent();
        }
        // Danh sách để lọc dữ liệu vào cmb
        DataSet dsNhanVien = new DataSet();
        DataSet dsKhachHang = new DataSet();
        DataSet dsCTHoaDonBan = new DataSet();
        DataSet dsTenSach = new DataSet();
        DataSet dsBia = new DataSet();
        DataSet dsNhaCungCap = new DataSet();

        cls57_61_QuanLyBanSach hoadonban = new cls57_61_QuanLyBanSach();
        DataSet ds = new DataSet();

        int viTri = 0, vitri = 0;
        Boolean bl = false;
        string makh = "";

        Boolean flagds = false;
        void danhsach_datagridview(DataGridView d, string sql)
        {
            ds = hoadonban.layDuLieu(sql);
            d.DataSource = null;
            dgvDanhSach_HDBan.Columns.Clear();
            d.DataSource = ds.Tables[0];
        }

        void hienthitextbox(DataSet ds, int vt)
        {
            txtMaHD.Text = ds.Tables[0].Rows[vt]["MaHDBan"].ToString();
            txtMaKH.Text = ds.Tables[0].Rows[vt]["MaKH"].ToString();
            txtMaNV.Text = ds.Tables[0].Rows[vt]["MaNV"].ToString();

            //Hiển thị ngày tháng năm
            string datestring = ds.Tables[0].Rows[vt]["NgaylapHD"].ToString();
            DateTime datavalue = DateTime.Parse(datestring);
            datatNgayLap.Value = datavalue;

            //lọc dữ liệu vào combobox
            string manv = ds.Tables[0].Rows[vt]["MaNV"].ToString();
            string makh = ds.Tables[0].Rows[vt]["MaKH"].ToString();
            string trangthai = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            cmbTrangThai.Text = trangthai;

            LocDuLieuComBoBox(cmbTenNV, "TenNV", "MaNV", dsNhanVien, manv);
            LocDuLieuComBoBox(cmbTenKH, "TenKh", "MaKH", dsKhachHang, makh);

            load_cthdbantheomahd(ds.Tables[0].Rows[vt]["MaHDBan"].ToString());

            txtMaHDBan.Text = txtMaHD.Text;
        }

        private void taoAnh(PictureBox pic, string file)
        {
            Bitmap a = new Bitmap(file);
            pic.Image = a;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void dgvDanhSach_HDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viTri = e.RowIndex;
            hienthitextbox(ds, viTri);
            xulychucnang_ct(false);
        }

        private void LocDuLieuComBoBox(ComboBox cmb, string ten, string ma, DataSet ds, string giaitri)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + " ='" + giaitri + "'";
            cmb.DataSource = dv;
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
        }

        private void hienthidatatime()
        {
            datatNgayLap.Format = DateTimePickerFormat.Custom;
        }

        private void xuLyComBoBox(ComboBox cmb, string ten, string ma, DataSet ds)
        {
            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember = ten;
            cmb.ValueMember = ma;
            cmb.SelectedIndex = -1;
        }

        private void load_cthdbantheomahd(string ma)
        {
            string sql = "select * from ChiTietHDBan where MaHDBan = '" + ma + "'";
            dsCTHoaDonBan = hoadonban.layDuLieu(sql);
            dgvDanhSach_CTHDBan.DataSource = null;
            dgvDanhSach_CTHDBan.Columns.Clear();
            dgvDanhSach_CTHDBan.DataSource = dsCTHoaDonBan.Tables[0];
        }

        string maphatsinh()
        {
            string mahd = "";
            mahd = (ds.Tables[0].Rows.Count + 1).ToString();
            return "HDB" + mahd;
        }
        int flag = 0;

        private void xulychucnang(Boolean a)
        {
            btnLuu.Enabled = !a;
            btnHuy.Enabled = !a;
            btnThem.Enabled = a;
            btnXoa.Enabled = a;
            btnSua.Enabled = a;
            btnKhachHangM.Enabled = !a;
            btnTim.Enabled = !a;
            
        }

        private void xulychucnang_ct(Boolean a)
        {
            btnThemCT.Enabled = a;
            btnTinh.Enabled = !a;
            //btnAnh.Enabled = a;
        }

        private void xulychucnang_e(Boolean e)
        {
            btnThemCT.Enabled = e;
            btnTinh.Enabled = e;
            //btnAnh.Enabled = e;
        }

        private void xulytextbox(Boolean a)
        {
            txtMaHD.Enabled = a;
            txtMaKH.Enabled = a;
            txtMaNV.Enabled = a;
            datatNgayLap.Enabled = a;
            txtSDT.Enabled = a;
            cmbTenNV.Enabled = a;
            cmbTrangThai.Enabled = a;
        }

        private void xulytextbox_ct(Boolean a)
        {
            txtMaHDBan.Enabled = a;
            txtDonGia.Enabled = a;
            lblThanhTien.Enabled = a;
        }

        private void xuly_textbox(Boolean a)
        {
            txtMaHD.ReadOnly = a;
            txtMaKH.ReadOnly = a;
            txtMaNV.ReadOnly = a;
            txtMaHDBan.ReadOnly = a;
            
        }

        private string xuLyThem(string sql, string ma)
        {
            string kqua = "";
            DataSet maThem = new DataSet();
            maThem = hoadonban.layDuLieu(sql);
            kqua = maThem.Tables[0].Rows[0][ma].ToString();
            return kqua;
        }

        private void clear()
        { 
            txtMaKH.Clear();
            txtMaNV.Clear();
            txtSDT.Clear();
            cmbTenNV.SelectedIndex = -1;
            cmbTrangThai.SelectedIndex = 0;
        }

        private void clear_ct()
        {
            txtMaCTSach.Clear();
            txtMaHDBan.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            lblThanhTien.Text = "";
        }

        void taoCotHoaDonBan()
        {
            dgvDanhSach_HDBan.Columns.Clear();
            dgvDanhSach_HDBan.Columns.Add("MaHDBan", "Mã hóa bán");
            dgvDanhSach_HDBan.Columns.Add("NgayLapHD", "Ngày lập hóa đơn");
            dgvDanhSach_HDBan.Columns.Add("TongTien", "Tổng tiền");
            dgvDanhSach_HDBan.Columns.Add("MaKH", "Mã khách hàng");
            dgvDanhSach_HDBan.Columns.Add("MaNV", "Mã nhân viên");
            dgvDanhSach_HDBan.Columns.Add("TrangThai", "Trạng thái");

        }
        void taoCotCTHoaDonBan()
        {
            dgvDanhSach_CTHDBan.Columns.Clear();
            dgvDanhSach_CTHDBan.Columns.Add("MaCTSach", "Mã chi tiết hóa bán");
            dgvDanhSach_CTHDBan.Columns.Add("MaHDBan", "Mã hóa đơn bán");
            dgvDanhSach_CTHDBan.Columns.Add("SoLuong", "Số Lượng");
            dgvDanhSach_CTHDBan.Columns.Add("DonGia", "Đơn giá");
            dgvDanhSach_CTHDBan.Columns.Add("ThanhTien", "Thành tiền");
            dgvDanhSach_CTHDBan.Columns.Add("HinhAnh", "Hình Ảnh");
            dgvDanhSach_CTHDBan.Columns.Add("TrangThai", "Trạng thái");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulychucnang_ct(false);
            xulytextbox(true);
            xuly_textbox(true);
            xulychucnang_e(true);
            clear();
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";

            dsNhanVien = hoadonban.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbTenNV, "TenNV", "MaNV", dsNhanVien);

            dsKhachHang = hoadonban.layDuLieu("select * from KhachHang");
            xuLyComBoBox(cmbTenKH, "TenKh", "MaKH", dsKhachHang);

            txtMaHD.Text = maphatsinh();
            dgvDanhSach_HDBan.DataSource = null;
            dgvDanhSach_CTHDBan.DataSource = null;
            taoCotHoaDonBan();
            taoCotCTHoaDonBan();

            datatNgayLap.Value = DateTime.Now;
            cmbTrangThai.SelectedIndex = 1;
            cmbTrangThaiCT.SelectedIndex = 1;
            flag = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytextbox(true);
            xuly_textbox(true);

            flag = 3;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            clear();
            xulychucnang(false);
            xulychucnang_ct(false);
            xulytextbox(true);
            xuly_textbox(true);
            dgvDanhSach_CTHDBan.DataSource = null;
            taoCotCTHoaDonBan();

            dsNhanVien = hoadonban.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbTenNV, "TenNV", "MaNV", dsNhanVien);

            dsKhachHang = hoadonban.layDuLieu("select * from KhachHang");
            xuLyComBoBox(cmbTenKH, "TenKh", "MaKH", dsKhachHang);

            cmbTrangThai.SelectedIndex = 1;
            cmbTrangThaiCT.SelectedIndex = 1;
            flag = 2;
        }

        int tongtien = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Boolean flags = false;
            

            string sql = "";
            string manv = "";
            string makh = "";
            string sql1 = "";
            if(flag == 1)
            {
                if (MessageBox.Show("Bạn có muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    flags = true;
                }
                else
                {
                    flags = false;
                }
            }

            if (flag == 2)
            {
                if (MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    flags = true;
                }
                else
                {
                    flags = false;
                }
            }

            if (flag == 3)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    flags = true;
                }
                else
                {
                    flags = false;
                }
            }


            if (flag == 1 && flags || flag == 2 && flags)
            {
                manv = xuLyThem("select MaNV from NhanVien where TenNV = N'" + cmbTenNV.Text + "'", "MaNV");
                makh = xuLyThem("select MaKH from KhachHang where TenKh = N'" + cmbTenKH.Text + "'", "MaKH");
            }

           if (flag == 1 && flags)
            {
                sql = "insert into HoaDonBan values ('" + txtMaHD.Text + "', '" + datatNgayLap.Text + "', '" + lblTongTien.Text + "' ,'" + makh + "', '" + manv + "', '" + 1 + "')";
            }

            if (flag == 2 && flags)
            {
                sql = "update HoaDonBan set NgaylapHD = '" + datatNgayLap.Text + ", MaKH = '" + makh + "', MaNV = '" + manv + "', TrangThai = '" + cmbTrangThai.SelectedIndex + "' where MaHDBan = '" + txtMaHD.Text + "'";
            }

            if (flag == 3 && flags)
            {
                sql = "update HoaDonBan set TrangThai = '" + 0 + "' where MaHDBan = '" + txtMaHD.Text + "'";
                if (hoadonban.capnhatdulieu(sql) > 0 && flags)
                {
                    for (int i = 0; i < dgvDanhSach_CTHDBan.Rows.Count - 1; i++)
                    {
                        string mahdban = dgvDanhSach_CTHDBan.Rows[i].Cells[1].Value.ToString();
                        sql1 = "update ChiTietHDBan set TrangThai ='" + 0 + "'where MaHDBan ='" + mahdban + "'";
                        if (hoadonban.capnhatdulieu(sql1) > 0)
                        {
                            continue;
                        }
                    }
                }
                    
            }

            if (flags)
            {
                if (flag == 1 && hoadonban.capnhatdulieu(sql) > 0)
                {
                    for (int i = 0; i < dgvDanhSach_CTHDBan.Rows.Count - 1; i++)
                    {
                        string maCTSach = dgvDanhSach_CTHDBan.Rows[i].Cells[0].Value.ToString();
                        string mahdban = dgvDanhSach_CTHDBan.Rows[i].Cells[1].Value.ToString();
                        string soLuong = dgvDanhSach_CTHDBan.Rows[i].Cells[2].Value.ToString();
                        string donGia = dgvDanhSach_CTHDBan.Rows[i].Cells[3].Value.ToString();
                        string thanhTien = dgvDanhSach_CTHDBan.Rows[i].Cells[4].Value.ToString();
                        string hinhanh = dgvDanhSach_CTHDBan.Rows[i].Cells[5].Value.ToString();

                        sql1 = "insert into ChiTietHDBan values ('" + maCTSach + "','" + mahdban + "','" + soLuong + "','" + donGia + "','" + thanhTien + "','" + hinhanh + "'," + cmbTrangThaiCT.SelectedIndex + ")";
                        if (hoadonban.capnhatdulieu(sql1) > 0)
                        {
                            continue;

                        }
                    }
                }
                if (flags)
                {
                    xulychucnang(true);
                    xulychucnang_ct(false);
                    xulytextbox(false);
                    xulytextbox_ct(false);
                }
                MessageBox.Show("cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                frmhoadonban_Load(sender, e);
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulychucnang_ct(false);
            xulytextbox(false);
            xulytextbox_ct(false);

            frmhoadonban_Load(sender, e);
        }

        private void frmhoadonban_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytextbox(false);
            xulytextbox_ct(false);
            xulychucnang_e(false);
            //xuLyTrangThai();
            hienthidatatime();
            txtHinhAnh.Hide();

            danhsach_datagridview(dgvDanhSach_HDBan, "select * from HoaDonBan where TrangThai = 1");

            // Hóa đơn bán
            dsNhanVien = hoadonban.layDuLieu("select * from NhanVien");
            xuLyComBoBox(cmbTenNV, "TenNV", "MaNV", dsNhanVien);

            dsKhachHang = hoadonban.layDuLieu("select * from KhachHang");
            xuLyComBoBox(cmbTenKH, "TenKh", "MaKH", dsKhachHang);

            hienthitextbox(ds, viTri);
            flagds = true;
            bl = true;
        }

        private string tinhtien()
        {
            Boolean kt_ctsach = true;
            
            string mactsach = txtMaCTSach.Text.ToString();
            try
            {
                if (mactsach == null)
                {
                    MessageBox.Show("Chưa chọn tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    kt_ctsach = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string dongia, tinhtien;
            float dongia_ct = 0, sl = 0;
            
            if (kt_ctsach)
            {
                dongia = xuLyThem("select DonGia from ChiTietSach where MaCTSach = '" + mactsach + "'", "DonGia");
                dongia_ct = float.Parse(dongia.ToString());
                txtDonGia.Text = dongia_ct.ToString();
                sl = float.Parse(txtSoLuong.Text.ToString());
            }

            return tinhtien = (dongia_ct * sl).ToString();
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            string mactsach = txtMaCTSach.Text.ToString();
            int tongtien = 0;
            int a = 0;
            if(mactsach == "1")
            {
                MessageBox.Show("Dữ liêu chưa có", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                float thanhTien = float.Parse(txtDonGia.Text) * float.Parse(txtSoLuong.Text);
                lblThanhTien.Text = thanhTien.ToString();
                object[] dsCT = new object[10];
                dsCT[0] = mactsach;
                dsCT[1] = txtMaHD.Text;
                dsCT[2] = txtSoLuong.Text;
                dsCT[3] = txtDonGia.Text;
                dsCT[4] = lblThanhTien.Text;
                dsCT[5] = txtHinhAnh.Text;
                dsCT[6] = cmbTrangThaiCT.Text;
                for (int i = 0; i < dgvDanhSach_CTHDBan.Rows.Count - 1; i++)
                {
                    if (dgvDanhSach_CTHDBan.Rows[i].Cells[0].Value.ToString() == mactsach)
                    {
                        MessageBox.Show("Chi tiết hóa đơn đã có", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        a = 1;
                        break;
                    }
                }
                if (a != 1)
                    dgvDanhSach_CTHDBan.Rows.Add(dsCT);
                for (int i = 0; i < dgvDanhSach_CTHDBan.Rows.Count - 1; i++)
                {
                    tongtien += int.Parse(dgvDanhSach_CTHDBan.Rows[i].Cells[4].Value.ToString());
                }
                lblTongTien.Text = tongtien.ToString();
            }

            //xulychucnang_ct(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSach_HDBan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagds)
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach_HDBan.CurrentRow.Index;
                    string mahdban = dgvDanhSach_HDBan.CurrentRow.Cells[0].Value.ToString();
                    string ngaylaphd = dgvDanhSach_HDBan.CurrentRow.Cells[1].Value.ToString();
                    string makh = dgvDanhSach_HDBan.CurrentRow.Cells[3].Value.ToString();
                    string manv = dgvDanhSach_HDBan.CurrentRow.Cells[4].Value.ToString();
                    string trangthai = dgvDanhSach_HDBan.CurrentRow.Cells[5].Value.ToString();

                    string sql = "update HoaDonBan set NgayLapHD = '" + ngaylaphd + "', MaKH = '" + makh + "', MaNV = '" + manv + "', TrangThai = '" + trangthai + "' where MaHDBan = '" + mahdban + "'";
                    if (hoadonban.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        viTri = 0;
                        frmhoadonban_Load(sender, e);
                    }
                }


        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            //xulytextbox_ct(true);
            xuly_textbox(true);
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            //xulytextbox_ct(true);
            xuly_textbox(true);
        }

        private void dgvDanhSach_CTHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(bl == true)
            {
                string sql = "";
                string sql1 = "";
                if(e.ColumnIndex >= 1)
                {
                    int tongsoluong = 0;
                    int vt = dgvDanhSach_HDBan.CurrentRow.Index;
                    string soluong = dgvDanhSach_CTHDBan.CurrentRow.Cells[2].Value.ToString();
                    string mactsach = dgvDanhSach_CTHDBan.CurrentRow.Cells[0].Value.ToString();
                    for (int i = 0; i < dsCTHoaDonBan.Tables[0].Rows.Count; i++)
                    {
                        tongsoluong += int.Parse(dsCTHoaDonBan.Tables[0].Rows[i]["SoLuong"].ToString());
                    }
                    txtSoLuong.Text = tongsoluong.ToString();
                }
            }

            string hinhanh = dgvDanhSach_CTHDBan.CurrentRow.Cells[5].Value.ToString();
            txtHinhAnh.Text = hinhanh;


            string tenfile = Path.GetFullPath("image_book") + @"\" + hinhanh;
            taoAnh(picHinhAnh, tenfile);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (txtMaCTSach.Text == "")
            {
                MessageBox.Show("Chưa có mã chi sách", "Thông báo");
                return;
            }

            if (txtSoLuong.Text == "0")
            {
                MessageBox.Show("Chưa nhập số lượng", "Thông báo");
                return;
            }
            lblThanhTien.Text = tinhtien();
            xulychucnang_ct(true);
            //btnTinh.Enabled = true;
            //btnThemCT.Enabled = false;

            string hinhAnh = xuLyThem("select HinhAnh from ChiTietSach where MaCTSach = N'" + txtMaCTSach.Text + "'", "HinhAnh");

            string tenfile = Path.GetFullPath("image_book") + @"\" + hinhAnh;

            taoAnh(picHinhAnh, tenfile);

            txtHinhAnh.Text = hinhAnh;
        }

        private void dgvDanhSach_CTHDBan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flagds)
                if (e.ColumnIndex >= 1)
                {
                    string sqll, sql;

                    int vt = dgvDanhSach_CTHDBan.CurrentRow.Index;
                    string mactsach = dgvDanhSach_CTHDBan.CurrentRow.Cells[0].Value.ToString();
                    string mahdban = dgvDanhSach_CTHDBan.CurrentRow.Cells[1].Value.ToString();
                    string soluong = dgvDanhSach_CTHDBan.CurrentRow.Cells[2].Value.ToString();
                    string dongia = dgvDanhSach_CTHDBan.CurrentRow.Cells[3].Value.ToString();

                    double thanhtien = double.Parse(soluong.ToString()) * double.Parse(dongia.ToString());

                    sql = "update ChiTietHDBan set SoLuong = '" + soluong + "', DonGia = '" + dongia + "', ThanhTien = '" + thanhtien.ToString() + "' where MaCTSach = '" + mactsach + "'";
                    if (hoadonban.capnhatdulieu(sql) > 0)
                    {
                        frmhoadonban_Load(sender, e);
                        double tongtien = 0;
                        for (int i = 0; i < dgvDanhSach_CTHDBan.Rows.Count - 1; i++)
                        {
                            string thanhtien1 = dgvDanhSach_CTHDBan.Rows[i].Cells[4].Value.ToString();
                            tongtien += double.Parse(thanhtien1.ToString());
                        }

                        sqll = "update HoaDonBan set TongTien = '" + tongtien.ToString() + "' where MaHDBan = '" + mahdban + "'";

                        if (hoadonban.capnhatdulieu(sqll) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                        }
                        frmhoadonban_Load(sender, e);
                    }
                }

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        Boolean timSDTKH()
        {
            ds = hoadonban.layDuLieu("select * from KhachHang where SDT = '" + txtSDT.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                makh = ds.Tables[0].Rows[0]["MaKH"].ToString();
                txtMaKH.Text = makh;
                cmbTenKH.Text = ds.Tables[0].Rows[0]["TenKH"].ToString();
                return true;
            }
            return false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text != " ")
                if (!timSDTKH())
                    MessageBox.Show("Không tìm thấy số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
        }

        private void btnKhachHangM_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
            makh = f.makh1;
            cmbTenKH.Text = f.tenkh1;
            txtSDT.Text = f.sdt1;
        }

        private void frmhoadonban_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog hinhAnh = new OpenFileDialog();
            hinhAnh.InitialDirectory = Path.GetFullPath("image_book") + @"\";
            hinhAnh.ShowDialog();
            string tenFile = hinhAnh.FileName;
            if( tenFile != "")
            {
                string[] tenhinh = tenFile.Split('\\');
                string a = tenhinh[9] + "\\" + tenhinh[10];
                Bitmap anh = new Bitmap(tenFile);
                picHinhAnh.Image = anh;
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                txtHinhAnh.Text = a;


                btnThemCT.Enabled = true;
                btnTinh.Enabled = false;
            }
            else
            {
                MessageBox.Show("Chưa chọn hình ảnh!", "Thông báo");
            }
            
        }
    }
}
