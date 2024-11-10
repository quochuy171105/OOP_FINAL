using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    public class ListStudent : IListUpdate<Student>, ISerializable
    {
        //trả về DS học sinh với các thao tác thêm xóa sửa
        private Student[] students = new Student[50]; 
        public Student[] Students
        {
            get { return students; }
            set { students = value; }
        }

        public ListStudent() { }
        //lưu trữ dữ liệu students vào SerializationInfo.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Students", students);
        }
        //dùng để giải tuần tự (deserialize) dữ liệu students.
        public ListStudent(SerializationInfo info, StreamingContext context)
        {
            Students = (Student[])info.GetValue("Students", typeof(Student[]));
        }
        //Khởi tạo danh sách học sinh
        public Student[] taoDSHocSinh() {
            Student[] hocSinhs = new Student[]
                {
                    new Student { maHS = "HS1", maLop = "2024L10A1", hoVaTenLot = "Hồ Ngọc", ten ="Hà", gioiTinh =0, soDienThoai ="0215036840", tenDangNhap ="userHS1", matKhau ="passwordHS1"},
                    new Student { maHS = "HS2", maLop = "2024L10A1", hoVaTenLot = "Trấn", ten ="Thành", gioiTinh =1, soDienThoai ="0203225675", tenDangNhap ="userHS2", matKhau ="passwordHS2"},
                    new Student { maHS = "HS3", maLop = "2024L10A1", hoVaTenLot = "Ninh Dương Lan", ten ="Ngọc", gioiTinh =0, soDienThoai ="0575167887", tenDangNhap ="userHS3", matKhau ="passwordHS3"},
                    new Student { maHS = "HS4", maLop = "2024L10A2", hoVaTenLot = "Đàm Vĩnh", ten ="Hưng", gioiTinh =1, soDienThoai ="0199375109", tenDangNhap ="userHS4", matKhau ="passwordHS4"},
                    new Student { maHS = "HS5", maLop = "2024L10A2", hoVaTenLot = "Phạm Mỹ", ten ="Tâm", gioiTinh =0, soDienThoai ="0308599075", tenDangNhap ="userHS5", matKhau ="passwordHS5"},
                    new Student { maHS = "HS6", maLop = "2024L10A2", hoVaTenLot = "Hoàng Thùy", ten ="Linh", gioiTinh =0, soDienThoai ="0735576304", tenDangNhap ="userHS6", matKhau ="passwordHS6"},
                    new Student { maHS = "HS7", maLop = "2024L11A1", hoVaTenLot = "Mai Hồng", ten ="Ngọc", gioiTinh =0, soDienThoai ="0115470656", tenDangNhap ="userHS7", matKhau ="passwordHS7"},
                    new Student { maHS = "HS8", maLop = "2024L11A1", hoVaTenLot = "Mai Hồng", ten ="Vũ", gioiTinh =1, soDienThoai ="0709710523", tenDangNhap ="userHS8", matKhau ="passwordHS8"},
                    new Student { maHS = "HS9", maLop = "2024L11A1", hoVaTenLot = "Nguyễn Thanh", ten ="Tùng", gioiTinh =1, soDienThoai ="0584462094", tenDangNhap ="userHS9", matKhau ="passwordHS9"},
                    new Student { maHS = "HS10", maLop = "2024L11A2", hoVaTenLot = "Trần Đăng", ten ="Khoa", gioiTinh =1, soDienThoai ="0580251684", tenDangNhap ="userHS10", matKhau ="passwordHS10"},
                    new Student { maHS = "HS11", maLop = "2024L11A2", hoVaTenLot = "Châu Đông", ten ="Vũ", gioiTinh =0, soDienThoai ="0590376355", tenDangNhap ="userHS11", matKhau ="passwordHS11"},
                    new Student { maHS = "HS12", maLop = "2024L11A2", hoVaTenLot = "Trịnh Thăng", ten ="Bình", gioiTinh =1, soDienThoai ="0999032150", tenDangNhap ="userHS12", matKhau ="passwordHS12"},
                    new Student { maHS = "HS13", maLop = "2024L12A1", hoVaTenLot = "Vũ Cát", ten ="Tường", gioiTinh =0, soDienThoai ="0658855849", tenDangNhap ="userHS13", matKhau ="passwordHS13"},
                    new Student { maHS = "HS14", maLop = "2024L12A1", hoVaTenLot = "Nghiêm Vũ Hoàng", ten ="Long", gioiTinh =1, soDienThoai ="0834680366", tenDangNhap ="userHS14", matKhau ="passwordHS14"},
                    new Student { maHS = "HS15", maLop = "2024L12A1", hoVaTenLot = "Nguyễn Thảo", ten ="Linh", gioiTinh =0, soDienThoai ="0531845212", tenDangNhap ="userHS15", matKhau ="passwordHS15"},
                    new Student { maHS = "HS16", maLop = "2024L12A2", hoVaTenLot = "Nguyễn Thúc Thùy", ten ="Tiên", gioiTinh =0, soDienThoai ="0920560514", tenDangNhap ="userHS16", matKhau ="passwordHS16"},
                    new Student { maHS = "HS17", maLop = "2024L12A2", hoVaTenLot = "Lê Nguyễn Trung", ten ="Đan", gioiTinh =1, soDienThoai ="0539477335", tenDangNhap ="userHS17", matKhau ="passwordHS17"},
                    new Student { maHS = "HS18", maLop = "2024L12A2", hoVaTenLot = "Trần Thiện Thanh", ten ="Bảo", gioiTinh =1, soDienThoai ="0905043801", tenDangNhap ="userHS18", matKhau ="passwordHS18"},
                };
            return hocSinhs;
        }

        public void Nhap(string filePath, Student hs)
        {
            Student[] hocSinhs = Program.DocFile<Student[]>(filePath); //đọc danh sách học sinh hiện có từ tệp JSON.
            List<Student> danhSachHocSinhs = new List<Student>(hocSinhs);
            // Thêm đối tượng HocSinh mới vào danh sách
            danhSachHocSinhs.Add(hs);
            hocSinhs = (Student[])danhSachHocSinhs.ToArray();
            Program.GhiFile("students.json", hocSinhs); //ghi danh sách mới vào tệp students.json.
        }

        public void Sua(string filePath, Student hs)
        {
            //lấy đối tượng HocSinh được tạo từ form -> xóa đối tượng hocSinh dùng phương thức Xoa() -> thay với chỉ số
            Student[] hocSinhs = Program.DocFile<Student[]>(filePath);
            for (int i = 0; i < hocSinhs.Length; i++) // tìm học sinh cần cập nhật và sửa đổi các thuộc tính.
            {
                if (hocSinhs[i].maHS == hs.maHS)
                {
                    hocSinhs[i].maHS = hs.maHS;
                    hocSinhs[i].hoVaTenLot = hs.hoVaTenLot;
                    hocSinhs[i].ten = hs.ten;
                    hocSinhs[i].gioiTinh = hs.gioiTinh;
                    hocSinhs[i].soDienThoai = hs.soDienThoai;
                }
            }
            Program.GhiFile("students.json", hocSinhs); //ghi danh sách đã cập nhật vào tệp.
        }

        public void Xoa(string filePath, string maHS)
        {
            Student[] hocSinhs = Program.DocFile<Student[]>(filePath);
            for (int i = 0; i < hocSinhs.Length; i++)
            {
                if (hocSinhs[i].maHS == maHS)
                {
                    for (int j = i + 1; j < hocSinhs.Length; j++)
                    {
                        hocSinhs[j - 1] = hocSinhs[j];
                    }
                }
            }
            Program.GhiFile("students.json", hocSinhs);
        }
        // Tìm kiếm theo mã hs
        public void TimKiem(ListView listView, string searchText)
        {
            searchText = searchText.Trim().ToLower(); 
            foreach (ListViewItem item in listView.Items)
            {
                if (searchText != "")
                {
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
    }
}
