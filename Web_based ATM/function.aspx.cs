using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_based_ATM
{
    public partial class function : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string userID = (String)Session["UserID"];
            Response.Write("歡迎回來! \n"+userID);
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["UserID"] = "";
            Response.Redirect("~/index.aspx");
        }
    }
}