namespace Test_App
{
    partial class GiaoDienChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaoDienChinh));
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnThanhVien = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnQuanAo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.Image")));
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(370, 300);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(328, 117);
            this.btnKhachHang.TabIndex = 0;
            this.btnKhachHang.Text = "     Khách &Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnThanhVien
            // 
            this.btnThanhVien.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhVien.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhVien.Image")));
            this.btnThanhVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhVien.Location = new System.Drawing.Point(370, 482);
            this.btnThanhVien.Name = "btnThanhVien";
            this.btnThanhVien.Size = new System.Drawing.Size(328, 114);
            this.btnThanhVien.TabIndex = 2;
            this.btnThanhVien.Text = "     &T&hành Viên";
            this.btnThanhVien.UseVisualStyleBackColor = true;
            this.btnThanhVien.Click += new System.EventHandler(this.btnThanhVien_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnHoaDon.Image")));
            this.btnHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDon.Location = new System.Drawing.Point(916, 300);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(330, 117);
            this.btnHoaDon.TabIndex = 1;
            this.btnHoaDon.Text = "     &Hoá Đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnQuanAo
            // 
            this.btnQuanAo.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanAo.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanAo.Image")));
            this.btnQuanAo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanAo.Location = new System.Drawing.Point(916, 482);
            this.btnQuanAo.Name = "btnQuanAo";
            this.btnQuanAo.Size = new System.Drawing.Size(330, 114);
            this.btnQuanAo.TabIndex = 3;
            this.btnQuanAo.Text = " Quần &Áo";
            this.btnQuanAo.UseVisualStyleBackColor = true;
            this.btnQuanAo.Click += new System.EventHandler(this.btnQuanAo_Click);
            // 
            // GiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1544, 884);
            this.Controls.Add(this.btnThanhVien);
            this.Controls.Add(this.btnQuanAo);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnKhachHang);
            this.Name = "GiaoDienChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GiaoDienChinh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnThanhVien;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnQuanAo;
    }
}