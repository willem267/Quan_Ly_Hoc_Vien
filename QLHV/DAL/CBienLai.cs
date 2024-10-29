using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHV
{
    class CBienLai
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CBienLai()
        {
            dc = new DataConnection();
        }

        public DataTable getALLBL()
        {
            //tao sql query lay toan bo hv
            string query = "SELECT * FROM BIENLAI";
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
        public bool themBL(BIENLAI bl)
        {
            string query = "INSERT INTO BIENLAI (MaBL, MaHV, ThanhTien, MienGiam) VALUES (@MaBL, @MaHV, @ThanhTien, @MienGiam)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaBL", SqlDbType.Char).Value = bl.MaBL;
                cmd.Parameters.Add("@MaHV", SqlDbType.Char).Value = bl.MaHV;
                cmd.Parameters.Add("@ThanhTien", SqlDbType.Decimal).Value = bl.ThanhTien;
                cmd.Parameters.Add("@MienGiam", SqlDbType.Decimal).Value = bl.MienGiam;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool suaBL(BIENLAI bl)
        {
            string query = "UPDATE BIENLAI SET MaHV=@MaHV, ThanhTien=@ThanhTien, MienGiam=@MienGiam WHERE MaBL=@MaBL";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaBL", SqlDbType.Char).Value = bl.MaBL;
                cmd.Parameters.Add("@MaHV", SqlDbType.Char).Value = bl.MaHV;
                cmd.Parameters.Add("@ThanhTien", SqlDbType.Decimal).Value = bl.ThanhTien;
                cmd.Parameters.Add("@MienGiam", SqlDbType.Decimal).Value = bl.MienGiam;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
        public bool xoaBL(BIENLAI bl)
        {
            string query = "DELETE BIENLAI WHERE MaBL=@MaBL";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaBL", SqlDbType.Char).Value = bl.MaBL;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }    

        public DataTable findBL(string s)
        {
            string query = "SELECT * FROM BIENLAI WHERE MaBL LIKE '%" + s + "%'";
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
