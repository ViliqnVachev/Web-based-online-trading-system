using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace webStore
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verify for auth
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }


            LabelFinalPrice.Text = Session["Price"].ToString();
            double price = double.Parse(Session["Price"].ToString());

            if (price <= 0.0)
            {
                ButtonCencel.Visible = false;
                ButtonConfirm.Visible = false;
                EmptyCartsLable.Visible = true;
            }
            else
            {
                ButtonCencel.Visible = true;
                ButtonConfirm.Visible = true;
                EmptyCartsLable.Visible = false;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int orderID = int.Parse(Session["Order"].ToString());
            string status = "confirm";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString);
            conn.Open();
            string comand = "update Orders set  status='" + status + "' where id_order='" + orderID + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            Session["Price"] = 0.0;
            Session["Order"] = null;

            Response.Redirect("myorder.aspx");

        }

        protected void ButtonCencel_Click(object sender, EventArgs e)
        {
            //Delete carts
            int orderID = int.Parse(Session["Order"].ToString());
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CartConnectionString"].ConnectionString);
            conn.Open();
            string comand = "delete from Carts where id_order='" + orderID + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            //Delete order           
            conn.Open();
            comand = "delete from Orders where id_order='" + orderID + "'";
            comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            // Clear sessions
            Session["Price"] = 0.0;
            Session["Order"] = null;

            Response.Redirect("home.aspx");
        }
    }
}