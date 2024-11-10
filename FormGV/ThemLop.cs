using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public partial class ThemLop : Form
    {
        private QuanLyDiem parent;
        string FilePath = "lophocs.json";
        public ThemLop(QuanLyDiem parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<Classroom> danhsachlophocs= Program.DocFile<List<Classroom>>(FilePath);

            //Tạo đối tượng lớp học mới để lưu vào file Json
            Classroom SuaLop = new Classroom();
            SuaLop.maLop = "2024L" + txtTenLop.Text;
            SuaLop.tenLop = txtTenLop.Text;
            SuaLop.tenHK = txtHocKy.Text;
            SuaLop.tenNamHoc = int.Parse(txtNamHoc.Text);

            //Thêm lớp mới vào listView và danhsachlophocs
            ListView lvlop = parent.lvLop;
            ListViewItem newLop = new ListViewItem("2024L" + txtTenLop.Text);
            newLop.SubItems.Add(txtTenLop.Text);
            newLop.SubItems.Add(txtHocKy.Text);
            newLop.SubItems.Add(txtNamHoc.Text);
            parent.lvLop.Items.Add(newLop);
            
            //Thêm lớp
            ListClassroom dSLopHoc = new ListClassroom();
            dSLopHoc.Nhap(FilePath, SuaLop);
            this.Close();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemLop_Load(object sender, EventArgs e)
        {

        }
    }
}
