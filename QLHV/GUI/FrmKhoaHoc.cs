using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHV
{
    public partial class FrmKhoaHoc : Form
    {
        string Username = "", Password = "", PhanQuyen = "";

        XuLyKhoaHoc xlkh;

        public FrmKhoaHoc()
        {
            InitializeComponent();
            xlkh = new XuLyKhoaHoc();
        }
        public FrmKhoaHoc(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
            xlkh = new XuLyKhoaHoc();
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;
        }

        public void showALL()
        {
            DataTable dt = xlkh.getALLKH();
            dgvKH.DataSource = dt;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmKhoaHoc_Load(object sender, EventArgs e)
        {
            showALL();
        }

        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khóa học.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên khóa học.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (checkData())
                {
                    KHOAHOC kh = new KHOAHOC();
                    kh.MaKH = txtMaKH.Text;
                    kh.TenKH = txtTenKH.Text;
                    kh.NgayBD = dtBD.Value;
                    kh.NgayKT = dtKT.Value;
                    if (xlkh.themKH(kh))
                    {
                        showALL();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KHOAHOC kh = new KHOAHOC();
                    kh.MaKH = txtMaKH.Text;
                    if (xlkh.xoaKH(kh))
                    {
                        showALL();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void dgvKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[index];

                if (row.Cells["MaKH"].Value != null)
                    txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                else
                    txtMaKH.Text = string.Empty;

                if (row.Cells["TenKH"].Value != null)
                    txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                else
                    txtTenKH.Text = string.Empty;

                if (row.Cells["NgayBD"].Value != null && row.Cells["NgayBD"].Value is DateTime)
                    dtBD.Value = (DateTime)row.Cells["NgayBD"].Value;
                else
                    dtBD.Value = DateTime.Now; 

                if (row.Cells["NgayKT"].Value != null && row.Cells["NgayKT"].Value is DateTime)
                    dtKT.Value = (DateTime)row.Cells["NgayKT"].Value;
                else
                    dtKT.Value = DateTime.Now; 
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (checkData())
                {
                    KHOAHOC kh = new KHOAHOC();
                    kh.MaKH = txtMaKH.Text;
                    kh.TenKH = txtTenKH.Text;
                    kh.NgayBD = dtBD.Value;
                    kh.NgayKT = dtKT.Value;
                    if (xlkh.suaKH(kh))
                    {
                        showALL();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            dtBD.Value= DateTime.Now;
            dtKT.Value = DateTime.Now;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string s = txtFind.Text;
            if (!string.IsNullOrEmpty(s))
            {
                DataTable dt = xlkh.findKH(s);
                dgvKH.DataSource = dt;

            }
            else
            {
                showALL();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu menu = new FrmMenu(Username, Password, PhanQuyen);
            menu.Show();
        }
    }
}
