using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace project_5
{
    public partial class admin_edit_categories : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        { }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
                try
                {


                    string s = Request.QueryString["id"];
                    int id = Convert.ToInt32(s);
                    string folderPath = Server.MapPath("~/Files/");

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                    //Display the Picture in Image control.
                    Image1.ImageUrl = "~/Files/" + Path.GetFileName(FileUpload1.FileName);

                    /////////////////////////////////////////////////////



                    ////////////////////////////////////////////////////////
                    SqlConnection cc = new SqlConnection("data source = DESKTOP-V50HPE1\\SQLEXPRESS; database = e-commerce ; integrated security=SSPI");

                    SqlCommand comand = new SqlCommand("select * category", cc);
                    cc.Open();


                    string query = "  Update category set cName= '" + TextBox1.Text + "',cImage='" + FileUpload1.FileName + "'  where id = '" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, cc);
                    cmd.ExecuteNonQuery();
                    cc.Close();

                Label3.Visible = true;


            }
                catch (SqlException q)
                {
                    Response.Write(q.Message);
                }
            
        }

            }
        }
        
    
