using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public partial class XoaHs : Form
    {
        private QuanLyDiem parent;
        private string maHS;
        private string filePath = "students.json";


        public XoaHs(string maHS, QuanLyDiem parent)
        {
            InitializeComponent();
            this.maHS = maHS;
            this.parent = parent;   
        }

        private void XoaHs_Load(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            ListStudent dsXoa = new ListStudent();
            dsXoa.Xoa(filePath, maHS);
            //Xóa xong tự cập nhật lại File JSON
                     
            DialogResult result = MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Close();
            }
            ListView lvSinhVien = parent.lvSinhVien;
            ListView lvLop = parent.lvLop;
            lvSinhVien.Items.Clear();
            if (lvLop.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvLop.SelectedItems[0];
                string maLop = selectedItem.SubItems[0].Text;

                lvSinhVien.Items.Clear();
                Student[] danhSachHocSinhs = DocFile<Student[]>(filePath);
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
