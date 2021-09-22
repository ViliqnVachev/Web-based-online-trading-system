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
            //Verify for auth
            if (Session["UserName"] != null)
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                // Create db connection
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
                conn.Open();

                string selectUsersQuery = "select count(*) from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand comm = new SqlCommand(selectUsersQuery, conn);
                int userExistsValue = Convert.ToInt32(comm.ExecuteScalar().ToString());
                conn.Close();

                //Verify user
                if (userExistsValue == 1)
                {
                    //Show label for non exist user
                    userExistsError.Visible = true;
                    return;
                }

                // Insert new user in db
                conn.Open();

                string insertUserQuery = "insert into Users(first_name,lastst_name,address,telephone,email,userName,password)" +
                    "values(@firtName,@lastName,@address,@telephone,@email,@userName,@password)";
                comm = new SqlCommand(insertUserQuery, conn);
                comm.Parameters.AddWithValue("@firtName", TextBoxFirstN.Text);
                comm.Parameters.AddWithValue("@lastName", TextBoxLastN.Text);
                comm.Parameters.AddWithValue("@address", TextBoxAddress.Text);
                comm.Parameters.AddWithValue("@telephone", TextBoxTelephone.Text);
                comm.Parameters.AddWithValue("@email", TextBoxMail.Text);
                comm.Parameters.AddWithValue("@userName", TextBoxUserName.Text);
                comm.Parameters.AddWithValue("@password", TextBoxPassword.Text);
                comm.ExecuteNonQuery();

                Response.Write("Registration is successful");

                // Create session
                string checkUserIdQery = "select id_user from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand idUserComm = new SqlCommand(checkUserIdQery, conn);
                string userID = idUserComm.ExecuteScalar().ToString().Replace(" ", "");

                Session["UserName"] = TextBoxUserName.Text;
                Session["UserId"] = userID;
                Response.Redirect("home.aspx");

                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
        }
    }
}