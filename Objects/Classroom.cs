using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    [Serializable]
    public class Classroom: ISerializable
    {
    
        public string maLop { get; set; } // vd: 2024L10A1; 2024L10A2;...
        public string tenLop { get; set; } // vd: 10A1
        public int tenNamHoc { get; set; }  // vd: 2024 2023 2022
        public string tenHK { get; set; } 

        public Classroom()
        {
        }
        public Classroom(SerializationInfo info, StreamingContext context)
        {
            // Đọc dữ liệu từ SerializationInfo và khôi phục các thuộc tính của đối tượng Student
            maLop = info.GetString("maLop");
            tenLop = info.GetString("tenLop");
            tenHK = info.GetString("tenHK");
            tenNamHoc = info.GetInt32("tenNamHoc");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("maLop", maLop);
            info.AddValue("tenLop", tenLop);
            info.AddValue("tenHK", tenHK);
            info.AddValue("tenNamHoc", tenNamHoc);
        }
    }
}
