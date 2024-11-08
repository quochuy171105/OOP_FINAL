using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public partial class QuanLyDiem : Form
    {
        // Thêm dữ liệu học sinh từ file
        public string filePath { get; set; } 

        private Teacher CurrentTeacher;

        public QuanLyDiem(Teacher teacher)
        {
            InitializeComponent();
            CurrentTeacher = teacher;
            btncomeback.Click += btncomeback_Click;
            lblTenGV.Text = CurrentTeacher.hoVaTenLot + " " + CurrentTeacher.ten;
            lblMon.Text = CurrentTeacher.maGV;
        }

        private void GiaoVien_Load(object sender, EventArgs e)
        {

            // thêm dữ liệu lớp học
            string FilePath = "lophocs.json";
            //Đọc dữ liệu lớp học từ tệp Json
            Classroom[] danhsachLophocs = Program.DocFile<Classroom[]>(FilePath);

            //Hiển thị lên ListView
            foreach (Classroom lophoc in danhsachLophocs)
            {
                ListViewItem item = new ListViewItem(lophoc.maLop);
                item.SubItems.Add(lophoc.tenLop);
                item.SubItems.Add(lophoc.tenHK);
                item.SubItems.Add(lophoc.tenNamHoc.ToString());

                lvLop.Items.Add(item);
            }
        }
        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            NhapDiem nhapDiem = new NhapDiem(lblMon.Text);
            nhapDiem.ComebackButtonClicked += btncomeback_Click;
            nhapDiem.ShowDialog();
            
        }

        private void btnSuaSv_Click(object sender, EventArgs e)
        {

            if (lvSinhVien.SelectedItems.Count > 0 && lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSinhVien.SelectedItems[0];
                string maHocSinh = selectedItem.SubItems[0].Text;

                SuaHs suaHS = new SuaHs(maHocSinh, this);
                suaHS.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Lớp và Học Sinh cần chỉnh sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count > 0)
            {
                // Lấy lớp được chọn trong listViewStudents
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                string maLop = selectedItem.SubItems[0].Text;
                string tenHK = selectedItem.SubItems[2].Text;

                // Hiển thị form EditForm và truyền maLop vào
                SuaLop suaLop = new SuaLop(maLop, tenHK, this);
                suaLop.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void lvLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                string maLop = selectedItem.SubItems[0].Text;

                HienThiDanhSachHocSinhTheoLop(maLop);
            }
        }
        private void HienThiDanhSachHocSinhTheoLop(string maLop)
        {
            filePath = "students.json";
            lvSinhVien.Items.Clear();
            Student[] danhSachHocSinhs = Program.DocFile<Student[]>(filePath);
            foreach (Student hocSinh in danhSachHocSinhs)
            {
                if (hocSinh.maLop == maLop)
                {
                    ListViewItem item = new ListViewItem(hocSinh.maHS);
                    item.SubItems.Add(hocSinh.hoVaTenLot);
                    item.SubItems.Add(hocSinh.ten);
                    item.SubItems.Add(hocSinh.gioiTinh == 0 ? "Nữ" : "Nam");
                    item.SubItems.Add(hocSinh.soDienThoai);
                    item.SubItems.Add(hocSinh.tenDangNhap);
                    item.SubItems.Add(hocSinh.matKhau);
                    lvSinhVien.Items.Add(item);
                }
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count > 0)
            {
                // Lấy lớp được chọn trong listViewStudents
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                string maLop = selectedItem.SubItems[0].Text;
                string tenHK = selectedItem.SubItems[2].Text;

                XoaLop xoalop = new XoaLop(maLop, tenHK, this);
                xoalop.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Lớp cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnNhapLop_Click(object sender, EventArgs e)
        {
            ThemLop themlop = new ThemLop(this);
            themlop.ShowDialog();
        }

        private void btnXoaSv_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0 && lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSinhVien.SelectedItems[0];
                string maHocSinh = selectedItem.SubItems[0].Text;

                XoaHs xoaHS = new XoaHs(maHocSinh, this);
                xoaHS.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Lớp và Học Sinh cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNhapHS_Click(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                string maLop = selectedItem.SubItems[0].Text;

                ThemHs themHS = new ThemHs(this, maLop);
                themHS.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Lớp cần thêm Học sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btncomeback_Click(object sender, EventArgs e)
        {
            AccountGV accountGV = new AccountGV();
            accountGV.Show();
            this.Close();
        }

        //Tìm kiếm theo mã lớp
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ListClassroom dsLopHoc = new ListClassroom();
            dsLopHoc.TimKiem(lvLop, txtSearch.Text);
        }

        //Tìm kiếm theo mã học sinh
        private void txtSearchhs_TextChanged(object sender, EventArgs e)
        {
            ListStudent dsHS = new ListStudent();
            dsHS.TimKiem(lvSinhVien, txtSearchhs.Text);
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
