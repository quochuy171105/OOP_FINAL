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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Thiet_ke
{
    public partial class SuaHs : Form
    {
        private string maHS;
        private QuanLyDiem parent;
        string filePath = "students.json";
        public SuaHs(string maHS, QuanLyDiem parentForm)
        {
            InitializeComponent();
            this.maHS = maHS;
            this.parent = parentForm;
        }

        private void SuaHs_Load(object sender, EventArgs e)
        {
            string filePath = "students.json";

            string json = File.ReadAllText(filePath);

            Student[] danhSachHocSinhs = JsonConvert.DeserializeObject<Student[]>(json);

            Student hocSinh = null;
            foreach (Student hs in danhSachHocSinhs)
            {
                if (hs.maHS == maHS)
                {
                    hocSinh = hs;
                    break;
                }
            }
            if (hocSinh != null)
            {
                txtMahs.Text = hocSinh.maHS;
                txtho.Text = hocSinh.hoVaTenLot;
                txtTen.Text = hocSinh.ten;
                if (hocSinh.gioiTinh == 1)
                {
                    rBtnNam.Checked = true;

                }
                else { rBtnNu.Checked = true; }
                txtSDT.Text = hocSinh.soDienThoai;
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            string hoVaTenLot = txtho.Text;
            string ten = txtTen.Text;
            int gioiTinh = rBtnNam.Checked ? 1 : 0;
            string soDienThoai = txtSDT.Text;

            ListStudent dsSua = new ListStudent();


            //thay đổi propeties
            Student[] danhSachHocSinhs = DocFile<Student[]>(filePath);
            foreach (Student hocSinh in danhSachHocSinhs)
            {
                if (hocSinh.maHS == maHS)
                {
                    hocSinh.hoVaTenLot = hoVaTenLot;
                    hocSinh.ten = ten;
                    hocSinh.gioiTinh = gioiTinh;
                    hocSinh.soDienThoai = soDienThoai;
                    dsSua.Sua(filePath, hocSinh); //đã ghi thay đổi vào file
                }
            }

            DialogResult result = MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Close();
            }
            System.Windows.Forms.ListView lvSinhVien = parent.lvSinhVien;
            System.Windows.Forms.ListView lvLop = parent.lvLop;
            lvSinhVien.Items.Clear();
            if (lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                string maLop = selectedItem.SubItems[0].Text;

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
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        static T DocFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                T data = JsonConvert.DeserializeObject<T>(json);
                Console.WriteLine("Đã đọc file JSON thành công.");
                return data;
            }
            else
            {
                Console.WriteLine("File không tồn tại.");
                return default(T);
            }
        }
    }

}
