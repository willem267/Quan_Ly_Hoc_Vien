using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class CGiaoVien
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CGiaoVien()
        {
            dc = new DataConnection();

        }
        public DataTable getALLGV()
        {
            //tao sql query lay toan bo hv
            string query = "SELECT * FROM GIAOVIEN";
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

        public bool themGV(GIAOVIEN gv)
        {
            string query = "INSERT INTO GIAOVIEN (MaGV, HoTen, NgaySinh, GioiTinh,  DiaChi, SDT) VALUES (@MaGV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaGV", SqlDbType.Char).Value = gv.MaGV;
                cmd.Parameters.Add("@HoTen", SqlDbType.VarChar).Value = gv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = gv.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = gv.GioiTinh;
                cmd.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = gv.DiaChi;
                cmd.Parameters.Add("@SDT", SqlDbType.Decimal).Value = gv.SDT;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool suaGV(GIAOVIEN gv)
        {
            string query = "UPDATE GIAOVIEN SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi, SDT=@SDT WHERE MaGV=@MaGV";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaGV", SqlDbType.Char).Value = gv.MaGV;
                cmd.Parameters.Add("@HoTen", SqlDbType.VarChar).Value = gv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = gv.NgaySinh;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = gv.GioiTinh;
                cmd.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = gv.DiaChi;
                cmd.Parameters.Add("@SDT", SqlDbType.Decimal).Value = gv.SDT;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool xoaGV(GIAOVIEN gv)
        {
            string query = "DELETE GIAOVIEN WHERE MaGV=@MaGV";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaGV", SqlDbType.Char).Value = gv.MaGV;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable findGV(string s)
        {
            string query = "SELECT * FROM GIAOVIEN WHERE HoTen LIKE '%" + s + "%' OR MaGV LIKE '%" + s + "%'";
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
