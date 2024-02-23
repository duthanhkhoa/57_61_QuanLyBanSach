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
    public partial class frmThongKeHDBan : Form
    {
        public frmThongKeHDBan()
        {
            InitializeComponent();
        }
        DataSet dsThongKe = new DataSet();
        cls57_61_QuanLyBanSach c = new cls57_61_QuanLyBanSach();
        void danhsach_datagridview(DataGridView d, string sql)
        {
            dsThongKe = c.layDuLieu(sql);
            d.DataSource = dsThongKe.Tables[0];
        }
        private void frmThongKeHDBan_Load(object sender, EventArgs e)
        {
            txtDoanhThu.ReadOnly = true;
            txtNgay.ReadOnly= true;
            txtThang.ReadOnly= true;
            txtNam.ReadOnly= true;
        }

        private void txtNgay_KeyDown(object sender, KeyEventArgs e)
        {
            int f = cmbChon.SelectedIndex;
            if (f == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (int.Parse(txtNgay.Text) < 0 || int.Parse(txtNgay.Text) > 31)
                    {
                        MessageBox.Show("Nhập ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (int.Parse(txtThang.Text) < 0 || int.Parse(txtThang.Text) > 12)
                    {
                        MessageBox.Show("Nhập tháng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double doanhThu = 0;
                        string a = "select * from HoaDonBan where Day(NgayLapHD) = '" + txtNgay.Text + "' and Month(NgayLapHD) = '" + txtThang.Text + "' and Year(NgayLapHD) = '" + txtNam.Text + "'";
                        danhsach_datagridview(dgvDanhSach, a);
                        for (int i = 0; i < dgvDanhSach.Rows.Count - 1; i++)
                        {
                            doanhThu += double.Parse(dgvDanhSach.Rows[i].Cells[2].Value.ToString());
                        }
                        txtDoanhThu.Text = doanhThu.ToString();
                    }
                    
                }
            }
            if (f == 1)
            {
                txtThang.ReadOnly= false;
                if (e.KeyCode == Keys.Enter)
                {
                    if (int.Parse(txtThang.Text) < 0 || int.Parse(txtThang.Text) > 12)
                    {
                        MessageBox.Show("Nhập tháng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        double doanhThu = 0;
                        string a = "select * from HoaDonBan where Month(NgayLapHD) = '" + txtThang.Text + "' and Year(NgayLapHD) = '" + txtNam.Text + "'";
                        danhsach_datagridview(dgvDanhSach, a);
                        for (int i = 0; i < dgvDanhSach.Rows.Count - 1; i++)
                        {
                            doanhThu += double.Parse(dgvDanhSach.Rows[i].Cells[2].Value.ToString());
                        }
                        txtDoanhThu.Text = doanhThu.ToString();

                    }   
                }
            }
            if (f == 2)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double doanhThu = 0;
                    string a = "select * from HoaDonBan where Year(NgayLapHD) = '" + txtNam.Text + "'";
                    danhsach_datagridview(dgvDanhSach, a);
                    for (int i = 0; i < dgvDanhSach.Rows.Count - 1; i++)
                    {
                        doanhThu += double.Parse(dgvDanhSach.Rows[i].Cells[2].Value.ToString());
                    }
                    txtDoanhThu.Text = doanhThu.ToString();
                }
            }
        }

        private void cmbChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int f = cmbChon.SelectedIndex;
            if (f == 0)
            {
                txtNgay.Text = "0";
                txtThang.Text = "0";
                txtNam.Text = "0";
                txtNgay.ReadOnly = false;
                txtThang.ReadOnly = false;
                txtNam.ReadOnly = false;
            }
            if (f == 1)
            {
                txtNgay.Text = "0";
                txtThang.Text = "0";
                txtNam.Text = "0";
                txtNgay.ReadOnly = true;
                txtThang.ReadOnly = false;
                txtNam.ReadOnly = false;
            }
            if (f == 2)
            {
                txtNgay.Text = "0";
                txtThang.Text = "0";
                txtNam.Text = "0";
                txtNam.ReadOnly = false;
                txtThang.ReadOnly = true;
                txtNgay.ReadOnly = true;
            }
        }
    }
}
