using System;
using System.Runtime.Serialization;

namespace Thiet_ke.Objects
{
    [Serializable]
    public class Classroom: ISerializable
    {
    
        public string maLop { get; set; } // vd: 2024L10A1; 2024L10A2;...
        public string tenLop { get; set; } // vd: 10A1
        public int tenNamHoc { get; set; }  // vd: 2024 2023 2022
        public string tenHK { get; set; } // vd: HK1

        public Classroom()
        {
        }
        public Classroom(SerializationInfo info, StreamingContext context)
        {
            //dùng để khôi phục dữ liệu đã tuần tự hóa từ SerializationInfo và StreamingContext.
            maLop = info.GetString("maLop");
            tenLop = info.GetString("tenLop");
            tenHK = info.GetString("tenHK");
            tenNamHoc = info.GetInt32("tenNamHoc");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //cho phép lưu các giá trị của đối tượng Classroom vào SerializationInfo.
            info.AddValue("maLop", maLop);
            info.AddValue("tenLop", tenLop);
            info.AddValue("tenHK", tenHK);
            info.AddValue("tenNamHoc", tenNamHoc);
        }
    }
}
