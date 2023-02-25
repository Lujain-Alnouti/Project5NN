using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_5
{
    public partial class Single_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            

            try
            {
                string str = Request.QueryString["id"];
                int x12 = Convert.ToInt32(str);
                SqlConnection connection = new SqlConnection("data source=DESKTOP-V50HPE1\\SQLEXPRESS; database=e-commerce; integrated security=SSPI");

                //SqlCommand comand = new SqlCommand("select * from name_and_password", cc);
                connection.Open();
                string q = "select * from product where id='"+ x12+"'";

                    
                SqlCommand com = new SqlCommand(q, connection);
                SqlDataReader sdr = com.ExecuteReader();
                if (sdr.Read())
                {
                    Label1.Text = (string)sdr[1];
                    product_img.ImageUrl = "~/img/" + (string)sdr[4];
                    description.Text = (string)sdr[2];
                    price.Text =  sdr[3] + " JD";
                    //com.ExecuteNonQuery();

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }

        protected void minus_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(quan.Text);
            if (c == 1) { quan.Text = "1"; }
            else if (c > 1)
            {
                c--;
                quan.Text = c.ToString();
            }

        }

        protected void plus_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(quan.Text);
            c++;
            quan.Text = c.ToString();

        }

        protected void post_Click(object sender, EventArgs e)
        {/***********/
            //string x = Server.MapPath(@"~\comment.txt");
            //using (StreamWriter co = File.AppendText(x))
            //{
            //    co.WriteLine(add_comment.Text);
            //}
            //string[] rea = File.ReadAllLines(x);

            //Label[] l = new Label[rea.Length];


            //    l[rea.Length-1] = new Label();





            //    l[rea.Length - 1].Text = rea[rea.Length - 1];
            //    this.Controls.Add(l[rea.Length - 1]);





        }

        protected void addtocart_Click(object sender, EventArgs e)
        {
           
            




        }
        protected void addcommwnrt_Click(object sender, EventArgs e)
        {
            string str = Request.QueryString["id"];
            int x12 = Convert.ToInt32(str);
            
            string pn = Label1.Text;
            //string pID = Request.QueryString["PID"];
            //int iid = Convert.ToInt32(pID);
            int iid = 3;
            //string uID = Request.QueryString["UID"];
            //int iiu = Convert.ToInt32(pID);
            
            Response.Redirect("Comments.aspx?productId="+ x12);
           // Response.Redirect("Comments.aspx?userId=" + uID + "&productId=" + iid);
        }

        protected void addtocart_Click1(object sender, EventArgs e)
        {
            try
            {
                string str = Request.QueryString["id"];
                int x12 = Convert.ToInt32(str);
                string quantity = quan.Text;
                int quantity1 = Convert.ToInt32(quantity);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlConnection cc = new SqlConnection("data source = DESKTOP-V50HPE1\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");

                cc.Open();
                string query2 = "insert into cart (productId ,quantity,total,userId) values ('" + x12 + "' ,'" + quantity1 + "' ,'" + 200 + "','" + 2 + "')";
                SqlCommand cmd2 = new SqlCommand(query2, cc);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
                cc.Close();

                //    string query = "select * from cart";

                //    SqlCommand cmd = new SqlCommand(query, cc);
                //    SqlDataReader sdr = cmd.ExecuteReader();
                //    cmd.ExecuteNonQuery();
                //    cc.Close();
                //    bool flag = false;
                //    while (sdr.Read())
                //    {
                //        if ((Int32)sdr[2] == x12)
                //        {
                //            flag = false;
                //            break;
                //        }
                //        else
                //        {
                //            flag = true;
                //        }
                //    }

                //    if (flag == false)
                //    {
                //        SqlConnection cc1 = new SqlConnection("data source = DESKTOP-V50HPE1\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");

                //        cc1.Open();
                //        int Q = quantity1 + (int)sdr[4];
                //        string query1 = "  Update cart set quantity= '" + Q + "'   where id = '" + x12 + "'";
                //        SqlCommand cmd1 = new SqlCommand(query1, cc1);
                //        cmd1.ExecuteNonQuery();
                //        cc1.Close();
                //        // string query1 = "update into cart (productId ,quantity,total,userId) values ('" + x12 + "' ,'" + quantity1 + "' ,'" + 200 + "','" + 2 + "')";
                //    }
                //    else
                //    {
                //        SqlConnection cc2 = new SqlConnection("data source = DESKTOP-V50HPE1\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");

                //        cc2.Open();
                //        string query2 = "insert into cart (productId ,quantity,total,userId) values ('" + x12 + "' ,'" + quantity1 + "' ,'" + 200 + "','" + 2 + "')";
                //        SqlCommand cmd2 = new SqlCommand(query2, cc2);
                //        cmd2.ExecuteNonQuery();
                //        cc2.Close();
                //    }





                Label2.Visible = true;

                //Response.Redirect("Shopping_Bag_card.aspx?id=" + x12);

            }
            catch (SqlException q)
            {
                Response.Write(q.Message);
            }


        }
    }
}