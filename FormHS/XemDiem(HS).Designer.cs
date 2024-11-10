namespace Thiet_ke
{
    partial class XemDiem_HS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XemDiem_HS));
            this.lvXemDiem = new System.Windows.Forms.ListView();
            this.clnTenMon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnGK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnCK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblHocKy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CBBHocKy = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMaHS = new System.Windows.Forms.Label();
            this.btncomeback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvXemDiem
            // 
            this.lvXemDiem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnTenMon,
            this.clnSTT,
            this.clnGK,
            this.clnCK,
            this.clnTB});
            this.lvXemDiem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvXemDiem.GridLines = true;
            this.lvXemDiem.HideSelection = false;
            this.lvXemDiem.Location = new System.Drawing.Point(36, 120);
            this.lvXemDiem.Name = "lvXemDiem";
            this.lvXemDiem.Size = new System.Drawing.Size(686, 305);
            this.lvXemDiem.TabIndex = 0;
            this.lvXemDiem.UseCompatibleStateImageBehavior = false;
            this.lvXemDiem.View = System.Windows.Forms.View.Details;
            // 
            // clnTenMon
            // 
            this.clnTenMon.DisplayIndex = 1;
            this.clnTenMon.Text = "Tên Môn Học";
            this.clnTenMon.Width = 150;
            // 
            // clnSTT
            // 
            this.clnSTT.DisplayIndex = 0;
            this.clnSTT.Text = "STT";
            this.clnSTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clnGK
            // 
            this.clnGK.Text = "Điểm giữa kỳ";
            this.clnGK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clnGK.Width = 150;
            // 
            // clnCK
            // 
            this.clnCK.Text = "Điểm cuối kỳ";
            this.clnCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clnCK.Width = 150;
            // 
            // clnTB
            // 
            this.clnTB.Text = "Điểm trung bình";
            this.clnTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clnTB.Width = 170;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocKy.ForeColor = System.Drawing.Color.Black;
            this.lblHocKy.Location = new System.Drawing.Point(547, 14);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(53, 15);
            this.lblHocKy.TabIndex = 2;
            this.lblHocKy.Text = "Học Kỳ: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(101, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Học sinh:";
            // 
            // CBBHocKy
            // 
            this.CBBHocKy.FormattingEnabled = true;
            this.CBBHocKy.Items.AddRange(new object[] {
            "Học kỳ I",
            "Học kỳ II"});
            this.CBBHocKy.Location = new System.Drawing.Point(617, 11);
            this.CBBHocKy.Name = "CBBHocKy";
            this.CBBHocKy.Size = new System.Drawing.Size(121, 23);
            this.CBBHocKy.TabIndex = 5;
            this.CBBHocKy.SelectedIndexChanged += new System.EventHandler(this.CBBHocKy_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Controls.Add(this.lblMaHS);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBBHocKy);
            this.groupBox1.Controls.Add(this.lblHocKy);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 42);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(420, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Năm: 2024";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.ForeColor = System.Drawing.Color.Black;
            this.lblHoTen.Location = new System.Drawing.Point(178, 16);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(59, 15);
            this.lblHoTen.TabIndex = 8;
            this.lblHoTen.Text = "HoTenHS";
            // 
            // lblMaHS
            // 
            this.lblMaHS.AutoSize = true;
            this.lblMaHS.Location = new System.Drawing.Point(6, 19);
            this.lblMaHS.Name = "lblMaHS";
            this.lblMaHS.Size = new System.Drawing.Size(41, 15);
            this.lblMaHS.TabIndex = 6;
            this.lblMaHS.Text = "MaHS";
            // 
            // btncomeback
            // 
            this.btncomeback.BackColor = System.Drawing.Color.Teal;
            this.btncomeback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btncomeback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btncomeback.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncomeback.ForeColor = System.Drawing.SystemColors.Control;
            this.btncomeback.Location = new System.Drawing.Point(647, 431);
            this.btncomeback.Name = "btncomeback";
            this.btncomeback.Size = new System.Drawing.Size(75, 36);
            this.btncomeback.TabIndex = 8;
            this.btncomeback.Text = "Quay lại";
            this.btncomeback.UseVisualStyleBackColor = false;
            this.btncomeback.Click += new System.EventHandler(this.btncomeback_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(781, 40);
            this.label1.TabIndex = 23;
            this.label1.Text = "BẢNG ĐIỂM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XemDiem_HS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(778, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncomeback);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvXemDiem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XemDiem_HS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Điểm_HS";
            this.Load += new System.EventHandler(this.XemDiem_HS_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvXemDiem;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBBHocKy;
        private System.Windows.Forms.ColumnHeader clnTenMon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader clnSTT;
        private System.Windows.Forms.ColumnHeader clnGK;
        private System.Windows.Forms.ColumnHeader clnCK;
        private System.Windows.Forms.ColumnHeader clnTB;
        private System.Windows.Forms.Label lblMaHS;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Button btncomeback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}