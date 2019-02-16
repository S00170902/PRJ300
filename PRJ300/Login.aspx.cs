using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PRJ300
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errormessage.Visible = false;
        }

        protected void buttonlogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=cairnssql\glencar;Initial Catalog=S00171672;Integrated Security=True"))
            {
                sqlcon.Open();
                string query = "SELECT * FROM Logintable WHERE UserName=@username AND Password=@password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", username.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", password.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Roles"].ToString() == "admin")
                    {
                        Session["UserName"] = username.Text.Trim();
                        Response.Redirect("WebForm1.aspx");
                    }

                    else if (dt.Rows[0]["Roles"].ToString() == "product" || dt.Rows[0]["Roles"].ToString() == "customer")
                    {
                        Session["UserName"] = username.Text.Trim();
                        Response.Redirect("WebForm2.aspx");
                    }

                    else
                    {
                        errormessage.Visible = true;
                    }
                }



            }

        }
    }
}