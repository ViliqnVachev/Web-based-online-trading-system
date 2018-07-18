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
                Label2.Visible = true;
            }
            else
            {
                ButtonCencel.Visible = true;
                ButtonConfirm.Visible = true;
                Label2.Visible = false;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int idOrder = int.Parse(Session["Order"].ToString());
            string status = "confirm";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString);
            conn.Open();
            string comand = "update Orders set  status='" + status + "' where id_order='" + idOrder + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            Session["Price"] = 0.0;
            Session["Order"] = null;

            Response.Redirect("myorder.aspx");

        }

        protected void ButtonCencel_Click(object sender, EventArgs e)
        {
            //delete carts
            int idOrder = int.Parse(Session["Order"].ToString());
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CartConnectionString"].ConnectionString);
            conn.Open();
            string comand = "delete from Carts where id_order='" + idOrder + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            //delete order
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CartConnectionString"].ConnectionString);
            conn.Open();
             comand = "delete from Orders where id_order='" + idOrder + "'";
             comm = new SqlCommand(comand, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            Session["Price"] = 0.0;
            Session["Order"] = null;

            //int visible = 0;
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

            //conn.Open();
            //comand = "update Products set  visible='" + visible + "' where id_order='" + idOrder + "'";
            //comm = new SqlCommand(comand, conn);
            //comm.ExecuteNonQuery();


            //conn.Close();

            Response.Redirect("home.aspx");
        }
    }
}