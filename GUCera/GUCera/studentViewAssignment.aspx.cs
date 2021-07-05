using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class studentViewAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }

        protected void Assignment(object sender, EventArgs e)
        {
            
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
            try
            {
                int cID = (int)long.Parse(course.Text);
                String loggedUser = Session["user"].ToString();

                SqlCommand assignproc = new SqlCommand("viewAssign", conn);
                assignproc.CommandType = System.Data.CommandType.StoredProcedure;
                assignproc.Parameters.Add(new SqlParameter("@courseId", cID));
                assignproc.Parameters.Add(new SqlParameter("@Sid", loggedUser));

                conn.Open();
                assignproc.ExecuteNonQuery();
                StringBuilder table = new StringBuilder();


                SqlDataReader rdr = assignproc.ExecuteReader();
                if (rdr.HasRows)
                {
                    table.Append("<table border='1'>");
                    table.Append("<tr><th>CourseID</th>" +
                                 "<th>Assignment Number</th>" +
                                 "<th>Assignment Type</th>" +
                                 "<th>Full Grade</th>" +
                                 "<th>Weight</th>" +
                                 "<th>Deadline</th>" +
                                 "<th>Content</th>");
                    table.Append("</tr>");

                    while (rdr.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + rdr[0] + "</td>");
                        table.Append("<td>" + rdr[1] + "</td>");
                        table.Append("<td>" + rdr[2] + "</td>");
                        table.Append("<td>" + rdr[3] + "</td>");
                        table.Append("<td>" + rdr[4] + "</td>");
                        table.Append("<td>" + rdr[4] + "</td>");
                        table.Append("<td>" + rdr[6] + "</td>");
                        table.Append("</tr><br />");
                    }
                    table.Append("</table><br /><hr />");
                }
                else {
                   table.Append("Course has no assignment(s) OR does not exist!<br /><br />" );
                }
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rdr.Close();
                conn.Close();
            }
            catch (Exception) {
                PlaceHolder1.Controls.Add(new Literal { Text = "Please enter a valid course code!<br /><br />" });
            }
            }
    }
}