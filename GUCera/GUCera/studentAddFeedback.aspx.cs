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
    public partial class studentAddFeedback : System.Web.UI.Page
    {
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void Feedback(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                int Course = (int)long.Parse(course.Text);
                String FB = fb.Text;
                int loggedUser = (int)Session["user"];

                SqlCommand addFB = new SqlCommand("addFeedback", conn);
                addFB.CommandType = System.Data.CommandType.StoredProcedure;

                addFB.Parameters.Add(new SqlParameter("@comment", FB));
                addFB.Parameters.Add(new SqlParameter("@cid", Course));
                addFB.Parameters.Add(new SqlParameter("@sid", loggedUser));

                conn.Open();
                if (FB != "")
                {
                    addFB.ExecuteNonQuery();

                    SqlCommand studCourse = new SqlCommand("Select cid , comment , sid from Feedback", conn);
                    studCourse.ExecuteNonQuery();
                    SqlDataReader rdr = studCourse.ExecuteReader();
                    int x = 0;
                    String y = "";
                    int z = 0;
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            x = rdr.GetInt32(rdr.GetOrdinal("cid"));
                            y = rdr.GetString(1);
                            // y = rdr["comment"].ToString();
                            z = rdr.GetInt32(rdr.GetOrdinal("sid"));
                        }
                        rdr.Close();
                    }

                    if (!(x == Course && y == FB && z == loggedUser))
                    {
                        PlaceHolder1.Controls.Add(new Literal
                        {
                            Text = " <br /><br /><hr /><br />" +
                            "                                             Please enter a course that you are enrolled in! " +
                            "                                             <br /><br /><hr /><br />"
                        });
                    }
                    else
                    {
                        String bye = "<br /><br /><hr /><br />" +
                                     "&nbsp;&nbsp;&nbsp;" +
                                     "Your feedback was submitted Successfuly! <br /><br /><hr /><br />";
                        PlaceHolder1.Controls.Add(new Literal { Text = bye });
                    }
                    feebackDiv.Style.Add("visibility", "hidden");
                    conn.Close();
                }
                else {
                    PlaceHolder1.Controls.Add(new Literal
                    {
                        Text = " <br /><br /><hr /><br />" +
                           "                                             Please enter a feedback! " +
                           "                                             <br /><br /><hr /><br />"
                    });
                }
            }
            catch (Exception)
            {
                Response.Write("Invalid Input(s)!");
            }
        }
    }
}