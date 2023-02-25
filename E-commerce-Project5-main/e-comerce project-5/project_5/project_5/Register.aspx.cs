using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_5
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //    if (!IsPostBack)
            //    {
            //bool s = false;
            try
            {
                SqlConnection cc = new SqlConnection("data source=DESKTOP-V50HPE1\\SQLEXPRESS; database=e-commerce; integrated security=SSPI");
                cc.Open();

                // string query1 = "select * from  userReg";
                // cmd1 = new SqlCommand(query1, cc);
                // SqlDataReader sdr = cmd1.ExecuteReader();

                //while (sdr.Read())
                //{
                //    if (TextBox3.Text == sdr[3]) { s = true; }


                //}
                //if (s)
                //{
                //    Label la = new Label();
                //    this.Controls.Add(la);
                //    la.Text = "You Are Already Exist";
                //}
                /**************************************************/
                //SqlCommand comand = new SqlCommand("select * from name_and_password", cc);

                string query = "insert into userReg (Fname,Email,PhoneNumber,Password,RolLogin) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + 2 + "') ";
                SqlCommand cmd = new SqlCommand(query, cc);
                cmd.ExecuteNonQuery();
                Label1.Visible = true;
                Response.Redirect("Shopping_Bag_card.aspx");
                cc.Close();
            }

            catch (SqlException q)
            {
                Response.Write(q.Message);
            }

        }
    }
}