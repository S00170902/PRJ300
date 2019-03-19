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
using System.Net.Mail;
using System.Collections;

namespace PRJ300
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int count; //count for drop box selection
        int days, limit; //for null limit for email
          
        string[] array1 = new string[] { "ProductMasterData" };
        string[] array2 = new string[] { "CustomerMasterData" };
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnectionString"].ToString());
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

                SqlCommand cmd = new SqlCommand("dbo.Notif", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlcon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                string s = "Null in Product Sku Code: ";

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    nullsListBox.Items.Add(s + dataRow["Sku Code"].ToString());
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

                string sql = string.Format("SELECT * FROM dbo.ProductMasterData WHERE DESCRIPTION like '%{0}%'", ItemSearch.Replace("'", "''"));
                SqlDataAdapter da = new SqlDataAdapter(@sql, sqlcon);

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
            string desc = itemsListBox.SelectedItem.Value.ToString();

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
                string sql = string.Format("SELECT * FROM dbo.ProductMasterData WHERE DESCRIPTION LIKE '{0}'", desc.Replace("'", "''"));
                SqlDataAdapter da = new SqlDataAdapter(@sql, sqlcon);

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

                Dictionary<string, string> vals2 = new Dictionary<string, string>();

                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        vals2.Add(dt.Columns[i].ColumnName, dr[dt.Columns[i].ColumnName].ToString());
                    }
                }

                details.DataSource = vals2;
                details.DataBind();
            }
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
                itemsListBox.Items.Clear();
                for (int i = 0; i < array2.GetLength(0); i++)
                {
                    tablesListBox.Items.Add(array2[i].ToString());
                }

                oracon.Open(); //have to open oracle connections now before populating listbox
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

        protected void timeAllowedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = timeAllowedList.SelectedItem.Text;
            days = int.Parse(selected.Substring(0, 1));

            //use this in email method
        }

        protected void nullLimitList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = nullLimitList.SelectedItem.Text;
            limit = int.Parse(selected);

            //use this in email method
        }

        protected void coloursList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colour = coloursList.SelectedItem.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("powerbi.aspx");

        }

        protected void SQLEmail()
        {
            string webpage = ""; //link for webpage for email
            //code for time limit
            int timeInMins = 288 * days;
            string sql = string.Format("SELECT SKU CODE from dbo.NullTbl WHERE Time > {0}", timeInMins);
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<string> list = new List<string>();
            DataTable dt = ds.Tables[0];

            foreach (var r in dt.Rows)
            {
                list.Add(r.ToString());
            }

            int counter = list.Count();

            //code for null limit
            string sql1 = string.Format("SELECT SKU CODE from dbo.NullTbl");
            SqlDataAdapter da1 = new SqlDataAdapter(sql, sqlcon);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            List<string> list1 = new List<string>();
            DataTable dt1 = ds1.Tables[0];

            foreach (var r in dt.Rows)
            {
                list1.Add(r.ToString());
            }

            

            if(counter > 0) //time limit
            {
                MailMessage mail = new MailMessage("cdfoodsnullalert@gmail.com", "Liamjonesprj300@gmail.com");
                //from , to , subject, success
                mail.Subject = "SQL Null Notifier";
                mail.Body = "You have " + counter + " Nulls in your product table that have existed for at least " + days +"days!\nClick <a href=\"" + webpage + "\">here</ID></a> to see more details";
                mail.IsBodyHtml = true;
                //making the body html to ensure hyperlink works
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                //e.g smtp.outlook.com
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("cdfoodsnullalert@gmail.com", "colmsangels");
                //username , password
                client.EnableSsl = true;
                client.Send(mail);
            }
            else if(list1.Count > limit) //null limit
            {
                MailMessage mail = new MailMessage("cdfoodsnullalert@gmail.com", "Liamjonesprj300@gmail.com");
                //from , to , subject, success
                mail.Subject = "SQL Null Notifier";
                mail.Body = "You have " + list1.Count + " nulls in your products table. Urgent action is advised.";
                mail.IsBodyHtml = true;
                //making the body html to ensure hyperlink works
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                //e.g smtp.outlook.com
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("cdfoodsnullalert@gmail.com", "colmsangels");
                //username , password
                client.EnableSsl = true;
                client.Send(mail);
            }
        }

        protected void ORAEmail()
        {
            string webpage = ""; //link for webpage for email
            //code for time limit
            int timeInMins = 288 * days;
            string sql = string.Format("SELECT GROUP_CUSTOMER_CODE from hr.NULLTBL WHERE Time > {0}", timeInMins);
            OracleDataAdapter da = new OracleDataAdapter(sql, oracon);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<string> list = new List<string>();
            DataTable dt = ds.Tables[0];

            foreach (var r in dt.Rows)
            {
                list.Add(r.ToString());
            }

            int counter = list.Count();

            //code for null limit
            string sql1 = string.Format("SELECT GROUP_CUSTOMER_CODE from hr.NULLTBL");
            OracleDataAdapter da1 = new OracleDataAdapter(sql1, oracon);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            List<string> list1 = new List<string>();
            DataTable dt1 = ds1.Tables[0];

            foreach (var r in dt.Rows)
            {
                list1.Add(r.ToString());
            }



            if (counter > 0) //time limit
            {
                MailMessage mail = new MailMessage("cdfoodsnullalert@gmail.com", "Liamjonesprj300@gmail.com");
                //from , to , subject, success
                mail.Subject = "Oracle Null Notifier";
                mail.Body = "You have " + counter + " Nulls in your SupplierMasterData table that have existed for at least " + days + "days!\nClick <a href=\"" + webpage + "\">here</ID></a> to see more details";
                mail.IsBodyHtml = true;
                //making the body html to ensure hyperlink works
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                //e.g smtp.outlook.com
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("cdfoodsnullalert@gmail.com", "colmsangels");
                //username , password
                client.EnableSsl = true;
                client.Send(mail);
            }
            else if (list1.Count > limit) //null limit
            {
                MailMessage mail = new MailMessage("cdfoodsnullalert@gmail.com", "Liamjonesprj300@gmail.com");
                //from , to , subject, success
                mail.Subject = "Oracle Null Notifier";
                mail.Body = "You have " + list1.Count + " nulls in your supplierMasterData table. Urgent action is advised.";
                mail.IsBodyHtml = true;
                //making the body html to ensure hyperlink works
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                //e.g smtp.outlook.com
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("cdfoodsnullalert@gmail.com", "colmsangels");
                //username , password
                client.EnableSsl = true;
                client.Send(mail);
            }
        }
    }
}