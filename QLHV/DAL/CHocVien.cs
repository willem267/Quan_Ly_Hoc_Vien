using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
     class CHocVien
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CHocVien()
        {
            dc = new DataConnection();
        }

        public DataTable getALLHV()
        {
            //tao sql query lay toan bo hv
            string query = "SELECT * FROM HOCVIEN";
            //tao connection
            SqlConnection con = dc.GetConnection();
            //khoi tao doi tuong cua lop adapter
            da= new SqlDataAdapter(query, con);
            //mo ket noi
            con.Open();
            //do du lieu tu adapter vaof table
            DataTable dt= new DataTable();
            da.Fill(dt);
            //dong ket noi
            con.Close();
            return dt;

        }

        public bool ThemHV(HOCVIEN hv)
        {
            string query = "INSERT INTO HOCVIEN (MaHV, MaLop, HoTen, GioiTinh, NgaySinh, DiaChi, SDT) VALUES (@MaHV, @MaLop, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT)";
            SqlConnection con =dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaHV", SqlDbType.VarChar).Value = hv.MaHV;
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = hv.MaLop;
                cmd.Parameters.Add("@HoTen", SqlDbType.VarChar).Value = hv.HoTen;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = hv.GioiTinh;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = hv.NgaySinh;
                cmd.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = hv.DiaChi;
                cmd.Parameters.Add("@SDT", SqlDbType.Decimal).Value = hv.SDT;
                cmd.ExecuteNonQuery();
                con.Close() ;

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
            
        }
        public bool SuaHV(HOCVIEN hv)
        {
            string query = "UPDATE HOCVIEN  SET MaLop=@MaLop, HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, DiaChi=@DiaChi, SDT=@SDT WHERE MaHV=@MaHV";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaHV", SqlDbType.VarChar).Value = hv.MaHV;
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = hv.MaLop;
                cmd.Parameters.Add("@HoTen", SqlDbType.VarChar).Value = hv.HoTen;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = hv.GioiTinh;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = hv.NgaySinh;
                cmd.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = hv.DiaChi;
                cmd.Parameters.Add("@SDT", SqlDbType.Decimal).Value = hv.SDT;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaHV(HOCVIEN hv)
        {
            string query = "DELETE HOCVIEN WHERE MaHV=@MaHV";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaHV", SqlDbType.VarChar).Value = hv.MaHV;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable findHV(string s)
        {
            string query = "SELECT * FROM HOCVIEN WHERE HoTen LIKE '%" + s + "%' OR MaHV LIKE '%"+s+"%'";
            //tao connection
            SqlConnection con = dc.GetConnection();
            //khoi tao doi tuong cua lop adapter
            da = new SqlDataAdapter(query, con);
            //mo ket noi
            con.Open();
            //do du lieu tu adapter vaof table
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dong ket noi
            con.Close();
            return dt;
        }

     }

   
}
    

