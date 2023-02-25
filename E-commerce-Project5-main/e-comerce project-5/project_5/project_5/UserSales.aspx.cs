using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_5
{
    public partial class UserSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string str = Request.QueryString["id"];
                int x = Convert.ToInt32(str);
                SqlConnection cc = new SqlConnection("data source =DESKTOP-V50HPE1\\SQLEXPRESS; database =e-commerce ; integrated security=SSPI");

                //SqlCommand comand = new SqlCommand("select * from name_and_password", cc);
                cc.Open();
                string q = "select * from userReg where userId='" + x + "'";
                SqlCommand com = new SqlCommand(q, cc);
                SqlDataReader sdr = com.ExecuteReader();
                if (sdr.Read())
                {
                    username.Text = (string)sdr[1];
                    useremail.Text = (string)sdr[2];
                    //com.ExecuteNonQuery();

                }
                cc.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }



            if (!IsPostBack)
            {


                try
                {
                    string product_name = Request.QueryString["id"];

                    SqlConnection cc = new SqlConnection("data source = DESKTOP-V50HPE1\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");
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
                    users.Text = table;



                }
                catch (SqlException q)
                {
                    Response.Write(q.Message);
                }



            }

            }
        }
}