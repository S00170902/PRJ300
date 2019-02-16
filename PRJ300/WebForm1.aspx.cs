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
        int count; //count for drop box selection
          
        string[] array1 = new string[] { "ProductMasterData" };
        string[] array2 = new string[] { "CustomerMasterData" };
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString());
        OracleConnection oracon = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ToString());
       

protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (Session["UserName"] == null)
                    Response.Redirect("Login.aspx"); 
            }

            userWelcome.Text = "Welcome: " + Session["UserName"]; //displays username name on the avatar icon
            
            if(!IsPostBack)
            {
                if (DropDownList1.SelectedItem.Text == "SQL")
                {
                    count = 0;
                }
                else if (DropDownList1.SelectedItem.Text == "Oracle")
                {
                    count = 1;
                }
                if (count == 0)
                {
                    tablesListBox.Items.Clear();
                    for (int i = 0; i < array1.GetLength(0); i++)
                    {
                        tablesListBox.Items.Add(array1[i].ToString());
                    }
                    itemsListBox.Items.Clear();
                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData", sqlcon);

                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                    }

                }
                else if (count == 1)
                {
                    tablesListBox.Items.Clear();
                    for (int i = 0; i < array2.GetLength(0); i++)
                    {
                        tablesListBox.Items.Add(array2[i].ToString());
                    }
                    itemsListBox.Items.Clear();
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
            if (DropDownList1.SelectedItem.Text == "SQL")
            {
                count = 0;
            }
            else if (DropDownList1.SelectedItem.Text == "Oracle")
            {
                count = 1;
            }
            
            if (count == 0)
            {
                itemsListBox.Items.Clear();
                var ItemSearch = searchBox.Text;
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData WHERE DESCRIPTION like '%" + ItemSearch + "%'", sqlcon);

                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }
            }
            else if (count == 1)
            {
                itemsListBox.Items.Clear();
                var ItemSearch = searchBox.Text;
                DataTable dt = new DataTable();

                OracleDataAdapter da = new OracleDataAdapter(@"SELECT * FROM hr.CustomerMasterData WHERE GROUP_CUSTOMER_NAME like '%" + ItemSearch + "%'", oracon);

                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["GROUP_CUSTOMER_NAME"].ToString());
                }
            }
            
            
        }

        protected void AZRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "SQL")
            {
                count = 0;
            }
            else if (DropDownList1.SelectedItem.Text == "Oracle")
            {
                count = 1;
            }
            itemsListBox.Items.Clear();
            DataTable dt = new DataTable();
            if (count == 0)
            {
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData ORDER BY DESCRIPTION ASC", sqlcon);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }
            }
            else if (count == 1)
            {
                OracleDataAdapter da = new OracleDataAdapter(@"select * from hr.CustomerMasterData order by GROUP_CUSTOMER_NAME ASC", oracon);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["GROUP_CUSTOMER_NAME"].ToString());
                }
            }


        }

        protected void ZARadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "SQL")
            {
                count = 0;
            }
            else if (DropDownList1.SelectedItem.Text == "Oracle")
            {
                count = 1;
            }
            itemsListBox.Items.Clear();
            DataTable dt = new DataTable();
            if (count == 0)
            {
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData ORDER BY DESCRIPTION DESC", sqlcon);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }
            }
            else if (count == 1)
            {
                OracleDataAdapter da = new OracleDataAdapter(@"select * from hr.CustomerMasterData order by GROUP_CUSTOMER_NAME DESC", oracon);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["GROUP_CUSTOMER_NAME"].ToString());
                }
            }

            


        }

        protected void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(itemsListBox.SelectedItem.Value.ToString());
            string desc = itemsListBox.SelectedItem.Value.ToString();

            if (count == 0)
            {
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
            }
            else if (count == 1)
            {
                OracleDataAdapter da = new OracleDataAdapter(@"select * from hr.CustomerMasterData WHERE GROUP_CUSTOMER_NAME LIKE '" + desc + "'", oracon);

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
        }

        protected void timeAllowedList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "SQL")
            {
                count = 0;
            }
            else if (DropDownList1.SelectedItem.Text == "Oracle")
            {
                count = 1;
            }

            if (count == 0)
            {
                itemsListBox.Items.Clear();
                tablesListBox.Items.Clear();
                for (int i = 0; i < array1.GetLength(0); i++)
                {
                    tablesListBox.Items.Add(array1[i].ToString());
                }

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM dbo.ProductMasterData", sqlcon);

                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemsListBox.Items.Add(dr["DESCRIPTION"].ToString());
                }

            }
            else if (count == 1)
            {
                tablesListBox.Items.Clear();
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    tablesListBox.Items.Add(array2[i].ToString());
                }

                OracleCommand cmdd = new OracleCommand("select * from hr.CustomerMasterData", oracon);

                
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

        protected void nullLimitList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void coloursList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}