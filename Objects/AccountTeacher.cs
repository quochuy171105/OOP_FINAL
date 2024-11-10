using System;
using System.Collections.Generic;

namespace Thiet_ke.Objects
{
    public class AccountTeacher : IAccount
    {
        private List<Teacher> teacherAccounts = new List<Teacher>();
        private static Teacher currentUser;

        public AccountTeacher()
        {
            // khởi tạo ds giáo viên
            teacherAccounts.Add(new Teacher { maGV = "GVTOAN", hoVaTenLot = "Nguyễn ", ten = "An", gioiTinh = 1, soDienThoai = "0204019960", tenDangNhap = "userGVTOAN", matKhau = "passwordGVTOAN" });
            teacherAccounts.Add(new Teacher { maGV = "GVLY", hoVaTenLot = "Nguyễn Quang ", ten = "Anh", gioiTinh = 1, soDienThoai = "0230515773", tenDangNhap = "userGVLY", matKhau = "passwordGVLY" });
            // ...
        }

        public void DangNhap(string tenDangNhap, string matKhau)
        {
            // Kiểm tra đăng nhập
            bool isMatched = false;
            foreach (Teacher account in teacherAccounts)
            {
                if (account.tenDangNhap == tenDangNhap && account.matKhau == matKhau)
                {
                    isMatched = true;
                    currentUser = account;
                    break;
                }
            }

            if (!isMatched)
            {
                Console.WriteLine("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }
        public static Teacher CurrentUser
        {
            get { return currentUser; }
        }
    }
}