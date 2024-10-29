using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace QLHV
{
    class CBangDiem
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CBangDiem()
        {
            dc = new DataConnection();
        }

        public DataTable getALLBD()
        {
            // tao sql query lay toan bo hv
            string query = "SELECT * FROM BANGDIEM";
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

        public bool themBD(BANGDIEM bd)
        {
            string query = "INSERT INTO BANGDIEM (MaHV, MaLop, Diem, KetQua, XepLoai, GhiChu) VALUES (@MaHV, @MaLop, @Diem, @KetQua, @XepLoai, @GhiChu)";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaHV", SqlDbType.Char).Value = bd.MaHV;
                cmd.Parameters.Add("@MaLop", SqlDbType.Char).Value = bd.MaLop;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = bd.Diem;
                cmd.Parameters.Add("@KetQua", SqlDbType.VarChar).Value = bd.KetQua;
                cmd.Parameters.Add("@XepLoai", SqlDbType.VarChar).Value = bd.XepLoai;
                cmd.Parameters.Add("@GhiChu", SqlDbType.VarChar).Value = bd.GhiChu;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool suaBD(BANGDIEM bd)
        {
            string query = "UPDATE BANGDIEM SET Diem=@Diem, KetQua=@KetQua, XepLoai=@XepLoai, GhiChu=@GhiChu WHERE MaHV=@MaHV AND MaLop=@MaLop";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaHV", SqlDbType.Char).Value = bd.MaHV;
                cmd.Parameters.Add("@MaLop", SqlDbType.Char).Value = bd.MaLop;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = bd.Diem;
                cmd.Parameters.Add("@KetQua", SqlDbType.VarChar).Value = bd.KetQua;
                cmd.Parameters.Add("@XepLoai", SqlDbType.VarChar).Value = bd.XepLoai;
                cmd.Parameters.Add("@GhiChu", SqlDbType.VarChar).Value = bd.GhiChu;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool xoaBD(BANGDIEM bd)
        {
            string query = "DELETE BANGDIEM WHERE MaHV=@MaHV AND MaLop=@MaLop";
            SqlConnection con = dc.GetConnection();
            try
            {
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@MaHV", SqlDbType.Char).Value = bd.MaHV;
                cmd.Parameters.Add("@MaLop", SqlDbType.Char).Value = bd.MaLop;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable findBD(string s)
        {
            string query = "SELECT * FROM BANGDIEM WHERE MaHV LIKE '%" + s + "%' OR MaLop LIKE '%" + s + "%'";
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
