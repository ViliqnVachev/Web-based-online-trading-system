using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webStore
{
    public partial class other : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verify auth
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }
            Session["Category"] = 9;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectIndex = GridView1.SelectedRow.Cells[4].Text;
            Session["ProductNumber"] = selectIndex;

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