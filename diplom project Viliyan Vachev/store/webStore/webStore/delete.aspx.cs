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
    public partial class delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify for auth
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }

            // Verify for product session
            if (Session["ProductNumber"] == null)
            {
                Response.Redirect("home.aspx");
            }

            // Load data from db
            int productNumberID = int.Parse(Session["ProductNumber"].ToString());

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            conn.Open();

            // Get Product Name
            string selectCommand = "select product_name from Products where id_product='" + productNumberID + "'";
            SqlCommand comm = new SqlCommand(selectCommand, conn);
            string name = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Price 
            selectCommand = "select price from Products where id_product='" + productNumberID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Quantity
            selectCommand = "select quantity from Products where id_product='" + productNumberID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Description
            selectCommand = "select description from Products where id_product='" + productNumberID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string description = comm.ExecuteScalar().ToString();

            //Get Image
            selectCommand = "select image from Products where id_product='" + productNumberID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string image = comm.ExecuteScalar().ToString();

            //Get category id
            selectCommand = "select id_category from Products where id_product='" + productNumberID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string categoryID = comm.ExecuteScalar().ToString().Replace(" ", "");

            selectCommand = "select gategory_name from Categories where id_category='" + categoryID + "'";
            comm = new SqlCommand(selectCommand, conn);
            string category = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            ProdName.Text = name;
            Price.Text = price;
            Quantity.Text = quantity;
            Description.Text = description;
            TextBoxCategoryName.Text = category;
            Image1.ImageUrl = image.ToString();

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(Session["ProductNumber"].ToString());
            int visible = 1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

            conn.Open();
            string updateQuery = "update Products set  visible='" + visible + "' where id_product='" + productID + "'";
            SqlCommand comm = new SqlCommand(updateQuery, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("myproducts.aspx");

        }



        protected void ButtonCencel_Click(object sender, EventArgs e)
        {
            Response.Redirect("myproducts.aspx");
        }


    }
}