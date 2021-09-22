using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webStore
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify auth
            if (Session["UserName"] == null  || Session["UserId"] == null || Session["UserName"].ToString() != "admin")
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creata session with selected user
            string selectIndex = GridView1.SelectedRow.Cells[1].Text;
            Session["SelectedUserName"] = selectIndex;
            Response.Redirect("userDetails.aspx");
        }
    }
}