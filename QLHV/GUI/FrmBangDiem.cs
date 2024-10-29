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

    public partial class FrmBangDiem : Form
    {
        
        XuLyBangDiem xlbd;
        string Username = "", Password = "", PhanQuyen = "";
        public FrmBangDiem()
        {
            InitializeComponent();
            xlbd = new XuLyBangDiem();

        }
        public FrmBangDiem(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
            xlbd = new XuLyBangDiem();
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;
            
        }
        public void showALL()
        {
            DataTable dt = xlbd.getAllBD();
            dgvBD.DataSource = dt;
        }

        private void FrmBangDiem_Load(object sender, EventArgs e)
        {
            showALL();
        }

        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtMaHV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã học viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã lớp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtKetQua.Text))
            {
                MessageBox.Show("Bạn chưa nhập kết quả.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKetQua.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtXepLoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập xếp loại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXepLoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Bạn chưa nhập ghi chú.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Focus();
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
                    BANGDIEM bd = new BANGDIEM();
                    bd.MaHV = txtMaHV.Text;
                    bd.MaLop = txtMaLop.Text;
                    bd.Diem = float.Parse(txtDiem.Text);
                    bd.KetQua = txtKetQua.Text;
                    bd.XepLoai = txtXepLoai.Text;
                    bd.GhiChu = txtGhiChu.Text;
                    if (xlbd.themBD(bd))
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

        private void dgvBD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvBD.Rows[index];

                if (row.Cells["MaHV"].Value != null)
                    txtMaHV.Text = row.Cells["MaHV"].Value.ToString();
                else
                    txtMaHV.Text = string.Empty;

                if (row.Cells["MaLop"].Value != null)
                    txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                else
                    txtMaLop.Text = string.Empty;

                if (row.Cells["Diem"].Value != null)
                    txtDiem.Text = row.Cells["Diem"].Value.ToString();
                else
                    txtDiem.Text = string.Empty;

                if (row.Cells["KetQua"].Value != null)
                    txtKetQua.Text = row.Cells["KetQua"].Value.ToString();
                else
                    txtKetQua.Text = string.Empty;

                if (row.Cells["XepLoai"].Value != null)
                    txtXepLoai.Text = row.Cells["XepLoai"].Value.ToString();
                else
                    txtXepLoai.Text = string.Empty;

                if (row.Cells["GhiChu"].Value != null)
                    txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
                else
                    txtGhiChu.Text = string.Empty;
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (checkData() == true)
                {
                    BANGDIEM bd = new BANGDIEM();
                    bd.MaHV = txtMaHV.Text;
                    bd.MaLop = txtMaLop.Text;
                    bd.Diem = float.Parse(txtDiem.Text);
                    bd.KetQua = txtKetQua.Text;
                    bd.XepLoai = txtXepLoai.Text;
                    bd.GhiChu = txtGhiChu.Text;
                    if (xlbd.suaBD(bd))
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
                    BANGDIEM bd = new BANGDIEM();
                    bd.MaHV = txtMaHV.Text;
                    bd.MaLop = txtMaLop.Text;
                    if (xlbd.xoaBD(bd))
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaHV.Text = "";
            txtMaLop.Text = "";
            txtDiem.Text = "";
            txtKetQua.Text = "";
            txtXepLoai.Text = "";
            txtGhiChu.Text = "";

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string s = txtFind.Text;
            if (!string.IsNullOrEmpty(s))
            {
                DataTable dt = xlbd.findBD(s);
                dgvBD.DataSource = dt;

            }
            else
            {
                showALL();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMenu menu= new FrmMenu(Username, Password, PhanQuyen);
            menu.Show();

        }
    }
}
