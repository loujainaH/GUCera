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
    public partial class courses : System.Web.UI.Page
    {
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }
        protected void Instructors(object sender, EventArgs e)
        { Response.Redirect("viewInstructors.aspx"); }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courses = new SqlCommand("availableCourses", conn);
            courses.CommandType = CommandType.StoredProcedure;
            conn.Open();
            courses.ExecuteNonQuery();
            StringBuilder t = new StringBuilder();

            SqlDataReader reader = courses.ExecuteReader();
            t.Append("<table border='8'>");
            t.Append("<tr><th>Name</th>" + "<th>Course ID</th>");
            t.Append("</tr>");
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    t.Append("<tr>");
                    t.Append("<td>" + reader[0] + "</td>");
                    t.Append("<td>" + reader[1] + "</td>");
                }
            }
            t.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = t.ToString() });
            reader.Close();





            //PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });

            conn.Close();





        }
    }
}