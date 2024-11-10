using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    [Serializable]
    public class ListSubject : ISerializable
    {
        //trả về DS học sinh với các thao tác thêm xóa sửa
        private Subject[] monHocs = new Subject[13]; 
        public Subject[] MonHocs
        {
            get { return monHocs; }
            set { monHocs = value; }
        }

        public ListSubject() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MonHocs", monHocs);
        }
        public ListSubject(SerializationInfo info, StreamingContext context)
        {
            MonHocs = (Subject[])info.GetValue("Students", typeof(Subject[]));
        }
        //Khởi tạo danh sách Mon Hoc
        public Subject[] taoDSMonHoc()
        {
            Subject[] monHocs = new Subject[]
                {
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TOAN10", tenMonHoc ="TOAN10", maGV ="GVTOAN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TOAN11", tenMonHoc ="TOAN11", maGV ="GVTOAN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TOAN12", tenMonHoc ="TOAN12", maGV ="GVTOAN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1LY10", tenMonHoc ="LY10", maGV ="GVLY"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1LY11", tenMonHoc ="LY11", maGV ="GVLY"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1LY12", tenMonHoc ="LY12", maGV ="GVLY"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1HOA10", tenMonHoc ="HOA10", maGV ="GVHOA"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1HOA11", tenMonHoc ="HOA11", maGV ="GVHOA"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1HOA12", tenMonHoc ="HOA12", maGV ="GVHOA"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1VAN10", tenMonHoc ="VAN10", maGV ="GVVAN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1VAN11", tenMonHoc ="VAN11", maGV ="GVVAN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1VAN12", tenMonHoc ="VAN12", maGV ="GVVAN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1SU10", tenMonHoc ="SU10", maGV ="GVSU"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1SU11", tenMonHoc ="SU11", maGV ="GVSU"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1SU12", tenMonHoc ="SU12", maGV ="GVSU"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1DIA10", tenMonHoc ="DIA10", maGV ="GVDIA"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1DIA11", tenMonHoc ="DIA11", maGV ="GVDIA"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1DIA12", tenMonHoc ="DIA12", maGV ="GVDIA"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1SINH10", tenMonHoc ="SINH10", maGV ="GVSINH"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1SINH11", tenMonHoc ="SINH11", maGV ="GVSINH"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1SINH12", tenMonHoc ="SINH12", maGV ="GVSINH"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1ANH10", tenMonHoc ="ANH10", maGV ="GVANH"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1ANH11", tenMonHoc ="ANH11", maGV ="GVANH"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1ANH12", tenMonHoc ="ANH12", maGV ="GVANH"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1CD10", tenMonHoc ="CD10", maGV ="GVCD"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1CD11", tenMonHoc ="CD11", maGV ="GVCD"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1CD12", tenMonHoc ="CD12", maGV ="GVCD"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1CN10", tenMonHoc ="CN10", maGV ="GVCN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1CN11", tenMonHoc ="CN11", maGV ="GVCN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1CN12", tenMonHoc ="CN12", maGV ="GVCN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1QP10", tenMonHoc ="QP10", maGV ="GVQP"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1QP11", tenMonHoc ="QP11", maGV ="GVQP"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1QP12", tenMonHoc ="QP12", maGV ="GVQP"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TC10", tenMonHoc ="TC10", maGV ="GVTC"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TC11", tenMonHoc ="TC11", maGV ="GVTC"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TC12", tenMonHoc ="TC12", maGV ="GVTC"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TIN10", tenMonHoc ="TIN10", maGV ="GVTIN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TIN11", tenMonHoc ="TIN11", maGV ="GVTIN"},
                new Subject { maNamHoc = "NH2024", tenNamHoc = 2024, maHK ="2024HK1", tenHK ="HK1", maMonHoc ="2024HK1TIN12", tenMonHoc ="TIN12", maGV ="GVTIN"},
                };
            return monHocs;
        }
    }
}
