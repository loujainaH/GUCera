using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AdminListCoursesNotAccepted : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String table = " ";
            SqlCommand Rejcourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
            SqlDataReader rdr = Rejcourses.ExecuteReader();
            table += "<table border='1'>";
            table += "<tr><th>Course Name</th>" +
                         "<th>Credit Hours</th>" +
                           "<th>Price</th>" +
                           "<th>Content</th>";
            table += "</tr>";

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    table += "<tr>";
                    table += "<td>" + rdr[0] + "</td>";
                    table += "<td>" + rdr[1] + "</td>";
                    table += "<td>" + rdr[2] + "</td>";
                    table += "<td>" + rdr[3] + "</td>";
                    table += "</tr>";
                }
            }
            else
            {
                table += "The system doesn't contain any courses yet , Thank you :)<br /><br />";
            }

            table += "</table>";


            course.Controls.Add(new Literal { Text = table.ToString() });




        }
        protected void Home(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}