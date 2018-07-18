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
            Label8.Text = realQuantity.ToString();

            TextBoxDescription.Text = description;
            TextBoxCategoryName.Text = category;
            Image1.ImageUrl = image.ToString();
            TextBoxTotal.Text = "";



        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int id = int.Parse(Session["ProductNameOrder"].ToString());
            conn.Open();
            string comand = "select quantity from Products where id_product='" + id + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            comand = "select price from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            int id = int.Parse(Session["ProductNameOrder"].ToString());
            conn.Open();
            string comand = "select quantity from Products where id_product='" + id + "'";
            SqlCommand comm = new SqlCommand(comand, conn);
            string quantity = comm.ExecuteScalar().ToString().Replace(" ", "");
            comand = "select price from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            string price = comm.ExecuteScalar().ToString().Replace(" ", "");

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

            Label7.Visible = false;
            int realQuantity = int.Parse(quantity) - int.Parse(orderedQuantity);
            int needQuant = int.Parse(TextBoxQuantity.Text);

            double money = double.Parse(price);

            if (needQuant > realQuantity)
            {
                Label7.Visible = true;
                return;
            }


            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
            id = int.Parse(Session["ProductNameOrder"].ToString());

            conn.Open();
            //get qunatity
            comand = "select quantity from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            quantity = comm.ExecuteScalar().ToString().Replace(" ", "");

            //get price
            comand = "select price from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
            price = comm.ExecuteScalar().ToString().Replace(" ", "");


            //get peoduct Name

            comand = "select product_name from Products where id_product='" + id + "'";
            comm = new SqlCommand(comand, conn);
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

            // Get id 
            int idProduct = int.Parse(Session["ProductNameOrder"].ToString());
            int idOrder = int.Parse(Session["Order"].ToString());



            // qunatity after added
            int tempQuantityforDb = realQuantity - quantityNeed;


            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CartConnectionString"].ConnectionString);
            conn.Open();

            comand = "insert into Carts(id_order,id_product,quantity,productName) values(@idOrder,@idProduct,@quantity,@productName)";
            comm = new SqlCommand(comand, conn);
            comm.Parameters.AddWithValue("@idOrder", idOrder);
            comm.Parameters.AddWithValue("@idProduct", idProduct);
            comm.Parameters.AddWithValue("@quantity", quantityNeed);
            comm.Parameters.AddWithValue("@productName", productName);

            comm.ExecuteNonQuery();

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString);
            conn.Open();
            comand = "select status from Orders where id_order='" + idOrder + "'";
            comm = new SqlCommand(comand, conn);
            string status = comm.ExecuteScalar().ToString().Replace(" ", "");

            if (tempQuantityforDb <= 0  )
            {
                int visible = 1;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

                conn.Open();
                comand = "update Products set  visible='" + visible + "' where id_product='" + idProduct + "'";
                comm = new SqlCommand(comand, conn);
                comm.ExecuteNonQuery();


                conn.Close();
            }
            //else
            //{
            //    int visible = 0;
            //    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

            //    conn.Open();
            //    comand = "update Products set  visible='" + visible + "' where id_product='" + idProduct + "'";
            //    comm = new SqlCommand(comand, conn);
            //    comm.ExecuteNonQuery();


            //    conn.Close();
            //}

            //update qunatity
            //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);

            //conn.Open();
            //comand = "update Products set  quantity='" + tempQuantityforDb + "' where id_product='" + idProduct + "'";
            //comm = new SqlCommand(comand, conn);
            //comm.ExecuteNonQuery();


            //conn.Close();

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



            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have successfully added a product to your cart')", true);

        }
    }
}