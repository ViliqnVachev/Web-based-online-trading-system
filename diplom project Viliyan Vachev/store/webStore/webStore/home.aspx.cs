using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webStore
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] != null || Session["UserId"] != null)
            {
                LabelWelcome.Text += " " + Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            Session["Category"] = 0;
        }

       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // session with product Name
            // NB if I have 2 or more identical names


            string selectIndex = GridView1.SelectedRow.Cells[4].Text;
            Session["ProductNameOrder"] = selectIndex;

            if (Session["Order"] != null)
            {
                Response.Redirect("order.aspx");
            }
            else
            {
                Response.Redirect("details.aspx");
            }

        }
    }
}