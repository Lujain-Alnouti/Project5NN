using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = TextBox1.Text;
                string pass = TextBox2.Text;

                SqlConnection cc = new SqlConnection("data source=DESKTOP-6GNKJL5\\SQLEXPRESS; database=e-commerce; integrated security=SSPI");
                cc.Open();
                string qry = "select * from userReg ";
                // string qry = "select * from userReg  ";
                SqlCommand cmd = new SqlCommand(qry, cc);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string Email = Convert.ToString(sdr[2]);
                    string Pass = Convert.ToString(sdr[4]);
                    int x = Convert.ToInt32(sdr[5]);

                    if (x == 1 && TextBox1.Text == "Rahma@gmail.com" && TextBox2.Text == "123123")
                    {
                        Response.Redirect("admin_categories-table.aspx?x="+x);
                    }
                   
                    else if (x == 2 && Email == TextBox1.Text && TextBox2.Text == Pass)
                    {
                        Response.Write("<script>alert('Welcome in our website')</script>");
                        Response.Redirect("Shopping_Bag_card.aspx?x="+x);
                    }
                    else if (Email != TextBox1.Text && x == 2)
                    {
                        Response.Write("<script>alert('You dont have account , please Signup')</script>");
                        //Response.Redirect("Register.aspx");
                    }
                    //else if (x != 2 || Email != TextBox1.Text || Pass != TextBox2.Text)
                    //{
                    //    Label4.Visible = true;

                    //    // Label4.Text = "email or Password Is not correct";
                    //}
                }
                //if (sdr.Read())
                //{
                //    Response.Redirect("category.aspx");
                //}
                //else if (TextBox1.Text=="yasmeen@gmail.com" && TextBox2.Text=="12345" && (sdr[2]=="2" ))
                //{
                //    Response.Redirect("admin.aspx");
                //}
                //else
                //{
                //    Label4.Text = "email or Password Is not correct";

                //}
                cc.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}