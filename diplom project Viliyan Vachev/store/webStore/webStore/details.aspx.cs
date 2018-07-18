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
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Session["ProductNameOrder"] == null)
            {
                Response.Redirect("home.aspx");
            }

            if (Session["Order"] != null)
            {
                Response.Redirect("order.aspx");
            }


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int id = int.Parse(Session["ProductNameOrder"].ToString());
            conn.Open();
            // Get Product Name
            string comand = "select product_name from Products where id_product='" + id + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            string name = comm.ExecuteScalar().ToString();

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

            //Get Images

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

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CartConnectionString"].ConnectionString);
            conn.Open();
            comand = "select sum(quantity) from Carts where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string orderedQuantity = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            if (orderedQuantity == "")
            {
                orderedQuantity = "0";
            }

            int realQuantity = int.Parse(quantity) - int.Parse(orderedQuantity);

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

            int userId = int.Parse(Session["UserId"].ToString());
            string status = "progress";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString);
            conn.Open();

            string comand = "insert into Orders(id_user,date_time,status) values(@idUser,@date,@status)";
            SqlCommand comm = new SqlCommand(comand, conn);
            comm.Parameters.AddWithValue("@idUser", userId);
            comm.Parameters.AddWithValue("@date", localDate);
            comm.Parameters.AddWithValue("@status", status);

            comm.ExecuteNonQuery();

            comand = "select id_order from Orders where status='" + status + "'";
            comm = new SqlCommand(comand, conn);
            string orderId = comm.ExecuteScalar().ToString();

            Session["Order"] = orderId;

            Response.Redirect("order.aspx");
            conn.Close();



        }
    }
}