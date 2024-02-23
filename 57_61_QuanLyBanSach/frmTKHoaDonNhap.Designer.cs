namespace _57_61_QuanLyBanSach
{
    partial class frmTKHoaDonNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAllHoaDon = new FontAwesome.Sharp.IconButton();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.cmbHoaNhap = new System.Windows.Forms.ComboBox();
            this.cmbNhaXuatBan = new System.Windows.Forms.ComboBox();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDanhSach);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 729);
            this.panel1.TabIndex = 0;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDanhSach.Location = new System.Drawing.Point(0, 216);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(1174, 513);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAllHoaDon);
            this.panel2.Controls.Add(this.dateNgayLap);
            this.panel2.Controls.Add(this.lblNgayLap);
            this.panel2.Controls.Add(this.cmbHoaNhap);
            this.panel2.Controls.Add(this.cmbNhaXuatBan);
            this.panel2.Controls.Add(this.cmbNhanVien);
            this.panel2.Controls.Add(this.lblKhachHang);
            this.panel2.Controls.Add(this.lblNhanVien);
            this.panel2.Controls.Add(this.lblMaHD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 216);
            this.panel2.TabIndex = 1;
            // 
            // btnAllHoaDon
            // 
            this.btnAllHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAllHoaDon.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAllHoaDon.IconColor = System.Drawing.Color.Black;
            this.btnAllHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAllHoaDon.Location = new System.Drawing.Point(903, 93);
            this.btnAllHoaDon.Name = "btnAllHoaDon";
            this.btnAllHoaDon.Size = new System.Drawing.Size(200, 43);
            this.btnAllHoaDon.TabIndex = 30;
            this.btnAllHoaDon.Text = "Tất cả hóa đơn";
            this.btnAllHoaDon.UseVisualStyleBackColor = true;
            this.btnAllHoaDon.Click += new System.EventHandler(this.btnAllHoaDon_Click);
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNgayLap.Location = new System.Drawing.Point(598, 140);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(207, 24);
            this.dateNgayLap.TabIndex = 29;
            this.dateNgayLap.ValueChanged += new System.EventHandler(this.dateNgayLap_ValueChanged);
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgayLap.Location = new System.Drawing.Point(415, 142);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(144, 23);
            this.lblNgayLap.TabIndex = 28;
            this.lblNgayLap.Text = "Ngày lập hóa đơn";
            this.lblNgayLap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbHoaNhap
            // 
            this.cmbHoaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbHoaNhap.FormattingEnabled = true;
            this.cmbHoaNhap.Location = new System.Drawing.Point(198, 93);
            this.cmbHoaNhap.Name = "cmbHoaNhap";
            this.cmbHoaNhap.Size = new System.Drawing.Size(208, 26);
            this.cmbHoaNhap.TabIndex = 19;
            this.cmbHoaNhap.SelectedIndexChanged += new System.EventHandler(this.cmbHoaNhap_SelectedIndexChanged);
            // 
            // cmbNhaXuatBan
            // 
            this.cmbNhaXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbNhaXuatBan.FormattingEnabled = true;
            this.cmbNhaXuatBan.Location = new System.Drawing.Point(198, 140);
            this.cmbNhaXuatBan.Name = "cmbNhaXuatBan";
            this.cmbNhaXuatBan.Size = new System.Drawing.Size(208, 26);
            this.cmbNhaXuatBan.TabIndex = 18;
            this.cmbNhaXuatBan.SelectedIndexChanged += new System.EventHandler(this.cmbNhaXuatBan_SelectedIndexChanged);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(598, 92);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(208, 26);
            this.cmbNhanVien.TabIndex = 20;
            this.cmbNhanVien.SelectedIndexChanged += new System.EventHandler(this.cmbNhanVien_SelectedIndexChanged);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblKhachHang.Location = new System.Drawing.Point(8, 142);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(161, 23);
            this.lblKhachHang.TabIndex = 23;
            this.lblKhachHang.Text = "Mã nhà xuất bản";
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNhanVien.Location = new System.Drawing.Point(412, 93);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(147, 23);
            this.lblNhanVien.TabIndex = 22;
            this.lblNhanVien.Text = "Mã nhân viên";
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaHD
            // 
            this.lblMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaHD.Location = new System.Drawing.Point(12, 93);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(157, 23);
            this.lblMaHD.TabIndex = 21;
            this.lblMaHD.Text = "Mã hóa đơn";
            this.lblMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1174, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "TÌM KIẾM HÓA ĐƠN NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTKHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTKHoaDonNhap";
            this.Text = "Hóa đơn nhập";
            this.Load += new System.EventHandler(this.frmTKHoaDonNhap_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHoaNhap;
        private System.Windows.Forms.ComboBox cmbNhaXuatBan;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private FontAwesome.Sharp.IconButton btnAllHoaDon;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}