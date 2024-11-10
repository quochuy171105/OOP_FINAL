using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;
using System.IO;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;

namespace Thiet_ke
{
    public partial class NhapDiem : Form
    {
        public NhapDiem(string maGV)
        {
            InitializeComponent();
            lblmaGV.Text = maGV;
        }
        string filePath = "students.json";
        string filePaths = "BDGV.json";
        string filepath_BangdiemHS = "BDHS.json";

        public void HienThiDanhSachHocSinhTheoLop(string maLop)
        {
            lvDiem.Items.Clear();
            Student[] danhSachHocSinhs = Program.DocFile<Student[]>(filePath);
            foreach (Student hocSinh in danhSachHocSinhs)
            {
                if (hocSinh.maLop == maLop)
                {
                    ListViewItem item = new ListViewItem(hocSinh.maHS);
                    item.SubItems.Add(hocSinh.hoVaTenLot);
                    item.SubItems.Add(hocSinh.ten);
                    lvDiem.Items.Add(item);
                }
            }
        }
        public void HienThiDanhSachTheoMaHS(string maHS)
        {

        }
        private void lvDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDiem.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDiem.SelectedItems[0];
                selectedItem.Selected = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string maLop = (string)MaLop.Text;
            HienThiDanhSachHocSinhTheoLop(maLop);
        }

        private void btnHK_Click(object sender, EventArgs e)
        {
            btnHK.Text = btnHK.Text == "Học Kỳ II" ? "Học Kỳ I" : "Học Kỳ II";
            if (btnHK.Text == "Học Kỳ I")
            {
                grbNhapDiem.Visible = false;

                lvDiem.Items.Clear(); // Clear the list view before adding new items
                Student[] danhSachHocSinhs = Program.DocFile<Student[]>(filePath);
                SBTeacher[] bangDiemGVs = Program.DocFile<SBTeacher[]>(filePaths);

                List<SBTeacher> bangDiemGVsForSemester = new List<SBTeacher>();

                foreach (SBTeacher bangDiemGV in bangDiemGVs)
                {
                    if (bangDiemGV.maHK == "Học kỳ I")
                    {
                        bangDiemGVsForSemester.Add(bangDiemGV);
                    }
                }

                foreach (Student hocSinh in danhSachHocSinhs)
                {
                    if (hocSinh.maLop == MaLop.Text)
                    {
                        ListViewItem item = new ListViewItem(hocSinh.maHS);
                        item.SubItems.Add(hocSinh.hoVaTenLot);
                        item.SubItems.Add(hocSinh.ten);

                        SBTeacher bangDiemGV = null;
                        foreach (SBTeacher bdg in bangDiemGVsForSemester)
                        {
                            if (bdg.maHS == hocSinh.maHS && bdg.maGiaoVien == lblmaGV.Text && bdg.maHK == "Học kỳ I")
                            {
                                bangDiemGV = bdg;
                                break;
                            }
                        }

                        if (bangDiemGV != null)
                        {
                            item.SubItems.Add(bangDiemGV.diemGiuaKy.ToString()); item.SubItems.Add(bangDiemGV.diemCuoiKy.ToString());
                            item.SubItems.Add(bangDiemGV.diemTongKet.ToString());
                        }
                        else
                        {
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                        }

                        lvDiem.Items.Add(item);
                    }
                }
            }
            else
            {
                grbNhapDiem.Visible = true;
                lvDiem.Items.Clear(); // Clear the list view before adding new items
                Student[] danhSachHocSinhs = Program.DocFile<Student[]>(filePath);
                SBTeacher[] bangDiemGVs = Program.DocFile<SBTeacher[]>(filePaths);

                List<SBTeacher> bangDiemGVsForSemester = new List<SBTeacher>();

                foreach (SBTeacher bangDiemGV in bangDiemGVs)
                {
                    if (bangDiemGV.maHK == "Học kỳ II")
                    {
                        bangDiemGVsForSemester.Add(bangDiemGV);
                    }
                }

                foreach (Student hocSinh in danhSachHocSinhs)
                {
                    if (hocSinh.maLop == MaLop.Text)
                    {
                        ListViewItem item = new ListViewItem(hocSinh.maHS);
                        item.SubItems.Add(hocSinh.hoVaTenLot);
                        item.SubItems.Add(hocSinh.ten);

                        SBTeacher bangDiemGV = null;
                        foreach (SBTeacher bdg in bangDiemGVsForSemester)
                        {
                            if (bdg.maHS == hocSinh.maHS && bdg.maGiaoVien == lblmaGV.Text && bdg.maHK == "Học kỳ II")
                            {
                                bangDiemGV = bdg;
                                break;
                            }
                        }

                        if (bangDiemGV != null)
                        {
                            item.SubItems.Add(bangDiemGV.diemGiuaKy.ToString()); item.SubItems.Add(bangDiemGV.diemCuoiKy.ToString());
                            item.SubItems.Add(bangDiemGV.diemTongKet.ToString());
                        }
                        else
                        {
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                        }

                        lvDiem.Items.Add(item);
                    }
                }
            }
        }
        public SBTeacher[] taoDSBDGV()
        {
            SBTeacher[] bangDiemGVs = Program.DocFile<SBTeacher[]>(filePaths);
            // Thay đổi các giá trị điểm trong bangDiemGVs 
            return bangDiemGVs;
        }

        public void btnLuu_Click_1(object sender, EventArgs e)
        {
            string maHS = txtMaHS.Text;
            string maGV = lblmaGV.Text;
            string maHK = "Học kỳ II";
            float diemGK = float.Parse(txtDiemGK.Text);
            float diemCK = float.Parse(txtDiemCK.Text);

            Student[] danhSachHocSinhs = Program.DocFile<Student[]>(filePath);
            SBTeacher[] bangDiemGVs = Program.DocFile<SBTeacher[]>(filePaths);

            // Tìm kiếm học sinh tương ứng
            Student hocSinh = null;
            for (int i = 0; i < danhSachHocSinhs.Length; i++)
            {
                if (danhSachHocSinhs[i].maHS == maHS)
                {
                    hocSinh = danhSachHocSinhs[i];
                    break;
                }
            }

            if (hocSinh != null)
            {
                // Tìm kiếm điểm của học sinh tương ứng
                SBTeacher bangDiemGV = null;
                for (int i = 0; i < bangDiemGVs.Length; i++)
                {
                    if (bangDiemGVs[i].maHS == maHS && bangDiemGVs[i].maGiaoVien == maGV && bangDiemGVs[i].maHK == maHK)
                    {
                        bangDiemGV = bangDiemGVs[i];
                        break;
                    }
                }

                if (bangDiemGV != null)
                {
                    // Tạo một đối tượng của class BangDiemGV
                    bangDiemGV.diemGiuaKy = diemGK;
                    bangDiemGV.diemCuoiKy = diemCK;
                    bangDiemGV.diemTongKet = (diemGK + diemCK) / 2;
                    lvDiem.Items.Clear();
                    lvDiem.Items.Clear();
                    foreach (Student student in danhSachHocSinhs)
                    {
                        if (student.maLop == MaLop.Text)
                        {
                            ListViewItem item = new ListViewItem(student.maHS);
                            item.SubItems.Add(student.hoVaTenLot);
                            item.SubItems.Add(student.ten);
                            // Tìm điểm của học sinh trong danh sách bangDiemGVs
                            SBTeacher grade = null;
                            for (int j = 0; j < bangDiemGVs.Length; j++)
                            {
                                if (bangDiemGVs[j].maHS == student.maHS && bangDiemGVs[j].maGiaoVien == maGV && bangDiemGVs[j].maHK == maHK)
                                {
                                    grade = bangDiemGVs[j];
                                    break;
                                }
                            }
                            if (grade != null)
                            {
                                item.SubItems.Add(grade.diemGiuaKy.ToString());
                                item.SubItems.Add(grade.diemCuoiKy.ToString());
                                item.SubItems.Add(grade.diemTongKet.ToString());
                            }
                            else
                            {
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                            }
                            lvDiem.Items.Add(item);
                        }
                    }

                    try
                    {
                        // Cập nhật bảng điểm
                        bangDiemGV.CapNhatBangDiem(bangDiemGV, lvDiem, filePaths);

                        // Cập nhật bảng điểm học sinh
                        UpdateStudentScoresFromBDGV(filePaths);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật bảng điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm của học sinh này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy học sinh này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateStudentScoresFromBDGV(string filepath_BDGV)
        {
            try
            {
                // Đọc danh sách điểm từ bdgv.json
                SBTeacher[] bangDiemGVs = Program.DocFile<SBTeacher[]>(filepath_BDGV);

                // Đọc danh sách điểm hiện tại từ bdhs.json
                SBStudent[] bangDiemHSs = Program.DocFile<SBStudent[]>(filepath_BangdiemHS);

                foreach (SBTeacher updatedScore in bangDiemGVs)
                {
                    // Tìm điểm hiện có của học sinh trong bdhs.json
                    SBStudent existingScore = null;
                    for (int j = 0; j < bangDiemHSs.Length; j++)
                    {
                        if (bangDiemHSs[j].maHS == updatedScore.maHS &&
                            bangDiemHSs[j].maHK == updatedScore.maHK &&
                            bangDiemHSs[j].MonHoc == updatedScore.maGiaoVien.Replace("GV", ""))
                        {
                            existingScore = bangDiemHSs[j];
                            break;
                        }
                    }
                    if (existingScore != null)
                    {
                        // Cập nhật điểm hiện có
                        existingScore.diemGiuaKy = updatedScore.diemGiuaKy;
                        existingScore.diemCuoiKy = updatedScore.diemCuoiKy;
                        existingScore.diemTongKet = updatedScore.diemTongKet;
                    }
                    else
                    {
                        // Thêm mới điểm cho học sinh nếu chưa có
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
                // Lưu danh sách đã cập nhật vào bdhs.json
                Program.GhiFile(filepath_BangdiemHS, bangDiemHSs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật bảng điểm học sinh từ bdgv.json: {ex.Message}");
            }
        }

        public event EventHandler ComebackButtonClicked;
        private void btncomeback_Click(object sender, EventArgs e)
        {
            ComebackButtonClicked?.Invoke(sender, e);
            this.Close();
        }

        private void NhapDiem_Load(object sender, EventArgs e)
        {

        }
    }
}

