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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create session 
            Session["UserName"] = null;
            Session["Price"] = 0.0;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Create db connection for new user registration
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
            conn.Open();

            string selectUsersQuery = "select count(*) from Users where userName='" + TextBoxUserName.Text + "'";
            SqlCommand comm = new SqlCommand(selectUsersQuery, conn);
            int userExistsValue = Convert.ToInt32(comm.ExecuteScalar().ToString());

            conn.Close();

            //Verify user
            if (userExistsValue == 1)
            {
                LabelPass.Visible = false;
                LabelUser.Visible = false;

                conn.Open();
                string checkPasswordQery = "select password from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPasswordQery, conn);
                string password = passComm.ExecuteScalar().ToString().Replace(" ", "");

                string checkUserIdQery = "select id_user from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand idUserComm = new SqlCommand(checkUserIdQery, conn);
                string userID = idUserComm.ExecuteScalar().ToString().Replace(" ", "");

                if (password == TextBoxPassword.Text)
                {
                    //Create Session
                    Session["UserName"] = TextBoxUserName.Text;
                    Session["UserId"] = userID;
                    if (TextBoxUserName.Text == "admin")
                    {
                        //Redirect to admin panel
                        Response.Write("Password is correct");
                        Response.Redirect("homeAdmin.aspx");
                    }
                    else
                    {
                        //Redirect to home page
                        Response.Write("Password is correct");
                        Response.Redirect("home.aspx");
                    }
                }
                else
                {
                    LabelPass.Visible = true;
                }
            }
            else
            {
                LabelUser.Visible = true;
            }

        }


    }
}