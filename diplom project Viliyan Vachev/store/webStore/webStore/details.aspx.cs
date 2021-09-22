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
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Verify auth
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }

            // Verify product select
            if (Session["ProductNumber"] == null)
            {
                Response.Redirect("home.aspx");
            }

            if (Session["Order"] != null)
            {
                Response.Redirect("order.aspx");
            }

            // Load data from db
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int productID = int.Parse(Session["ProductNumber"].ToString());
            conn.Open();

            // Get Product Name
            string selectCommand = "select product_name from Products where id_product='" + productID + "'";
            SqlCommand comm = new SqlCommand(selectCommand, conn);
            string name = comm.ExecuteScalar().ToString();

            //Get Price 
            selectCommand = "select price from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Quantity
            selectCommand = "select quantity from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Description
            selectCommand = "select description from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string description = comm.ExecuteScalar().ToString();

            //Get Images
            selectCommand = "select image from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string image = comm.ExecuteScalar().ToString();

            //Get category id
            selectCommand = "select id_category from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string categoryID = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CategoryConnectionString"].ConnectionString);
            conn.Open();
            selectCommand = "select gategory_name from Categories where id_category='" + categoryID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string category = comm.ExecuteScalar().ToString().Replace(" ", "");

            selectCommand = "select sum(quantity) from Carts where id_product='" + productID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string orderedQuantity = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            if (orderedQuantity == "")
            {
                orderedQuantity = "0";
            }

            int realQuantity = int.Parse(quantity) - int.Parse(orderedQuantity);

            // Fill text boxes
            TextBoxProdName.Text = name;
            TextBoxPrice.Text = price;
            TextBoxQuantity.Text = realQuantity.ToString();
            TextBoxDesc.Text = description;
            Image1.ImageUrl = image.ToString();
            TextBoxCategoryName.Text = category;
        }

        protected void ButtonOrder_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;

            // Create order
            int userID = int.Parse(Session["UserId"].ToString());
            string status = "progress";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString);
            conn.Open();

            string query = "insert into Orders(id_user,date_time,status) values(@idUser,@date,@status)";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@idUser", userID);
            comm.Parameters.AddWithValue("@date", localDate);
            comm.Parameters.AddWithValue("@status", status);
            comm.ExecuteNonQuery();

            query = "select id_order from Orders where status='" + status + "'";
            comm = new SqlCommand(query, conn);
            string orderID = comm.ExecuteScalar().ToString();

            //Create session with order id
            Session["Order"] = orderID;

            Response.Redirect("order.aspx");
            conn.Close();

        }
    }
}