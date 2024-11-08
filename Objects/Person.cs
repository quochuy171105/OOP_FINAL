using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    public abstract class Person 
    {
        public string hoVaTenLot { get; set; }
        public string ten { get; set; }
        public int gioiTinh { get; set; } //nam 1, nu 0
        public string soDienThoai { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }

    }
}
