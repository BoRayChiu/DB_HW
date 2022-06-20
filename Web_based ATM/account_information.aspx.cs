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
    public partial class account_information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 顯示現在時間
            DateTime locatetime = DateTime.Now;
            Response.Write(locatetime);

            if ((String)Session["UserID"] != null) {
                string userID = (String)Session["UserID"];
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Web_basedATM_DBConnectionString"].ConnectionString);
                conn.Open(); // 開啟與資料庫連線

                // 將Customer.db中的資料取出
                SqlCommand select_cmd = new SqlCommand($"Select * from Customer where cusID = \'{userID}\'", conn);
                SqlDataReader reader = select_cmd.ExecuteReader();
                if (reader.Read()) {
                    UserID.Text = (String)reader[0];
                    UserName.Text = (String)reader[1];
                    UserPwd.Text = (String)reader[2];
                    UserGender.Text = (String)reader[3];
                    Balance.Text = reader[4].ToString();
                }
                reader.Close();
                // 將Bank_account_record.db中的資料取出
                SqlCommand bank_account_record_select_cmd = new SqlCommand($"Select top 5 rel_cusID as 相關帳號, trans_amount as 金額, trans_date as 日期時間, current_balance as 異動後餘額 from Bank_account_record where cusID = \'{userID}\' order by trans_date DESC ", conn);
                SqlDataReader reader2 = bank_account_record_select_cmd.ExecuteReader();
                GridView.DataSource = reader2;
                GridView.DataBind();
                reader2.Close();
                conn.Close();
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        { 
            Response.Redirect("~/function.aspx");
        }
    }
}