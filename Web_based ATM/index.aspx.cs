using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Web_based_ATM
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userID = UserID.Text;
            string userpwd = Userpwd.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Web_basedATM_DBConnectionString"].ConnectionString);
            conn.Open(); //開啟與資料庫連線
            string sql = $"Select * from Customer where cusID = \'{userID}\' and cuspwd = \'{userpwd}\'";
            SqlCommand select_cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = select_cmd.ExecuteReader();
            if (reader.Read()) { //輸入帳密正確
                Session["UserID"] = userID;
                reader.Close();
                Server.Transfer("~/function.aspx");
            }
            else { //輸入帳密錯誤
                reader.Close();
                string select_sql2 = $"Select * from Customer where cusID = \'{userID}\'";
                SqlCommand cmd2 = new SqlCommand(select_sql2, conn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read()) { //輸入帳號正確
                    Response.Write("<script>alert(\'密碼錯誤!請重新登入\')</script>");
                }
                else { //輸入帳號不正確
                    Response.Write("<script>alert(\'帳號不存在!請檢查拼字或點選註冊新帳號\')</script>");
                }
                reader2.Close();
            }
            conn.Close(); //關閉與資料庫連線
        }
    }
}