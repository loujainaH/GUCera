using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class studentSubmitAssignment : System.Web.UI.Page
    { protected void Page_Load(object sender, EventArgs e)
        {}
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }
        protected void Submit(object sender, EventArgs e)
        {
        string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
            try
            {
                String Type = type.Text;
                int Number = (int)long.Parse(number.Text);
                int Course = (int)long.Parse(course.Text);
                int loggedUser = (int)Session["user"];

                SqlCommand sub = new SqlCommand("submitAssign", conn);
                sub.CommandType = System.Data.CommandType.StoredProcedure;

                sub.Parameters.Add(new SqlParameter("@assignType", Type));
                sub.Parameters.Add(new SqlParameter("@assignnumber", Number));
                sub.Parameters.Add(new SqlParameter("@sid", loggedUser));
                sub.Parameters.Add(new SqlParameter("@cid", Course));

                conn.Open();
                sub.ExecuteNonQuery();

                SqlCommand check = new SqlCommand("Select cid , sid from StudentTakeAssignment", conn);
                check.ExecuteNonQuery();
                SqlDataReader rdr = check.ExecuteReader();
                int x = 0;
                int y = 0;
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        x = rdr.GetInt32(rdr.GetOrdinal("cid"));
                        y = rdr.GetInt32(rdr.GetOrdinal("sid"));
                    }
                    rdr.Close();
                }

                if (!(x == Course && y == loggedUser))
                {
                    String bye = "<br /><hr /><br />You cannot submit an assignment for a course that you do not take!<br /><br /><hr /><br />";
                    PlaceHolder1.Controls.Add(new Literal { Text = bye });
                    conn.Close();
                }
                else
                {
                    String bye = "<br /><hr /><br />Your assignment was submitted Successfuly! Great Work!<br /><br /><hr /><br />";
                    PlaceHolder1.Controls.Add(new Literal { Text = bye });
                    divData.Style.Add("visibility", "hidden");
                    conn.Close();
                }            
            }
            catch {
                PlaceHolder2.Controls.Add(new Literal { Text= "<hr /><br />" +
                                                            "Please enter valid Data and make sure that you have not submitted this assignment before!" +
                                                            "<br /><br /><hr />" });
            }
        }
    }
}