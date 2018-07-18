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
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Session["ProductNameOrder"] == null)
            {
                Response.Redirect("home.aspx");
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

            int id = int.Parse(Session["ProductNameOrder"].ToString());
            conn.Open();
            // Get Product Name
            string comand = "select product_name from Products where id_product='" + id + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            string name = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Price 
            comand = "select price from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Quantity
            comand = "select quantity from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Description
            comand = "select description from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string description = comm.ExecuteScalar().ToString();

            //Get Image
            comand = "select image from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string image = comm.ExecuteScalar().ToString();

            comand = "select id_category from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string categoryId = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CategoryConnectionString"].ConnectionString);
            conn.Open();
            comand = "select gategory_name from Categories where id_category='" + categoryId + "'";
            comm = new SqlCommand(comand, conn);
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
            int idProduct = int.Parse(Session["ProductNameOrder"].ToString());
            int visible = 1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

            conn.Open();
           string comand = "update Products set  visible='" + visible + "' where id_product='" + idProduct + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
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