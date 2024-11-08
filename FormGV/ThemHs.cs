using Newtonsoft.Json;
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
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public partial class ThemHs : Form
    {
        private string maLop;
        private string maHS;
        private QuanLyDiem parent;
        string filePath = "students.json";
        

        public ThemHs(QuanLyDiem parent, string maLop)
        {
            InitializeComponent();
            this.parent = parent;
            this.maLop = maLop;
        }

        private void ThemHs_Load(object sender, EventArgs e)
        {
            Student[] danhSachHocSinhs = DocFile<Student[]>(filePath);
            maHS = "HS" + (danhSachHocSinhs.Length + 1).ToString();
            txtMahs.Text = maHS;
            txtMahs.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHS = this.maHS;
            maLop = this.maLop;
            string hoVaTenLot = txtho.Text;
            string ten = txtTen.Text;
            int gioiTinh = rBtnNam.Checked ? 1 : 0;
            string soDienThoai = txtSDT.Text;
            string username = taoTaiKhoan(maHS);
            string password = taoMatKhau(maHS);


            //thay đổi propeties
            
            Student hsMoi = new Student(maHS, maLop ,hoVaTenLot, ten, gioiTinh, soDienThoai, username, password);

            ListStudent dsNhap = new ListStudent();
            dsNhap.Nhap(filePath, hsMoi); //=> Lưu vào file json
            Student[] danhSachHocSinhs = DocFile<Student[]>(filePath);
            ;
            ListView lvSinhVien = parent.lvSinhVien;
            ListView lvLop = parent.lvLop;
            lvSinhVien.Items.Clear();
            if (lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                maLop = selectedItem.SubItems[0].Text;

                lvSinhVien.Items.Clear();
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
            DialogResult result = MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        static T DocFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
            else
            {
                return default(T);
            }
        }
        static string taoTaiKhoan(string maHS) {
            return "user" + maHS;
        }
        static string taoMatKhau(string maHS)
        {
            return "password" + maHS;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
