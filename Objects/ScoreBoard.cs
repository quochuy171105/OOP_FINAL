using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    public abstract class ScoreBoard
    {
        public string MonHoc;    
        public string maHK;
        public double diemGiuaKy;
        public double diemCuoiKy;
        public double diemTongKet;

        protected ScoreBoard() { }

        protected ScoreBoard(string monHoc, string maHK, double diemGiuaKy, double diemCuoiKy)
        {
            MonHoc = monHoc;
            this.maHK = maHK;
            this.diemGiuaKy = diemGiuaKy;
            this.diemCuoiKy = diemCuoiKy;
        }

        public abstract void luuBangDiem(string filepath, string maHS, string maHK);

    }
}
