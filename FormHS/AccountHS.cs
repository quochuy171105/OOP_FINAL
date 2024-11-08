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
    public partial class AccountHS : Form
    {
        public AccountHS()
        {
            InitializeComponent();
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
        }

        private void AccountHS_Load(object sender, EventArgs e)
        {
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            Objects.AccountStudent taiKhoanHS = new Objects.AccountStudent();
            taiKhoanHS.DangNhap(username, password);

            if (Objects.AccountStudent.CurrentUser != null)
            {
                // Kiểm tra đăng nhập
                XemDiem_HS xemDiem_HS = new XemDiem_HS(Objects.AccountStudent.CurrentUser);
                xemDiem_HS.ShowDialog();
                this.Close();
            }
            else
            {
                // Không đúng thì hiện thông báo
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            this.Close();
        }
    }
    }

