using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class CKhoaHoc
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CKhoaHoc()
        {
            dc = new DataConnection();
        }

        public DataTable getALLKH()
        {
            //tao sql query lay toan bo hv
            string query = "SELECT * FROM KHOAHOC";
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

        public bool themKH(KHOAHOC kh)
        {
            string query = "INSERT INTO KHOAHOC (MaKH, TenKH, NgayBD, NgayKT) VALUES (@MaKH, @TenKH, @NgayBD, @NgayKT)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = kh.MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.VarChar).Value = kh.TenKH;

                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = kh.NgayBD;
                cmd.Parameters.Add("@NgayKT", SqlDbType.Date).Value = kh.NgayKT;

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool suaKH(KHOAHOC kh)
        {
            string query = "UPDATE KHOAHOC SET TenKH=@TenKH, NgayBD=@NgayBD, NgayKT=@NgayKT WHERE MaKH=@MaKH";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = kh.MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.VarChar).Value = kh.TenKH;

                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = kh.NgayBD;
                cmd.Parameters.Add("@NgayKT", SqlDbType.Date).Value = kh.NgayKT;

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool xoaKH(KHOAHOC kh)
        {
            string query = "DELETE KHOAHOC WHERE MaKH=@MaKH";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = kh.MaKH;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
        public DataTable findKH(string s)
        {
            string query = "SELECT * FROM KHOAHOC WHERE MaKH LIKE '%" + s + "%' OR TenKH LIKE '%" + s + "%'";
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
