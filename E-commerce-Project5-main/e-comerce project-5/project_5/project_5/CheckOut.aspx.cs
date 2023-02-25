using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_5
{
    public partial class CheckOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string sub = Request.QueryString["total"];
            int sss = Convert.ToInt32(sub);
            subtotal.Text = sub+" JD";
            string[] del=delivery.Text.Split(' ');
            int de = Convert.ToInt32(del[0]);
            int tot = sss + de;
            total.Text = tot + " JD";


            /////////////////////////////////////////////////////////////////////////////////////////////
            ///
            if (!IsPostBack)
            {


                try
                {
                    string product_name = Request.QueryString["id"];

                    SqlConnection cc = new SqlConnection("data source = DESKTOP-6GNKJL5\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");
                    string query = "SELECT  product.pName ,product.pImage ,product.description ,product.price ,cart.quantity ,cart.total \r\nFROM product\r\nINNER JOIN cart ON product.id =cart.productId;";
                    SqlCommand cmd = new SqlCommand(query, cc);
                    cc.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    string table = "<table class='table table-striped'> <tr> <th>Product Name</th><th>Image</th><th>Price</th><th>Quantity</th><th>total</th></tr>";

                    double sum = 0;
                    while (sdr.Read())
                    {

                        //if ((string)sdr[1] == product_name)
                        //{
                        double x = Convert.ToDouble(sdr[3]) * Convert.ToDouble(sdr[4]);
                        table += $"<tr><td>{sdr[0]}</td><td><img src =img\\{sdr[1]}  width=200px; height=200px /></td> <td> {sdr[3]} JOD</td><td>{sdr[4]}</td><td>{x}</td></tr>";
                        sum += x;
                        //}
                    }
                    table += "</table>";
                    Label1.Text = table;
                  
                   

                }
                catch (SqlException q)
                {
                    Response.Write(q.Message);
                }



            }


        }
        protected void checkout_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source=DESKTOP-6GNKJL5\\SQLEXPRESS; database=e-commerce; integrated security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * from userReg", connection);
            connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {


                int y = (int)rd[0];
                if (y!= 0)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Register.aspx");
                 }
            }


        }
    }
}
