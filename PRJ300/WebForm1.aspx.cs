using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace PRJ300
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData", sqlcon);

            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ListBox1.Items.Add(dr["Description"].ToString());
            }
            
            

           
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
             
        }
        
    }
}