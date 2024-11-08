using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    public class ListTeacher :  ISerializable
    {
        //trả về DS Giao Vien với các thao tác thêm xóa sửa
        private Teacher[] teachers = new Teacher[13]; //
        public Teacher[] Teachers
        {
            get { return teachers; }
            set { teachers = value; }
        }

        public ListTeacher() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Teachers", teachers);
        }

        public ListTeacher(SerializationInfo info, StreamingContext context)
        {
            Teachers = (Teacher[])info.GetValue("Teachers", typeof(Teacher[]));
        }
        //Khởi tạo danh sách Giao Vien
        public Teacher[] taoDSGiaoVien()
        {
            Teacher[] giaoViens = new Teacher[]
                {
                  new Teacher { maGV = "GVTOAN", hoVaTenLot = "Nguyễn ", ten ="An", gioiTinh =1, soDienThoai ="0204019960", tenDangNhap ="userGVTOAN", matKhau ="passwordGVTOAN"},
                    new Teacher { maGV = "GVLY", hoVaTenLot = "Nguyễn Quang ", ten ="Anh", gioiTinh =1, soDienThoai ="0230515773", tenDangNhap ="userGVLY", matKhau ="passwordGVLY"},
                    new Teacher { maGV = "GVHOA", hoVaTenLot = "Nguyễn Xuân ", ten ="Bách", gioiTinh =1, soDienThoai ="0998182654", tenDangNhap ="userGVHOA", matKhau ="passwordGVHOA"},
                    new Teacher { maGV = "GVVAN", hoVaTenLot = "Nguyễn Tuấn ", ten ="Ngọc", gioiTinh =1, soDienThoai ="0934914939", tenDangNhap ="userGVVAN", matKhau ="passwordGVVAN"},
                    new Teacher { maGV = "GVSU", hoVaTenLot = "Nguyễn Hiếu ", ten ="Nghĩa", gioiTinh =1, soDienThoai ="0674647750", tenDangNhap ="userGVSU", matKhau ="passwordGVSU"},
                    new Teacher { maGV = "GVDIA", hoVaTenLot = "Nguyễn Thành ", ten ="Nhân", gioiTinh =1, soDienThoai ="0693269527", tenDangNhap ="userGVDIA", matKhau ="passwordGVDIA"},
                    new Teacher { maGV = "GVSINH", hoVaTenLot = "Trần Bảo Gia ", ten ="Khiêm", gioiTinh =1, soDienThoai ="0903204781", tenDangNhap ="userGVSINH", matKhau ="passwordGVSINH"},
                    new Teacher { maGV = "GVANH", hoVaTenLot = "Lê Yến ", ten ="Di", gioiTinh =0, soDienThoai ="0585653550", tenDangNhap ="userGVANH", matKhau ="passwordGVANH"},
                    new Teacher { maGV = "GVCD", hoVaTenLot = "Lê Kim ", ten ="Hoa", gioiTinh =0, soDienThoai ="0964956574", tenDangNhap ="userGVCD", matKhau ="passwordGVCD"},
                    new Teacher { maGV = "GVCN", hoVaTenLot = "Lê Nhã ", ten ="Quế", gioiTinh =0, soDienThoai ="0920029060", tenDangNhap ="userGVCN", matKhau ="passwordGVCN"},
                    new Teacher { maGV = "GVQP", hoVaTenLot = "Phạm Tuệ ", ten ="Doanh", gioiTinh =0, soDienThoai ="0203089302", tenDangNhap ="userGVQP", matKhau ="passwordGVQP"},
                    new Teacher { maGV = "GVTC", hoVaTenLot = "Phạm Tuệ Phương ", ten ="Anh", gioiTinh =0, soDienThoai ="0199331045", tenDangNhap ="userGVTC", matKhau ="passwordGVTC"},
                    new Teacher { maGV = "GVTIN", hoVaTenLot = "Trần Lâm ", ten ="Anh", gioiTinh =0, soDienThoai ="0392136597", tenDangNhap ="userGVTIN", matKhau ="passwordGVTIN"},
                };
            return giaoViens;
        }
    }
}
