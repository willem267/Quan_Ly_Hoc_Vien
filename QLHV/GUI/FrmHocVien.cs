using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHV
{
    public partial class FrmHocVien : Form

    {
        string Username = "", Password = "", PhanQuyen = "";
        XuLyHOCVIEN xlhv;

        public FrmHocVien()
        {
            InitializeComponent();
            xlhv = new XuLyHOCVIEN();

        }
        public FrmHocVien(string Username, string Password, string PhanQuyen)
        {
            InitializeComponent();
           
            this.Username = Username;
            this.Password = Password;
            this.PhanQuyen = PhanQuyen;
            xlhv = new XuLyHOCVIEN();

        }
        public void ShowALL()
        {
            DataTable dt = xlhv.getALLHV();
            dgvHocVien.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmHocVien_Load(object sender, EventArgs e)
        {
            ShowALL();
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvSinhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHocVien.Columns[e.ColumnIndex].Name == "GioiTinh")
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
            if (string.IsNullOrEmpty(txtMaHV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã học viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã Lớp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập Họ tên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (checkData() == true)
                {
                    HOCVIEN hv = new HOCVIEN();
                    hv.MaHV = txtMaHV.Text;
                    hv.MaLop = txtMaLop.Text;
                    hv.HoTen = txtHoTen.Text;
                    hv.GioiTinh = (rNam.Checked) ? true : false;
                    hv.NgaySinh = dateTimePicker1.Value;
                    hv.DiaChi = txtDiaChi.Text;
                    hv.SDT = decimal.Parse(txtSDT.Text);
                    if (xlhv.ThemHV(hv))
                    {
                        ShowALL();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi (có thể mã lớp không tồn tại trong database)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else 
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");

            }
        }

        private void dgvHocVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvHocVien.Rows[index];

                if (row.Cells["MaHV"].Value != null)
                    txtMaHV.Text = row.Cells["MaHV"].Value.ToString();
                else
                    txtMaHV.Text = string.Empty;

                if (row.Cells["MaLop"].Value != null)
                    txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                else
                    txtMaLop.Text = string.Empty;

                if (row.Cells["HoTen"].Value != null)
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                else
                    txtHoTen.Text = string.Empty;

                if (row.Cells["GioiTinh"].Value != null && row.Cells["GioiTinh"].Value is bool)
                {
                    if ((bool)row.Cells["GioiTinh"].Value == true)
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

                if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value is DateTime)
                    dateTimePicker1.Value = (DateTime)row.Cells["NgaySinh"].Value;
                else
                    dateTimePicker1.Value = DateTime.Now; 

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
                if (checkData() == true)
                {
                    HOCVIEN hv = new HOCVIEN();
                    hv.MaHV = txtMaHV.Text;
                    hv.MaLop = txtMaLop.Text;
                    hv.HoTen = txtHoTen.Text;
                    hv.GioiTinh = (rNam.Checked) ? true : false;
                    hv.NgaySinh = dateTimePicker1.Value;
                    hv.DiaChi = txtDiaChi.Text;
                    hv.SDT = decimal.Parse(txtSDT.Text);
                    if (xlhv.SuaHV(hv))
                    {
                        ShowALL();
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
                    HOCVIEN hv = new HOCVIEN();
                    hv.MaHV = txtMaHV.Text;
                    if (xlhv.XoaHV(hv))
                    {
                        ShowALL();
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
           txtMaHV.Text="";
           txtMaLop.Text = "";
           txtHoTen.Text="";
            if (rNam.Checked == true)
            {
                rNam.Checked = false;
            }
            else
            {
                rNu.Checked = false;
            }
            
           txtDiaChi.Text="";
            txtSDT.Text = "";
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string s = txtFind.Text;
            if (!string.IsNullOrEmpty(s))
            {
                DataTable dt = xlhv.findHV(s);
                dgvHocVien.DataSource = dt;

            }
            else
            {
                ShowALL();
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
