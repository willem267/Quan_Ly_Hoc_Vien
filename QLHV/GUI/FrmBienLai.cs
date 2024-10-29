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
    public partial class FrmBienLai : Form
    {
        XuLyBienLai xlbl;
        string Username = "", Password = "", PhanQuyen = "";
        public FrmBienLai()
        {
            InitializeComponent();
            xlbl = new XuLyBienLai();
        }
        public FrmBienLai(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
            xlbl = new XuLyBienLai();
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;
        }

        public void showALL()
        {
            DataTable dt = xlbl.getALLBL();
            dgvBL.DataSource = dt;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmBienLai_Load(object sender, EventArgs e)
        {
            showALL();
        }

        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtMaBL.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã biên lai.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaBL.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaHV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã học viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtThanhTien.Text))
            {
                MessageBox.Show("Bạn chưa nhập thành tiền.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThanhTien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMienGiam.Text))
            {
                MessageBox.Show("Bạn chưa nhập miễn giảm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMienGiam.Focus();
                return false;
            }
            return true;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (checkData() == true)
                {
                    BIENLAI bl = new BIENLAI();
                    bl.MaBL = txtMaBL.Text;
                    bl.MaHV = txtMaHV.Text;
                    bl.ThanhTien = decimal.Parse(txtThanhTien.Text);
                    bl.MienGiam = decimal.Parse(txtMienGiam.Text);

                    if (xlbl.themBL(bl))
                    {
                        showALL();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi (có thể mã học viên không tồn tại trong database hoặc bạn đã nhập sai kiểu dữ liệu)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void dgvBL_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvBL.Rows[index];

                if (row.Cells["MaHV"].Value != null)
                    txtMaHV.Text = row.Cells["MaHV"].Value.ToString();
                else
                    txtMaHV.Text = string.Empty;

                if (row.Cells["MaBL"].Value != null)
                    txtMaBL.Text = row.Cells["MaBL"].Value.ToString();
                else
                    txtMaBL.Text = string.Empty;

                if (row.Cells["ThanhTien"].Value != null)
                    txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
                else
                    txtThanhTien.Text = string.Empty;

                if (row.Cells["MienGiam"].Value != null)
                    txtMienGiam.Text = row.Cells["MienGiam"].Value.ToString();
                else
                    txtMienGiam.Text = string.Empty;
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (checkData() == true)
                {
                    BIENLAI bl = new BIENLAI();
                    bl.MaBL = txtMaBL.Text;
                    bl.MaHV = txtMaHV.Text;
                    bl.ThanhTien = decimal.Parse(txtThanhTien.Text);
                    bl.MienGiam = decimal.Parse(txtMienGiam.Text);

                    if (xlbl.suaBL(bl))
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BIENLAI bl = new BIENLAI();
                    bl.MaBL = txtMaBL.Text;
                    if (xlbl.xoaBL(bl))
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

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string s = txtFind.Text;
            if (!string.IsNullOrEmpty(s))
            {
                DataTable dt = xlbl.findBL(s);
                dgvBL.DataSource = dt;

            }
            else
            {
                showALL();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaBL.Text = "";
            txtMaHV.Text = "";
            txtMienGiam.Text = "";
            txtThanhTien.Text = "";
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu menu = new FrmMenu(Username, Password, PhanQuyen);
            menu.Show();
        }
    }
}
