using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public static class Program
    {
        [STAThread]
        public static void GhiFile<T>(string filePath, T data)
        {
            try
            {
                //Chuyển đổi data(dữ liệu đầu vào) thành chuỗi JSON, với định dạng dễ đọc(Indented).
                string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Đã ghi file JSON thành công.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Lỗi khi ghi file: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Lỗi khi chuyển đổi dữ liệu sang JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        public static T DocFile<T>(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                T data = JsonConvert.DeserializeObject<T>(json); //Chuyển đổi chuỗi JSON thành đối tượng kiểu T
                Console.WriteLine("Đã đọc file JSON thành công.");
                return data;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
                return default(T);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Lỗi khi chuyển đổi dữ liệu từ JSON: {ex.Message}");
                return default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                return default(T);
            }

        }
        static void Main()
        {
            string filePath_students = "students.json";
            string filePath_teachers = "teachers.json";
            string filePath_monHocs = "monHocs.json";
            string filePath_lophocs = "lophocs.json";
            string filePath_BDGVs = "BDGV.json";

            // Ghi danh sách học sinh vào file JSON => 18 bạn, một lớp 3 bạn
            ListStudent dsHocSinh = new ListStudent();
            Student[] hocSinhs = dsHocSinh.taoDSHocSinh();
            //Ghi danh sách giáo viên vào file JSON => 13 giáo viên, một giáo viên dạy một môn
            ListTeacher dSGiaoVien = new ListTeacher();
            Teacher[] giaoViens = dSGiaoVien.taoDSGiaoVien();
            //Ghi danh sách môn học vào file JSON => 13 môn học, nhưng chỉ lấy 2 môn của 1 khối thoy
            ListSubject dsMonHoc = new ListSubject();
            Subject[] monHocs = dsMonHoc.taoDSMonHoc();
            // Ghi danh sách lớp học vào file JSON => 6 bạn, 3 lớp 10, 2 lớp 11, 1 lớp 12
            ListClassroom dsLopHoc = new ListClassroom();
            Classroom[] lophocs = dsLopHoc.taoDSLopHoc();
            //ghi bảng điểm giáo viên và json => 2gv - 6 lớp - 18 bạn
            ListSBTeacher dSBangDiemGV = new ListSBTeacher();
            SBTeacher[] bangDiemGVs = dSBangDiemGV.taoDSBDGV();

            GhiFile(filePath_students, hocSinhs);
            GhiFile(filePath_teachers, giaoViens);
            GhiFile(filePath_monHocs, monHocs);
            GhiFile(filePath_lophocs, lophocs);
            GhiFile(filePath_BDGVs, bangDiemGVs);

            // Đọc danh sách học sinh từ file JSON
            Student[] danhSachHocSinhs = DocFile<Student[]>(filePath_students);
            Teacher[] danhSachGiaoViens = DocFile<Teacher[]>(filePath_teachers);
            Subject[] danhSachMonHocs = DocFile<Subject[]>(filePath_monHocs);
            SBTeacher[] dsbdgvcs = DocFile<SBTeacher[]>(filePath_BDGVs);

            Application.EnableVisualStyles(); //Bật kiểu giao diện người dùng hiện đại cho ứng dụng Windows Forms.
            Application.SetCompatibleTextRenderingDefault(false); //Đặt chế độ kết xuất văn bản mặc định.
            Application.Run(new DangNhap()); // Chạy ứng dụng, bắt đầu với màn hình đăng nhập(DangNhap).

        }
    }
}
