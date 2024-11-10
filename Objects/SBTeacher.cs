using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Thiet_ke.Objects
{

    [Serializable]
    public class SBTeacher : ScoreBoard, ISerializable
    {
        //thực hiện thao tác chỉnh sửa nhập điểm
        public string maGiaoVien { get; set; }
        public string maLop { get; set; }
        public string maHS { get; set; }
        public string maHK { get; set; }

        // Implement phương thức abstract từ class cha
        public override void luuBangDiem(string filepath, string maHS, string maHK)
        {
            try
            {
                List<SBTeacher> danhSachDiem = File.Exists(filepath)
                    ? JsonConvert.DeserializeObject<List<SBTeacher>>(File.ReadAllText(filepath)) ?? new List<SBTeacher>()
                    : new List<SBTeacher>();

                SBTeacher bangDiem = new SBTeacher
                {
                    maHS = maHS,
                    maHK = maHK,
                    diemGiuaKy = this.diemGiuaKy,
                    diemCuoiKy = this.diemCuoiKy,
                    diemTongKet = this.diemTongKet,
                    maGiaoVien = this.maGiaoVien,
                    maLop = this.maLop
                };

                danhSachDiem.Add(bangDiem);
                File.WriteAllText(filepath, JsonConvert.SerializeObject(danhSachDiem, Formatting.Indented));
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu bảng điểm: {ex.Message}");
            }
        }

        public void CapNhatBangDiem(SBTeacher bangDiemGV, ListView lvDiem, string filePath)
        {
            // Cập nhật dữ liệu
            this.diemGiuaKy = bangDiemGV.diemGiuaKy;
            this.diemCuoiKy = bangDiemGV.diemCuoiKy;
            this.diemTongKet = bangDiemGV.diemTongKet;

            // Đọc và cập nhật file JSON
            string fileContent = File.ReadAllText(filePath);
            List<SBTeacher> bangDiemGVs = JsonConvert.DeserializeObject<List<SBTeacher>>(fileContent);

            SBTeacher hsToUpdate = null;
            foreach (SBTeacher item in bangDiemGVs)
            {
                if (item.maGiaoVien == this.maGiaoVien &&
                item.maLop == this.maLop &&
                item.maHS == this.maHS &&
                item.maHK == this.maHK)
                {
                    hsToUpdate = item;
                    break;
                }
            }

            File.WriteAllText(filePath, JsonConvert.SerializeObject(bangDiemGVs, Formatting.Indented));

            // Cập nhật ListView
            try
            {
                foreach (ListViewItem item in lvDiem.Items)
                {
                    if (item.SubItems[0].Text == bangDiemGV.maHS)
                    {
                        // Cập nhật điểm giữa kỳ ở cột 3
                        if (item.SubItems.Count > 3)
                            item.SubItems[3].Text = bangDiemGV.diemGiuaKy.ToString();

                        // Cập nhật điểm cuối kỳ ở cột 4
                        if (item.SubItems.Count > 4)
                            item.SubItems[4].Text = bangDiemGV.diemCuoiKy.ToString();

                        // Cập nhật điểm trung bình ở cột 5
                        if (item.SubItems.Count > 5)
                            item.SubItems[5].Text = bangDiemGV.diemTongKet.ToString();

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật giao diện: " + ex.Message);
            }
        }
        public SBTeacher() :base()
        {
        }

        public SBTeacher(SerializationInfo info, StreamingContext context)
        {
            maGiaoVien = info.GetString("maGiaoVien");
            maLop = info.GetString("maLop");
            maHS = info.GetString("maHS");
            maHK = info.GetString("maHK");
            diemGiuaKy = info.GetDouble("diemGiuaKy");
            diemCuoiKy = info.GetDouble("diemCuoiKy");
            diemTongKet = info.GetDouble("diemTongKet");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("maGiaoVien", maGiaoVien);
            info.AddValue("maLop", maLop);
            info.AddValue("maHS", maHS);
            info.AddValue("maHK", maHK);
            info.AddValue("diemGiuaKy", diemGiuaKy);
            info.AddValue("diemCuoiKy", diemCuoiKy);
            info.AddValue("diemTongKet", diemTongKet);
        }
    }
}