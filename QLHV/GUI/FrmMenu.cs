using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHV
{
    public partial class FrmMenu : Form
    {
        string Username = "", Password = "", PhanQuyen = "";
        public FrmMenu()
        {
            InitializeComponent();
        }
        public FrmMenu(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;

        }

        private void btnHocVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHocVien hocVien = new FrmHocVien(Username, Password, PhanQuyen);
            hocVien.Show(); 
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLop lop = new FrmLop(Username, Password, PhanQuyen);
            lop.Show();

        }

        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmKhoaHoc khoahoc= new FrmKhoaHoc(Username, Password, PhanQuyen);
            khoahoc.Show();
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmGiaoVien giaovien= new FrmGiaoVien(Username, Password, PhanQuyen);
            giaovien.Show();
        }

        private void btnBienLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBienLai bienlai= new FrmBienLai(Username, Password, PhanQuyen);
            bienlai.Show();
        }

        private void btnBangDiem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBangDiem bangdiem= new FrmBangDiem(Username, Password, PhanQuyen);
            bangdiem.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Cảnh báo đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                FrmLogin login = new FrmLogin();
                login.Show();
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
        
    }
}
