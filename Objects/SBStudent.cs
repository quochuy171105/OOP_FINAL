using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thiet_ke.Objects
{
    public class SBStudent : ScoreBoard
    {
        public string maHS { get; set; }
        string filepath_BangdiemHS = "BDHS.json";
        private XemDiem_HS parentForm;

        public SBStudent(XemDiem_HS parent) : base()
        {
            this.parentForm = parent;
        }

        // Tạo BDHS cho tất cả học sinh để xem
        // Implement phương thức abstract từ class cha
        public override void luuBangDiem(string filepath, string maHocSinh, string maHocKy)
        {
            try
            {
                SBTeacher[] bangdiems = Program.DocFile<SBTeacher[]>(filepath);
                List<SBStudent> BDHSItems = new List<SBStudent>();

                foreach (SBTeacher diem in bangdiems)
                {
                    string maMonHoc = diem.maGiaoVien.Replace("GV", "");
                    double diemTrungBinh = (diem.diemGiuaKy + diem.diemCuoiKy) / 2;

                    SBStudent bdhsItem = new SBStudent(parentForm)
                    {
                        maHS = diem.maHS,
                        maHK = diem.maHK,
                        MonHoc = maMonHoc,
                        diemCuoiKy = diem.diemCuoiKy,
                        diemGiuaKy = diem.diemGiuaKy,
                        diemTongKet = diemTrungBinh
                    };

                    BDHSItems.Add(bdhsItem);
                }

                Program.GhiFile(filepath_BangdiemHS, BDHSItems);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu bảng điểm học sinh: {ex.Message}");
            }
        }
    }
}
