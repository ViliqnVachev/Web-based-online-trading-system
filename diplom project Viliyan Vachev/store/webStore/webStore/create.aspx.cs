using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;

namespace webStore
{
    public partial class create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserId"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //get category id

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CategoryConnectionString"].ConnectionString);
            conn.Open();
            string checkCategoryId = "select id_category from Categories where gategory_name='" + DropDownListCategory.Text + "'";
            SqlCommand idCategoryComm = new SqlCommand(checkCategoryId, conn);

            string idCategoryString = idCategoryComm.ExecuteScalar().ToString().Replace(" ", "");

            int categoryId = int.Parse(idCategoryString);
            conn.Close();

            //get user id

            int userId = int.Parse(Session["UserId"].ToString());



            //get price validation
            string patern = @"(^\d+(,\d{3})*(\.\d{1,2})?$)";
            double price = 0.0;
            string line = TextBoxPrice.Text;
            Match match = Regex.Match(line, patern);

            if (Regex.IsMatch(line, patern))
            {
                price = double.Parse(line);
                LabelValid.Visible = false;
            }
            else
            {
                LabelValid.Visible = true;
                return;
            }
            // insert into imagese
            if (this.FileUploadImages.HasFile)
            {
                double filesize = FileUploadImages.PostedFile.ContentLength;
                double check = filesize / 1024 / 1024;

                if (check > 1)
                {
                    this.Label1.Text = "File size exceeds 1 megabyte!";
                    Label1.Visible = true;
                }
                else
                {
                    Label1.Visible = false;
                    string APP_PATH = System.Web.HttpContext.Current.Request.ApplicationPath.ToLower();
                    if (APP_PATH == "/")      //a site
                        APP_PATH = "/";
                    else if (!APP_PATH.EndsWith(@"/")) //a virtual
                        APP_PATH += @"/";

                    string it = System.Web.HttpContext.Current.Server.MapPath(APP_PATH);
                    if (!it.EndsWith(@"\"))
                        it += @"\";

                    string filename = Guid.NewGuid().ToString(); //това генерира уникално име за файла
                    string ext = Path.GetExtension(this.FileUploadImages.FileName);
                    string savePath = it + @"upload\" + filename + ext;

                    this.FileUploadImages.SaveAs(savePath); //това записва файла на диска

                    string savep = @"upload/" + filename + ext; //това е за базата данни стойността

                    // insert into Products table
                    int visible = 0;
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductsConnectionString"].ConnectionString);
                    conn.Open();

                    string insert = "insert into Products(id_category,id_user,product_name,price,quantity,image,description,visible)" +
                           "values(@categoryId,@userId,@productName,@price,@quantity,@image,@description,@visible)";

                    SqlCommand comm = new SqlCommand(insert, conn);
                    comm.Parameters.AddWithValue("@categoryId", categoryId);
                    comm.Parameters.AddWithValue("@userId", userId);
                    comm.Parameters.AddWithValue("@productName", TextBoxProdName.Text);
                    comm.Parameters.AddWithValue("@price", price);
                    comm.Parameters.AddWithValue("@quantity", TextBoxQuantity.Text);



                    comm.Parameters.AddWithValue("@image", savep);

                    comm.Parameters.AddWithValue("@description", TextBoxDescription.Text);
                    comm.Parameters.AddWithValue("@visible", visible);

                    comm.ExecuteNonQuery();

                    conn.Close();


                    TextBoxProdName.Text = string.Empty;
                    TextBoxPrice.Text = string.Empty;
                    TextBoxQuantity.Text = string.Empty;
                    TextBoxDescription.Text = string.Empty;

                    LabelSuccess.Visible = true;
                    
                }
            }
        }
    }
}