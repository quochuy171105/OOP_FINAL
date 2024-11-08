using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    [Serializable]
    public class Subject : ISerializable
    {
        public string maNamHoc { get; set; } // vd: NH2024
        public int tenNamHoc { get; set; }  //vd: 2024 2023 2022
        public string maHK { get; set; } //vd: 2024HK1
        public string tenHK { get; set; } //vd: HK1 HK2
        public string maMonHoc { get; set; } //vd: 2024HK1TO10
        public string tenMonHoc { get; set; }  //vd: TOAN10
        public string maGV { get; set; } //vd: GVTOAN

        public Subject() { }
        public Subject(SerializationInfo info, StreamingContext context)
        {
            // Đọc dữ liệu từ SerializationInfo và khôi phục các thuộc tính của đối tượng Student
            maNamHoc = info.GetString("maNamHoc");
            tenNamHoc = info.GetInt32("tenNamHoc");
            maHK = info.GetString("maHK");
            tenHK = info.GetString("tenHK");
            maMonHoc = info.GetString("maMonHoc");
            tenMonHoc = info.GetString("tenMonHoc");
            maGV = info.GetString("maGV");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("maNamHoc", maNamHoc);
            info.AddValue("tenNamHoc", tenNamHoc);
            info.AddValue("maHK", maHK);
            info.AddValue("tenHK", tenHK);
            info.AddValue("maMonHoc", maMonHoc);
            info.AddValue("tenMonHoc", tenMonHoc);
            info.AddValue("maGV", maGV);
        }

    }
}
