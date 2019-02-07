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

            //DataTable dt = new DataTable();

            //SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData", sqlcon);

            //da.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    itemsListBox.Items.Add(dr["Description"].ToString());
            //}

            {
                OracleCommand cmdd = new OracleCommand("select * from hr.CustomerMasterData", oracon);

                oracon.Open();
                cmdd.ExecuteNonQuery();

                OracleDataReader dr = cmdd.ExecuteReader();

                OracleDataAdapter da = new OracleDataAdapter(cmdd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow drr in dt.Rows)
                {
                    itemsListBox.Items.Add(drr["GROUP_CUSTOMER_NAME"].ToString());
                }
            }
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

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void Button2_Click(object sender, EventArgs e)
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

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            itemsListBox.Items.Clear();
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            itemsListBox.Items.Clear();
        }
    }
}