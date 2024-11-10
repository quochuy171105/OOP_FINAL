using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public partial class AccountGV : Form
    {
        public AccountGV()
        {
            InitializeComponent();
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            string password = txtMatKhau.Text;
        }
        Teacher matchedAccount = null;

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            AccountTeacher taiKhoanGV = new AccountTeacher();
            taiKhoanGV.DangNhap(username, password);

            if (AccountTeacher.CurrentUser != null)
            {
                //Kiểm tra đăng nhập
                QuanLyDiem quanLyDiem = new QuanLyDiem(AccountTeacher.CurrentUser);
                quanLyDiem.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            this.Close();
        }

        private void AccountGV_Load(object sender, EventArgs e)
        {

        }
    }
}
