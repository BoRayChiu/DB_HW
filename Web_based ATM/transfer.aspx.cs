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
    public partial class transfer : System.Web.UI.Page
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
            if(To_userID.Text == "") {
                Response.Write("<script>alert(\'錯誤!請輸入目標帳戶帳號\')</script>");
            }
            else if (Money.Text == "") {
                Response.Write("<script>alert(\'錯誤!請輸入金額\')</script>");
            }
            else {
                double money = Convert.ToDouble(Money.Text);
                double balance = 0;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Web_basedATM_DBConnectionString"].ConnectionString);
                conn.Open(); // 開啟與資料庫連線
                // 將Customer.db中的balance取出
                SqlCommand select_cmd = new SqlCommand($"Select balance from Customer where cusID = \'{userID}\'", conn);
                SqlDataReader reader = select_cmd.ExecuteReader();
                if (reader.Read()) {
                    balance = Convert.ToDouble(reader[0]);
                }
                reader.Close();
                // 將Customer.db中的balance更新
                balance -= money;
                if (balance <= 0) {
                    Response.Write("<script>alert(\'餘額不足!\')</script>");
                }
                else {
                    /* Customer.db 更新 for Sender*/
                    SqlCommand update_cmd = new SqlCommand($"Update Customer Set balance = @balance where cusID = \'{userID}\'", conn);
                    update_cmd.Parameters.Add("@balance", SqlDbType.Float).Value = balance;
                    /* Customer.db 更新 for Receiver */
                    // 將Customer.db中的balance取出
                    double to_balance = 0;
                    string to_userID = To_userID.Text;
                    SqlCommand to_select_cmd = new SqlCommand($"Select balance from Customer where cusID = \'{to_userID}\'", conn);
                    SqlDataReader to_reader = to_select_cmd.ExecuteReader();
                    if (to_reader.Read()) {
                        to_balance = Convert.ToDouble(to_reader[0]);
                        to_reader.Close();
                        // 將Customer.db中的balance更新
                        to_balance += money;
                        SqlCommand to_update_cmd = new SqlCommand($"Update Customer Set balance = @balance where cusID = \'{to_userID}\'", conn);
                        to_update_cmd.Parameters.Add("@balance", SqlDbType.Float).Value = to_balance;
                        if (to_update_cmd.ExecuteNonQuery() == 1 & update_cmd.ExecuteNonQuery() == 1)
                        {
                            Response.Write("<script>alert(\'匯款成功!\')</script>");
                        }
                        /* Bank_account_record.db 更新 for Sender */
                        SqlCommand insert_cmd = new SqlCommand($"Insert into  Bank_account_record values(@transID, @cusID, @rel_cusID, @trans_amount, @trans_date, @current_balance)", conn);
                        insert_cmd.Parameters.Add("@transID", SqlDbType.Int).Value = Math.Abs(DateTime.Now.GetHashCode());
                        insert_cmd.Parameters.Add("@cusID", SqlDbType.VarChar).Value = userID;
                        insert_cmd.Parameters.Add("@rel_cusID", SqlDbType.VarChar).Value = to_userID;
                        insert_cmd.Parameters.Add("@trans_amount", SqlDbType.VarChar).Value = $"-{money}";
                        insert_cmd.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = DateTime.Now;
                        insert_cmd.Parameters.Add("@current_balance", SqlDbType.Float).Value = balance;
                        insert_cmd.ExecuteNonQuery();
                        /* Bank_account_record.db 更新 for Receiver */
                        SqlCommand to_insert_cmd = new SqlCommand($"Insert into  Bank_account_record values(@transID, @cusID, @rel_cusID, @trans_amount, @trans_date, @current_balance)", conn);
                        to_insert_cmd.Parameters.Add("@transID", SqlDbType.Int).Value = Math.Abs(DateTime.Now.GetHashCode());
                        to_insert_cmd.Parameters.Add("@cusID", SqlDbType.VarChar).Value = to_userID;
                        to_insert_cmd.Parameters.Add("@rel_cusID", SqlDbType.VarChar).Value = userID;
                        to_insert_cmd.Parameters.Add("@trans_amount", SqlDbType.VarChar).Value = $"+{money}";
                        to_insert_cmd.Parameters.Add("@trans_date", SqlDbType.DateTime).Value = DateTime.Now;
                        to_insert_cmd.Parameters.Add("@current_balance", SqlDbType.Float).Value = to_balance;
                        to_insert_cmd.ExecuteNonQuery();
                    }
                    else {
                        Response.Write("<script>alert(\'目標帳戶錯誤!請檢查拼字\')</script>");
                    }
                    conn.Close();
                }
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/function.aspx");
        }
    }
}