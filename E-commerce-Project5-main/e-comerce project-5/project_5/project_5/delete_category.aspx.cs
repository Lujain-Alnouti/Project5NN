﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_5
{
    public partial class delete_category : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = Request.QueryString["id"];
                int s1 = Convert.ToInt32(s);
                SqlConnection connect = new SqlConnection("data source =DESKTOP-6GNKJL5\\SQLEXPRESS; database =e-commerce ; integrated security=SSPI");
                SqlCommand comand = new SqlCommand("select * from category", connect);
                connect.Open();

                SqlDataReader reada = comand.ExecuteReader();
                // string table = "<table class='table table-striped'> <tr><th>ID</th> <th>Name</th> <th>Email</th> <th>PhoneNumber</th> <th></th> <th></th>";

                while (reada.Read())
                {
                    if ((Int32)reada[0] == s1)
                    {
                        Image2.ImageUrl = "img\\" + reada[2];
                        Label1.Text = (string)reada[1];
                    }




                }
              
                connect.Close();
              

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                string s = Request.QueryString["id"];
                int s1 = Convert.ToInt32(s);
                SqlConnection cc = new SqlConnection("data source = DESKTOP-6GNKJL5\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");


                string query = "DELETE FROM category WHERE  id='" + s1 + "'";
                SqlCommand comand = new SqlCommand(query, cc);
                cc.Open();
                //SqlDataReader reada = comand.ExecuteReader();



                comand.ExecuteNonQuery();

                Label2.Visible = true;
                cc.Close();
            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }

    }
    }

