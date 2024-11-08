using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thiet_ke
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btnHS_Click_1(object sender, EventArgs e)
        {
            AccountHS accountHS = new AccountHS();
            accountHS.Show();
            this.Hide();
        }

        private void btnGV_Click_1(object sender, EventArgs e)
        {
            AccountGV accountGV = new AccountGV();
            accountGV.Show();
            this.Hide();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
