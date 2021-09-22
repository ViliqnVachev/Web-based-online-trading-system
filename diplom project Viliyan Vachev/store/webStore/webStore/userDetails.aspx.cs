using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webStore
{
    public partial class userDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify auth
            if (Session["UserName"] == null || Session["UserId"] == null || Session["UserName"].ToString() != "admin")
            {
                Response.Redirect("login.aspx");
            }
            // Verify product select
            if (Session["SelectedUserName"] == null)
            {
                Response.Redirect("homeAdmin.aspx");
            }

            // Load data from db
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
            string selectedUserName = Session["SelectedUserName"].ToString();
            conn.Open();

            // Get Product Name
            string selectQuery = "select password from Users where userName='" + selectedUserName + "'";
            SqlCommand comm = new SqlCommand(selectQuery, conn);
            string userPassword = comm.ExecuteScalar().ToString();

            // Get First Name
            selectQuery = "select first_name from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectQuery, conn);
            string firstName = comm.ExecuteScalar().ToString();

            // Get Last Name
            selectQuery = "select lastst_name from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectQuery, conn);
            string lastName = comm.ExecuteScalar().ToString();

            // Get Address
            selectQuery = "select address from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectQuery, conn);
            string address = comm.ExecuteScalar().ToString();

            // Get Telephone
            selectQuery = "select telephone from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectQuery, conn);
            string telephone = comm.ExecuteScalar().ToString();

            // Get Email
            selectQuery = "select email from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectQuery, conn);
            string email = comm.ExecuteScalar().ToString();

            // Fill text boxes
            UserNameTextBox.Text = selectedUserName;
            PasswordTextBox.Text = userPassword;
            FirstNameTextBox.Text = firstName;
            LastNameTextBox.Text = lastName;
            AddressTextBox.Text = address;
            TelephoneTextBox.Text = telephone;
            EmailTextBox.Text = email;
        }

        protected void ButtonCencel_Click(object sender, EventArgs e)
        {
            //Clear session
            Session["SelectedUserName"] = null;
            Response.Redirect("homeAdmin.aspx");

        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            // Redirect to edit page
            Response.Redirect("editUser.aspx");
        }
    }

}