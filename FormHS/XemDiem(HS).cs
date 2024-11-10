using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Thiet_ke
{
    public partial class XemDiem_HS : Form
    {
        string filepath_BangdiemHS = "BDHS.json";
        string filePath_BDGVs = "BDGV.json";
        public XemDiem_HS(Student hocSinh)
        {
            InitializeComponent();
            CurrentStudent = hocSinh;
            lblMaHS.Text = CurrentStudent.maHS.ToString();
            lblHoTen.Text = CurrentStudent.hoVaTenLot.ToString() + " " + CurrentStudent.ten.ToString();
        }
        private Student CurrentStudent;
        private void btncomeback_Click(object sender, EventArgs e)
        {
            AccountHS accountHS = new AccountHS();
            accountHS.ShowDialog();
            this.Close();
        }

        private void CBBHocKy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy mã học sinh và học kỳ từ đăng nhập và comboBox học kỳ
            string maHS = CurrentStudent.maHS.ToString();
            string maHK = CBBHocKy.SelectedItem.ToString();

            // Đọc danh sách điểm từ BDGV.json
            SBTeacher[] bangDiemGVs = Program.DocFile<SBTeacher[]>(filePath_BDGVs);
            SBStudent[] bangDiemHSs = Program.DocFile<SBStudent[]>(filepath_BangdiemHS);

            // Cập nhật điểm từ bangDiemGVs vào bangDiemHSs
            foreach (var updatedScore in bangDiemGVs)
            {
                if (updatedScore.maHS == maHS && updatedScore.maHK == maHK)
                {
                    var existingScore = bangDiemHSs.FirstOrDefault(s =>
                        s.maHS == maHS &&
                        s.maHK == maHK &&
                        s.MonHoc == updatedScore.maGiaoVien.Replace("GV", ""));

                    if (existingScore != null)
                    {
                        // Cập nhật điểm hiện có
                        existingScore.diemGiuaKy = updatedScore.diemGiuaKy;
                        existingScore.diemCuoiKy = updatedScore.diemCuoiKy;
                        existingScore.diemTongKet = updatedScore.diemTongKet;
                    }
                    else
                    {
                        // Thêm mới điểm cho học sinh
                        bangDiemHSs = bangDiemHSs.Concat(new SBStudent[]
                        {
                    new SBStudent(null)
                    {
                        maHS = updatedScore.maHS,
                        maHK = updatedScore.maHK,
                        MonHoc = updatedScore.maGiaoVien.Replace("GV", ""),
                        diemGiuaKy = updatedScore.diemGiuaKy,
                        diemCuoiKy = updatedScore.diemCuoiKy,
                        diemTongKet = updatedScore.diemTongKet
                    }
                        }).ToArray();
                    }
                }
            }

            // Lưu danh sách đã cập nhật vào bdhs.json
            Program.GhiFile(filepath_BangdiemHS, bangDiemHSs);
            // Cập nhật ListView
            RefreshScoreView();
        }

        private void UpdateListView(string maHS, string maHK)
        {
            // Tạo Bảng điểm HS mới
            SBStudent[] bangdiemHSs = Program.DocFile<SBStudent[]>(filepath_BangdiemHS);
            List<SBStudent> diemHS = bangdiemHSs.Where(d => d.maHS == maHS && d.maHK == maHK).ToList();

            lvXemDiem.Items.Clear(); 
            int stt = 1; // Biến đếm số thứ tự
            foreach (SBStudent diem in diemHS)
            {
                ListViewItem ViewDiemHS = new ListViewItem(diem.MonHoc);
                ViewDiemHS.SubItems.Add(stt.ToString());
                ViewDiemHS.SubItems.Add(diem.diemGiuaKy.ToString());
                ViewDiemHS.SubItems.Add(diem.diemCuoiKy.ToString());
                ViewDiemHS.SubItems.Add(diem.diemTongKet.ToString());

                lvXemDiem.Items.Add(ViewDiemHS);
                stt++;
            }
        }
        private void RefreshScoreView()
        {
            string maHS = CurrentStudent.maHS.ToString();
            string maHK = CBBHocKy.SelectedItem.ToString();
            UpdateListView(maHS, maHK);
        }

        private void XemDiem_HS_Load(object sender, EventArgs e)
        {
            RefreshScoreView();
        }

        private void XemDiem_HS_Load_1(object sender, EventArgs e)
        {

        }
    }
}
