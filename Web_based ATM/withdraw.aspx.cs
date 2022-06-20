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
    public partial class withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 顯示現在時間
            DateTime locatetime = DateTime.Now;
            Response.Write(locatetime);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string userID = (String)Session["UserID"];
            if (Money.Text == "")
            {
                Response.Write("<script>alert(\'錯誤!請輸入金額\')</script>");
            }
            else
            {
                double money = Convert.ToDouble(Money.Text);
                double balance = 0;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Web_basedATM_DBConnectionString"].ConnectionString);
                conn.Open(); // 開啟與資料庫連線

                // 將Customer.db中的balance取出
                SqlCommand select_cmd = new SqlCommand($"Select balance from Customer where cusID = \'{userID}\'", conn);
                SqlDataReader reader = select_cmd.ExecuteReader();
                if (reader.Read())
                {
                    balance = Convert.ToDouble(reader[0]);
                }
                reader.Close();
                // 將Customer.db中的balance更新
                balance -= money;
                if (balance <= 0)
                {
                    Response.Write("<script>alert(\'餘額不足!\')</script>");
                }
                else
                {
                    SqlCommand update_cmd = new SqlCommand($"Update Customer Set balance = @balance where cusID = \'{userID}\'", conn);
                    update_cmd.Parameters.Add("@balance", SqlDbType.Float).Value = balance;
                    if (update_cmd.ExecuteNonQuery() == 1)
                    {
                        Response.Write("<script>alert(\'領款成功!\')</script>");
                    }
                    SqlCommand insert_cmd = new SqlCommand($"Insert into  Bank_account_record values(@transID, @cusID, @rel_cusID, @trans_amount, @trans_date, @current_balance)", conn);
                    insert_cmd.Parameters.Add("@transID", SqlDbType.Int).Value = Math.Abs(DateTime.Now.GetHashCode());
                    insert_cmd.Parameters.Add("@cusID", SqlDbType.VarChar).Value = userID;
                    insert_cmd.Parameters.Add("@rel_cusID", SqlDbType.VarChar).Value = userID;
                    insert_cmd.Parameters.Add("@trans_amount", SqlDbType.VarChar).Value = $"-{money}";
                    insert_cmd.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = DateTime.Now;
                    insert_cmd.Parameters.Add("@current_balance", SqlDbType.Float).Value = balance;
                    insert_cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/function.aspx");
        }
    }
}