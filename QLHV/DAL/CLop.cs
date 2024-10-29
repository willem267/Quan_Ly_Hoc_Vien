using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class CLop
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CLop()
        {
            dc = new DataConnection();
        }

        public DataTable getALLLOP()
        {
            //tao sql query lay toan bo hv
            string query = "SELECT * FROM LOPHOC";
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
        public bool themLop(LOPHOC lp)
        {
            string query = "INSERT INTO LOPHOC ( MaLop, MaGV,TenLop, Phong, MaKH) VALUES (@MaLop, @MaGV, @TenLop, @Phong, @MaKH)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.Char).Value = lp.MaLop;
                cmd.Parameters.Add("@MaGV", SqlDbType.Char).Value = lp.MaGV;
                cmd.Parameters.Add("@TenLop", SqlDbType.VarChar).Value = lp.TenLop;
                cmd.Parameters.Add("@Phong", SqlDbType.VarChar).Value = lp.Phong;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = lp.MaKH;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool suaLop(LOPHOC lp)
        {
            string query = "UPDATE LOPHOC SET  MaGV=@MaGV, TenLop=@TenLop, Phong=@Phong, MaKH=@MaKH WHERE MaLop=@MaLop";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.Char).Value = lp.MaLop;
                cmd.Parameters.Add("@MaGV", SqlDbType.Char).Value = lp.MaGV;
                cmd.Parameters.Add("@TenLop", SqlDbType.VarChar).Value = lp.TenLop;
                cmd.Parameters.Add("@Phong", SqlDbType.VarChar).Value = lp.Phong;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = lp.MaKH;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool xoaLop(LOPHOC lp)
        {
            string query = "DELETE LOPHOC WHERE MaLop=@MaLop";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.VarChar).Value = lp.MaLop;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable findLop(string s)
        {
            string query = "SELECT * FROM LOPHOC WHERE MaLop LIKE '%" + s + "%' OR TenLop LIKE '%" + s + "%'";
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
