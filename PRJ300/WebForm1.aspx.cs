﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString()))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(@"SELECT * FROM [campus\S00171672].DummyTable", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }

            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString()))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(@"SELECT * FROM [campus\S00171672].DummyTable2", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
            }
        }

        protected void onClick(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString()))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(@"SELECT * FROM [campus\S00171672].DummyTable WHERE Name is null OR price is null", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }

            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["S00171672ConnectionString"].ToString()))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(@"SELECT * FROM [campus\S00171672].DummyTable2 WHERE Name is null OR price is null", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
            }
        }
    }
}