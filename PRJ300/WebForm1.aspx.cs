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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString());
        OracleConnection oracon = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            userWelcome.Text = "Welcome Name";
            //get user's name from login table

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData", sqlcon);

            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                itemsListBox.Items.Add(dr["Description"].ToString());
            }

            string[] array1 = new string[] {"productmasterdata" };
            string[] array2 = new string[] {"customermasterdata"};

         


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

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData WHERE DESCRIPTION like '%"+ItemSearch+"%'", sqlcon);

            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                itemsListBox.Items.Add(dr["Description"].ToString());
            }
        }

        protected void AZRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemsListBox.Items.Clear();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData ORDER BY Description ASC", sqlcon);

            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                itemsListBox.Items.Add(dr["Description"].ToString());
            }
        }

        protected void ZARadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemsListBox.Items.Clear();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData ORDER BY Description DESC", sqlcon);

            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                itemsListBox.Items.Add(dr["Description"].ToString());
            }
        }

        protected void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string desc = itemsListBox.SelectedItem.Value.ToString();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData WHERE Description LIKE '" + desc + "'", sqlcon);

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
        }

        protected void timeAllowedList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}