using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webStore
{
    public partial class homeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Verify for auth session
            if (Session["UserName"] != null || Session["UserId"] != null || Session["UserName"].ToString() != "admin")
            {
                LabelWelcome.Text += " " + Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // session with product Name
            string selectIndex = GridView1.SelectedRow.Cells[4].Text;
            Session["ProductNumber"] = selectIndex;
            Response.Redirect("detailsProduct.aspx");

        }
    }
}