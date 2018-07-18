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
            Session["UserName"] = null;
            Session["Price"] = 0.0;

            Dictionary<string, string> map = new Dictionary<string, string>();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
            conn.Open();

            string checkUser = "select count(*) from Users where userName='" + TextBoxUserName.Text + "'";
            SqlCommand comm = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());

            conn.Close();
            
            if (temp == 1)
            {
                LabelPass.Visible = false;
                LabelUser.Visible = false;


                conn.Open();
                string checkPassword = "select password from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPassword, conn);
                string password = passComm.ExecuteScalar().ToString().Replace(" ", "");

                string checkUserId = "select id_user from Users where userName='" + TextBoxUserName.Text + "'";
                SqlCommand idUserComm = new SqlCommand(checkUserId, conn);
                string id = idUserComm.ExecuteScalar().ToString().Replace(" ", "");

                if (password == TextBoxPassword.Text)
                {
                    //Start Session

                    Session["UserName"] = TextBoxUserName.Text;
                    Session["UserId"] = id;


                    Response.Write("Password is correct");

                    Response.Redirect("home.aspx");

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