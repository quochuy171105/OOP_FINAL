using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    public class ListClassroom : IListUpdate<Classroom>, ISerializable
    {
        //trả về DS lớp học với các thao tác thêm xóa sửa
        private Classroom[] lophocs = new Classroom[10]; 
        public Classroom[] Lophocs
        {
            get { return lophocs; }
            set { lophocs = value; }
        }
        //Khởi tạo danh sách học sinh
        public ListClassroom() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Students", lophocs);
        }
        public ListClassroom(SerializationInfo info, StreamingContext context)
        {
            Lophocs = (Classroom[])info.GetValue("LopHoc", typeof(Classroom[]));
        }
        public Classroom[] taoDSLopHoc()
        {
            Classroom[] lophoc = new Classroom[]
            {
                  new Classroom { maLop = "2024L10A1", tenLop = "10A1",tenHK="HK1" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L10A2", tenLop = "10A2",tenHK="HK1" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L11A1", tenLop = "11A1",tenHK="HK1" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L11A2", tenLop = "11A2",tenHK="HK1" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L12A1", tenLop = "12A1",tenHK="HK1" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L12A2", tenLop = "12A2",tenHK="HK1" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L10A1", tenLop = "10A1",tenHK="HK2" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L10A2", tenLop = "10A2",tenHK="HK2" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L11A1", tenLop = "11A1",tenHK="HK2" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L11A2", tenLop = "11A2",tenHK="HK2" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L12A1", tenLop = "12A1",tenHK="HK2" ,tenNamHoc = 2024},
                  new Classroom { maLop = "2024L12A2", tenLop = "12A2",tenHK="HK2" ,tenNamHoc = 2024},
            };
            return lophoc;
        }
        public void Nhap(string filePath, Classroom lh)                              
        {
            //Đọc và thêm lớp mới vào file lớp
            List<Classroom> danhsachlophocs = Program.DocFile<List<Classroom>>(filePath);
            danhsachlophocs.Add(lh);
            Program.GhiFile(filePath, danhsachlophocs);
        }

        //Tìm kiếm theo mã Lớp
        public void TimKiem(ListView listView, string searchText)
        {
            searchText = searchText.Trim().ToLower(); // Trim để loại bỏ khoảng trắng ở đầu và cuối chuỗi
            foreach (ListViewItem item in listView.Items)
            {
                if (searchText != "")
                {
                    // Kiểm tra xem từ khóa có tồn tại không
                    if (item.Text.ToLower().Contains(searchText))
                    {
                        item.Selected = true;
                        item.Focused = true;
                        listView.EnsureVisible(item.Index);
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
        //Dùng cho xoá, sửa lớp
        public static void XoaLop(List<Classroom> danhSachLopHocs, string maLop, string tenHK) 
        {
            for (int i = danhSachLopHocs.Count - 1; i >= 0; i--)
            {
                if (danhSachLopHocs[i].maLop == maLop && danhSachLopHocs[i].tenHK == tenHK)
                {
                    danhSachLopHocs.RemoveAt(i);
                }
            }
        }
        public void Sua(string filePath, Classroom doiTuong) { }
        public void Xoa(string filePath, string maDoiTuong) { }
    }
}
