using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;
using Newtonsoft.Json;

namespace Thiet_ke
{
    public partial class XoaLop : Form
    {
        private QuanLyDiem parent;
        private string maLop;
        private string tenHK;
        string FilePath = "lophocs.json";
        public XoaLop(string maLop, string tenHK, QuanLyDiem parent)
        {
            InitializeComponent();
            this.maLop = maLop;
            this.tenHK = tenHK;
            this.parent = parent;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Đọc file Lớp học và chuyển đổi đối tượng dưới dạng List
            List<Classroom> danhsachlophocs = Program.DocFile<List<Classroom>>(FilePath);

            //Tìm và xóa đối tượng LopHoc có mã trùng với mã lớp đang chọn để sửa
            ListClassroom.XoaLop(danhsachlophocs,this.maLop,this.tenHK);

            Program.GhiFile<List<Classroom>>(FilePath, danhsachlophocs);

            //Lấy lvLop của QuanLyDiem
            ListView lvlop = parent.lvLop;
            //Duyệt qua từng phần tử để lấy ra phần tử đang chọn và xóa nó
            foreach (ListViewItem item in lvlop.Items)
            {
                if (item.SubItems[0].Text == this.maLop && item.SubItems[2].Text == this.tenHK)
                {
                    lvlop.Items.Remove(item);
                }
            }
            MessageBox.Show("Xóa lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XoaLop_Load(object sender, EventArgs e)
        {

        }
    }
}
