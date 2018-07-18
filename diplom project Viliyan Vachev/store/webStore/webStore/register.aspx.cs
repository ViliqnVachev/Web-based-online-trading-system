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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] != null)
            {
                Response.Redirect("home.aspx");
            }
            if (IsPostBack)
            {
               

               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
                conn.Open();

                string checkUser = "select count(*) from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand comm = new SqlCommand(checkUser, conn);
                int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                conn.Close();

               

                if (temp == 1)
                {
                    Label1.Visible = true;

                    return;
                }

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
                conn.Open();

                string insert = "insert into Users(first_name,lastst_name,address,telephone,email,userName,password)" +
                    "values(@firtName,@lastName,@address,@telephone,@email,@userName,@password)";
                comm = new SqlCommand(insert, conn);
                comm.Parameters.AddWithValue("@firtName", TextBoxFirstN.Text);
                comm.Parameters.AddWithValue("@lastName", TextBoxLastN.Text);
                comm.Parameters.AddWithValue("@address", TextBoxAddress.Text);
                comm.Parameters.AddWithValue("@telephone", TextBoxTelephone.Text);
                comm.Parameters.AddWithValue("@email", TextBoxMail.Text);
                comm.Parameters.AddWithValue("@userName", TextBoxUserName.Text);
                comm.Parameters.AddWithValue("@password", TextBoxPassword.Text);

                comm.ExecuteNonQuery();

                Response.Write("Registration is successful");
                Response.Redirect("login.aspx");
                conn.Close();
               // Session["UserName"] = TextBoxUserName.Text;
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
        }
    }
}