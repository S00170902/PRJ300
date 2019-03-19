using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace PRJ300
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString());
        OracleConnection oracon = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ToString());


        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (Session["UserName"] == null)
                    Response.Redirect("Login.aspx");
            }

            userWelcome.Text = "Welcome: " + Session["UserName"]; //displays username name on the avatar icon

            if (!IsPostBack)
            {
                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData", sqlcon);

                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                    }
                }

            //{
            //    OracleCommand cmdd = new OracleCommand("select * from hr.CustomerMasterData", oracon);

            //    oracon.Open();
            //    cmdd.ExecuteNonQuery();

            //    OracleDataReader dr = cmdd.ExecuteReader();

            //    OracleDataAdapter da = new OracleDataAdapter(cmdd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);

            //    foreach (DataRow drr in dt.Rows)
            //    {
            //        itemsListBox.Items.Add(drr["GROUP_CUSTOMER_NAME"].ToString());
            //    }
            //}
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
                itemsListBox.Items.Clear();
                var ItemSearch = searchBox.Text;
                DataTable dt = new DataTable();

                string sql = string.Format("SELECT * FROM dbo.ProductMasterData WHERE DESCRIPTION like '%{0}%'", ItemSearch.Replace("'", "''"));
                SqlDataAdapter da = new SqlDataAdapter(@sql, sqlcon);

                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }
        }

        protected void AZRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData ORDER BY DESCRIPTION ASC", sqlcon);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }
        }

        protected void ZARadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemsListBox.Items.Clear();
            DataTable dt = new DataTable();
           
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData ORDER BY DESCRIPTION DESC", sqlcon);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }
        }

        protected void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string desc = itemsListBox.SelectedItem.Value.ToString();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData WHERE DESCRIPTION LIKE '" + desc + "'", sqlcon);

                DataSet ds = new DataSet();
                da.Fill(ds);

                Dictionary<string, string> vals = new Dictionary<string, string>();

                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        vals.Add(dt.Columns[i].ColumnName, dr[dt.Columns[i].ColumnName].ToString());
                    }
                }

                details.DataSource = vals;
                details.DataBind();
            
                details.DataSource = vals;
                details.DataBind();
        }

        

        protected void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string table = tablesListBox.SelectedValue.ToString();
            //if (count == 0)
            //{
            //    itemsListBox.Items.Clear();
            //    DataTable dt = new DataTable();

            //    SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM ProductMasterData", sqlcon);

            //    da.Fill(dt);
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
            //    }
            //}
            //else if (count == 1)
            //{
            //    itemsListBox.Items.Clear();
            //    DataTable dt = new DataTable();
            //    OracleDataAdapter da = new OracleDataAdapter(@"select * from hr.CustomerMasterData", oracon);
            //    da.Fill(dt);
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        itemsListBox.Items.Add(dr["GROUP_CUSTOMER_NAME"].ToString());
            //    }
            //}
        }
    }
}