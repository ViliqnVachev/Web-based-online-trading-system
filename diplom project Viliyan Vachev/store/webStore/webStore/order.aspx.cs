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
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verify auth
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Session["ProductNumber"] == null)
            {
                Response.Redirect("home.aspx");
            }

            // Load data from db
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int productID = int.Parse(Session["ProductNumber"].ToString());
            conn.Open();

            // Get Product Name
            string selectQuery = "select product_name from Products where id_product='" + productID + "'";
            SqlCommand comm = new SqlCommand(selectQuery, conn);
            string name = comm.ExecuteScalar().ToString();

            //Get Price 
            selectQuery = "select price from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Quantity
            selectQuery = "select quantity from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get Description
            selectQuery = "select description from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string description = comm.ExecuteScalar().ToString();

            //Get Image
            selectQuery = "select image from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string image = comm.ExecuteScalar().ToString();

            selectQuery = "select id_category from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string categoryId = comm.ExecuteScalar().ToString().Replace(" ", "");

            // Get category
            selectQuery = "select gategory_name from Categories where id_category='" + categoryId + "'";
            comm = new SqlCommand(selectQuery, conn);
            string category = comm.ExecuteScalar().ToString().Replace(" ", "");

            // Get total sum
            selectQuery = "select sum(quantity) from Carts where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string orderedQuantity = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            if (orderedQuantity == "")
            {
                orderedQuantity = "0";
            }

            int realQuantity = int.Parse(quantity) - int.Parse(orderedQuantity);

            // Fill data in text boxes
            TextBoxProdName.Text = name;
            TextBoxPrice.Text = price;
            Label8.Text = realQuantity.ToString();
            TextBoxDescription.Text = description;
            TextBoxCategoryName.Text = category;
            Image1.ImageUrl = image.ToString();
            TextBoxTotal.Text = "";
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int productID = int.Parse(Session["ProductNumber"].ToString());
            conn.Open();
            string selectQuery = "select quantity from Products where id_product='" + productID + "'";
            SqlCommand comm = new SqlCommand(selectQuery, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            selectQuery = "select price from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

            selectQuery = "select sum(quantity) from Carts where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string orderedQuantity = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            if (orderedQuantity == "")
            {
                orderedQuantity = "0";
            }

            // Fill data in text boxes
            Label7.Visible = false;
            int realQuantity = int.Parse(quantity) - int.Parse(orderedQuantity);
            int needQuant = int.Parse(TextBoxQuantity.Text);

            double money = double.Parse(price);

            if (needQuant > realQuantity)
            {
                Label7.Visible = true;
                return;
            }
            else
            {
                double sum = money * needQuant;
                TextBoxTotal.Text = sum.ToString();
                TextBoxTotal.Visible = true;
                Label5.Visible = true;
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int productID = int.Parse(Session["ProductNumber"].ToString());
            conn.Open();

            // Get quantity
            string selectQuery = "select quantity from Products where id_product='" + productID + "'";
            SqlCommand comm = new SqlCommand(selectQuery, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            // Get price
            selectQuery = "select price from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

            // Get total sum
            selectQuery = "select sum(quantity) from Carts where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string orderedQuantity = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();
            if (orderedQuantity == "")
            {
                orderedQuantity = "0";
            }

            Label7.Visible = false;
            int realQuantity = int.Parse(quantity) - int.Parse(orderedQuantity);
            int needQuant = int.Parse(TextBoxQuantity.Text);

            double money = double.Parse(price);

            // Check available quantity
            if (needQuant > realQuantity)
            {
                Label7.Visible = true;
                return;
            }

            productID = int.Parse(Session["ProductNumber"].ToString());

            conn.Open();
            //Get qunatity
            selectQuery = "select quantity from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            //Get price
            selectQuery = "select price from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            price = comm.ExecuteScalar().ToString().Replace(" ", "");


            //Get peoduct name
            selectQuery = "select product_name from Products where id_product='" + productID + "'";
            comm = new SqlCommand(selectQuery, conn);
            string productName = comm.ExecuteScalar().ToString();
            conn.Close();

            int quant = int.Parse(quantity);
            needQuant = int.Parse(TextBoxQuantity.Text);
            money = double.Parse(price);
            double sum = money * needQuant;
            int firstQuantity = int.Parse(quantity);
            int quantityNeed = int.Parse(TextBoxQuantity.Text);

            //Session for Total Price
            double totalForThisProducts = sum;
            double temp = double.Parse(Session["Price"].ToString());
            double sumTotal = totalForThisProducts + temp;
            Session["Price"] = sumTotal;

            // Get ids
            int idProduct = int.Parse(Session["ProductNumber"].ToString());
            int idOrder = int.Parse(Session["Order"].ToString());

            // Qunatity after added
            int tempQuantityforDb = realQuantity - quantityNeed;

            // Change the quantity after order
            conn.Open();
            string insertQuery = "insert into Carts(id_order,id_product,quantity,productName) values(@idOrder,@idProduct,@quantity,@productName)";
            comm = new SqlCommand(insertQuery, conn);
            comm.Parameters.AddWithValue("@idOrder", idOrder);
            comm.Parameters.AddWithValue("@idProduct", idProduct);
            comm.Parameters.AddWithValue("@quantity", quantityNeed);
            comm.Parameters.AddWithValue("@productName", productName);
            comm.ExecuteNonQuery();

            selectQuery = "select status from Orders where id_order='" + idOrder + "'";
            comm = new SqlCommand(selectQuery, conn);
            string status = comm.ExecuteScalar().ToString().Replace(" ", "");
            conn.Close();

            if (tempQuantityforDb <= 0)
            {
                int visible = 1;
                conn.Open();
                string updateQuery= "update Products set  visible='" + visible + "' where id_product='" + idProduct + "'";
                comm = new SqlCommand(updateQuery, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }

            // Redirect to category
            int category = int.Parse(Session["Category"].ToString());

            if (category == 9)
            {
                Response.Redirect("other.aspx");
            }
            else if (category == 10)
            {
                Response.Redirect("telephones.aspx");

            }
            else if (category == 11)
            {
                Response.Redirect("headphones.aspx");
            }
            else if (category == 12)
            {
                Response.Redirect("mobileAccessories.aspx");
            }
            else
            {
                Response.Redirect("home.aspx");
            }

        }

    }
}