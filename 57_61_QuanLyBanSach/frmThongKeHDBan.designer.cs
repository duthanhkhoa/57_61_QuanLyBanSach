namespace _57_61_QuanLyBanSach
{
    partial class frmThongKeHDBan
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.mahdnhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaylaphd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manxb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.txtNgay = new System.Windows.Forms.TextBox();
            this.cmbChon = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(815, 75);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thống Kê HD Bán";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Chọn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Năm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Doanh Thu";
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(112, 139);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(138, 22);
            this.txtDoanhThu.TabIndex = 13;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahdnhap,
            this.ngaylaphd,
            this.tongtien,
            this.manxb,
            this.manv});
            this.dgvDanhSach.Location = new System.Drawing.Point(8, 182);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(790, 327);
            this.dgvDanhSach.TabIndex = 14;
            // 
            // mahdnhap
            // 
            this.mahdnhap.DataPropertyName = "MaHDBan";
            this.mahdnhap.HeaderText = "MaHDBan";
            this.mahdnhap.MinimumWidth = 6;
            this.mahdnhap.Name = "mahdnhap";
            // 
            // ngaylaphd
            // 
            this.ngaylaphd.DataPropertyName = "NgayLapHD";
            this.ngaylaphd.HeaderText = "NgayLapHD";
            this.ngaylaphd.MinimumWidth = 6;
            this.ngaylaphd.Name = "ngaylaphd";
            // 
            // tongtien
            // 
            this.tongtien.DataPropertyName = "TongTien";
            this.tongtien.HeaderText = "TongTien";
            this.tongtien.MinimumWidth = 6;
            this.tongtien.Name = "tongtien";
            // 
            // manxb
            // 
            this.manxb.DataPropertyName = "MaKH";
            this.manxb.HeaderText = "MaNXB";
            this.manxb.MinimumWidth = 6;
            this.manxb.Name = "manxb";
            // 
            // manv
            // 
            this.manv.DataPropertyName = "MaNV";
            this.manv.HeaderText = "MaNV";
            this.manv.MinimumWidth = 6;
            this.manv.Name = "manv";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(691, 98);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(84, 22);
            this.txtNam.TabIndex = 10;
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgay_KeyDown);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(514, 97);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(84, 22);
            this.txtThang.TabIndex = 11;
            this.txtThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgay_KeyDown);
            // 
            // txtNgay
            // 
            this.txtNgay.Location = new System.Drawing.Point(333, 95);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(84, 22);
            this.txtNgay.TabIndex = 12;
            this.txtNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgay_KeyDown);
            // 
            // cmbChon
            // 
            this.cmbChon.FormattingEnabled = true;
            this.cmbChon.Items.AddRange(new object[] {
            "Theo Ngày",
            "Theo Tháng",
            "Theo Năm"});
            this.cmbChon.Location = new System.Drawing.Point(112, 95);
            this.cmbChon.Name = "cmbChon";
            this.cmbChon.Size = new System.Drawing.Size(138, 24);
            this.cmbChon.TabIndex = 9;
            this.cmbChon.SelectedIndexChanged += new System.EventHandler(this.cmbChon_SelectedIndexChanged);
            // 
            // frmThongKeHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 570);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.txtNgay);
            this.Controls.Add(this.cmbChon);
            this.Controls.Add(this.label4);
            this.Name = "frmThongKeHDBan";
            this.Text = "Thống Kê Hóa Đơn Bán";
            this.Load += new System.EventHandler(this.frmThongKeHDBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.TextBox txtNgay;
        private System.Windows.Forms.ComboBox cmbChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahdnhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaylaphd;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn manxb;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
    }
}