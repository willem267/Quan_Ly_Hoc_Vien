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
    public partial class FrmLop : Form
    {
        string Username = "", Password = "", PhanQuyen = "";
        XuLyLOP xll;
        
        public FrmLop()
        {
            InitializeComponent();
            xll = new XuLyLOP();
        }
        public FrmLop(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
            xll = new XuLyLOP();
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;
        }
        public void ShowALL()
        {
            DataTable dt = xll.getALLLOP();
            dgvLop.DataSource = dt;
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            ShowALL();
        }
        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã lớp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaGV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã giáo viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên lớp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhong.Text))
            {
                MessageBox.Show("Bạn chưa nhập phòng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khóa học.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LOPHOC lp = new LOPHOC();
                    lp.MaLop = txtMaLop.Text;
                    lp.MaGV = txtMaGV.Text;
                    lp.TenLop = txtTenLop.Text;
                    lp.Phong = txtPhong.Text;
                    lp.MaKH = txtMaKH.Text;
                    if (xll.themLop(lp))
                    {
                        ShowALL();

                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi! )", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void dgvLop_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvLop.Rows[index];

                if (row.Cells["MaLop"].Value != null)
                    txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                else
                    txtMaLop.Text = string.Empty;

                if (row.Cells["MaGV"].Value != null)
                    txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                else
                    txtMaGV.Text = string.Empty;

                if (row.Cells["TenLop"].Value != null)
                    txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
                else
                    txtTenLop.Text = string.Empty;

                if (row.Cells["Phong"].Value != null)
                    txtPhong.Text = row.Cells["Phong"].Value.ToString();
                else
                    txtPhong.Text = string.Empty;

                if (row.Cells["MaKH"].Value != null)
                    txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                else
                    txtMaKH.Text = string.Empty;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {

                if (checkData())
                {
                    LOPHOC lp = new LOPHOC();
                    lp.MaLop = txtMaLop.Text;
                    lp.MaGV = txtMaGV.Text;
                    lp.TenLop = txtTenLop.Text;
                    lp.Phong = txtPhong.Text;
                    lp.MaKH = txtMaKH.Text;
                    if (xll.suaLop(lp))
                    {
                        ShowALL();

                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    LOPHOC lp = new LOPHOC();
                    lp.MaLop = txtMaLop.Text;
                    if (xll.xoaLop(lp))
                    {
                        ShowALL();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string s = txtFind.Text;
            if (!string.IsNullOrEmpty(s))
            {
                DataTable dt = xll.findLop(s);
                dgvLop.DataSource = dt;

            }
            else
            {
                ShowALL();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = "";
            txtMaGV.Text = "";
            txtTenLop.Text = "";
            txtPhong.Text = "";
            txtMaKH.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu menu = new FrmMenu(Username, Password, PhanQuyen);
            menu.Show();
        }
    }
}
