using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Web_based_ATM
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Check_Click(object sender, EventArgs e)
        {
            string userID = ID.Text;
            string userName = name.Text;
            string userPwd = pwd.Text;
            string checkPwd = check_pwd.Text;
            string userGender = gender.Text;
            if (!(userID == "" | userName == "" | userPwd == "" | checkPwd == "" | userGender == "")) {
                if (userPwd != checkPwd)
                { // 如果確認密碼與密碼不符
                    Response.Write("<script>alert(\'確認密碼與設定密碼不符!請再試一次\')</script>");
                }
                else {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Web_basedATM_DBConnectionString"].ConnectionString);
                    conn.Open(); //開啟與資料庫連線

                    //檢查帳號是否已存在
                    SqlCommand select_cmd = new SqlCommand($"Select * from Customer where cusID = \'{userID}\'", conn);
                    SqlDataReader reader = select_cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Response.Write("<script>alert(\'帳號已存在!請重新改變輸入帳號\')</script>");
                    }
                    reader.Close();
                    //將註冊資料傳入Customer.db
                    SqlCommand insert_cmd = new SqlCommand($"Insert Into Customer values(@cusID, @cusname, @cuspwd, @gender, @balance)", conn);
                    insert_cmd.Parameters.Add("@cusID", SqlDbType.VarChar).Value = userID;
                    insert_cmd.Parameters.Add("@cusname", SqlDbType.VarChar).Value = userName;
                    insert_cmd.Parameters.Add("@cuspwd", SqlDbType.VarChar).Value = userPwd;
                    insert_cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = userGender;
                    insert_cmd.Parameters.Add("@balance", SqlDbType.Float).Value = 1000.0;
                    insert_cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert(\'註冊成功!請重新登入\')</script>");
                    Server.Transfer("~/index.aspx");
                }
            }
            else {
                Response.Write("<script>alert(\'資料不完整!請檢查\')</script>");
            }
        }
    }
}