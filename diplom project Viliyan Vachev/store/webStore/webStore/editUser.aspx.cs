using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webStore
{
    public partial class editUser : System.Web.UI.Page
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
            string selectCommand = "select password from Users where userName='" + selectedUserName + "'";
            SqlCommand comm = new SqlCommand(selectCommand, conn);
            string userPassword = comm.ExecuteScalar().ToString();

            // Get First Name
            selectCommand = "select first_name from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectCommand, conn);
            string firstName = comm.ExecuteScalar().ToString();

            // Get Last Name
            selectCommand = "select lastst_name from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectCommand, conn);
            string lastName = comm.ExecuteScalar().ToString();

            // Get Address
            selectCommand = "select address from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectCommand, conn);
            string address = comm.ExecuteScalar().ToString();

            // Get Telephone
            selectCommand = "select telephone from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectCommand, conn);
            string telephone = comm.ExecuteScalar().ToString();

            // Get Email
            selectCommand = "select email from Users where userName='" + selectedUserName + "'";
            comm = new SqlCommand(selectCommand, conn);
            string email = comm.ExecuteScalar().ToString();


           

            if (!Page.IsPostBack)
            {            
                // Fill text boxes
                UserNameTextBox.Text = selectedUserName;
                FirstNameTextBox.Text = firstName;
                LastNameTextBox.Text = lastName;
                AddressTextBox.Text = address;
                TelephoneTextBox.Text = telephone;
                EmailTextBox.Text = email;
            }
        }

        protected void ButtonCencel_Click(object sender, EventArgs e)
        {
            //Clear session
            Session["SelectedUserName"] = null;
            Response.Redirect("homeAdmin.aspx");
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string selectedUserName = Session["SelectedUserName"].ToString();

            //Get data from page           
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string address = AddressTextBox.Text;
            string telephone = TelephoneTextBox.Text;
            string email = EmailTextBox.Text;

            string updateQuery;
            //Ckeck password
            if (password == null || password == "")
            {
                updateQuery = $"update Users set first_name='{firstName}', lastst_name='{lastName}', address='{address}', telephone='{telephone}', email='{email}', userName='{userName}' where userName='{selectedUserName}'";
            }
            else
            {
                updateQuery = $"update Users set first_name='{firstName}', lastst_name='{lastName}', address='{address}', telephone='{telephone}', email='{email}', userName='{userName}', password='{password}' where userName='{selectedUserName}'";

            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationStoreConnectionString"].ConnectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand(updateQuery, conn);
            comm.ExecuteScalar();

            Session["SelectedUserName"] = null;
            Response.Redirect("homeAdmin.aspx");
        }

        protected void ButtonChangePassowrd_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Enabled = true;
        }
    }
}