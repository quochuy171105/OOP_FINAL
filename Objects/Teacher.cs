using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    [Serializable]
    public class Teacher : Person, ISerializable
    {
        public string maGV { get; set; }

        public Teacher()
        {
        }

        public Teacher(SerializationInfo info, StreamingContext context)
        {
            // Đọc dữ liệu từ SerializationInfo và khôi phục các thuộc tính của đối tượng Student
            maGV = info.GetString("maGV");
            hoVaTenLot = info.GetString("hoVaTenLot");
            ten = info.GetString("ten");
            gioiTinh = info.GetInt32("gioiTinh");
            soDienThoai = info.GetString("soDienThoai");
            tenDangNhap = info.GetString("tenDangNhap");
            matKhau = info.GetString("matKhau");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("maGV", maGV);
            info.AddValue("hoVaTenLot", hoVaTenLot);
            info.AddValue("ten", ten);
            info.AddValue("gioiTinh", gioiTinh);
            info.AddValue("soDienThoai", soDienThoai);
            info.AddValue("tenDangNhap", tenDangNhap);
            info.AddValue("matKhau", matKhau);
        }
        public Teacher DangNhap(string tenDangNhap, string matKhau)
        {
            // Kiểm tra thông tin đăng nhập 
            if (tenDangNhap == this.tenDangNhap && matKhau == this.matKhau)
            {
                return this;
            }

            return null;
        }
    }
}
