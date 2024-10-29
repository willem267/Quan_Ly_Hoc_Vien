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

    public partial class FrmGiaoVien : Form
    {
        string Username = "", Password = "", PhanQuyen = "";
        XuLyGiaoVien xlgv;
        public FrmGiaoVien()
        {
            InitializeComponent();
            xlgv = new XuLyGiaoVien();
        }
        public FrmGiaoVien(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
            xlgv = new XuLyGiaoVien();
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;
        }
        public void showALL()
        {
            DataTable dt = xlgv.getALLGV();
            dgvGiaoVien.DataSource = dt;

        }

        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {
            showALL();
        }

        private void dgvGiaoVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGiaoVien.Columns[e.ColumnIndex].Name == "GioiTinh")
            {
                // Kiểm tra giá trị ô
                if (e.Value is bool)
                {
                    // Chuyển đổi giá trị true/false thành Nam/Nữ
                    e.Value = (bool)e.Value ? "Nam" : "Nữ";
                    e.FormattingApplied = true; // Đánh dấu là định dạng đã được áp dụng
                }
            }
        }

        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtMaGV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã học viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã học viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (!rNam.Checked && !rNu.Checked)
            {
                MessageBox.Show("Bạn chưa chọn giới tính.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
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
                    GIAOVIEN gv = new GIAOVIEN();
                    gv.MaGV = txtMaGV.Text;
                    gv.HoTen = txtHoTen.Text;
                    gv.NgaySinh = dtNgaySinh.Value;
                    gv.GioiTinh = (rNam.Checked) ? true : false;
                    gv.DiaChi = txtDiaChi.Text;
                    gv.SDT = decimal.Parse(txtSDT.Text);
                    if (xlgv.themGV(gv))
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

        private void dgvGiaoVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvGiaoVien.Rows[index];

                if (row.Cells["MaGV"].Value != null)
                    txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                else
                    txtMaGV.Text = string.Empty;

                if (row.Cells["HoTen"].Value != null)
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                else
                    txtHoTen.Text = string.Empty;

                if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value is DateTime)
                    dtNgaySinh.Value = (DateTime)row.Cells["NgaySinh"].Value;
                else
                    dtNgaySinh.Value = DateTime.Now; // Or any default value you prefer

                if (row.Cells["GioiTinh"].Value != null && row.Cells["GioiTinh"].Value is bool)
                {
                    if ((bool)row.Cells["GioiTinh"].Value)
                    {
                        rNam.Checked = true;
                    }
                    else
                    {
                        rNu.Checked = true;
                    }
                }
                else
                {
                    rNam.Checked = false;
                    rNu.Checked = false;
                }

                if (row.Cells["DiaChi"].Value != null)
                    txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                else
                    txtDiaChi.Text = string.Empty;

                if (row.Cells["SDT"].Value != null)
                    txtSDT.Text = row.Cells["SDT"].Value.ToString();
                else
                    txtSDT.Text = string.Empty;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PhanQuyen == "Admin")
            {
                if (checkData())
                {
                    GIAOVIEN gv = new GIAOVIEN();
                    gv.MaGV = txtMaGV.Text;
                    gv.HoTen = txtHoTen.Text;
                    gv.NgaySinh = dtNgaySinh.Value;
                    gv.GioiTinh = (rNam.Checked) ? true : false;
                    gv.DiaChi = txtDiaChi.Text;
                    gv.SDT = decimal.Parse(txtSDT.Text);
                    if (xlgv.suaGV(gv))
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
                    GIAOVIEN gv = new GIAOVIEN();
                    gv.MaGV = txtMaGV.Text;
                    if (xlgv.xoaGV(gv))
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
            txtMaGV.Text = "";
            txtHoTen.Text = "";
            if (rNam.Checked == true)
            {
                rNam.Checked = false;
            }
            else
            {
                rNu.Checked = false;
            }
            dtNgaySinh.Value=DateTime.Now;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string s = txtFind.Text;
            if (!string.IsNullOrEmpty(s))
            {
                DataTable dt = xlgv.findGV(s);
                dgvGiaoVien.DataSource = dt;

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
