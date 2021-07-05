using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class studentListCertificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }
        protected void certificate(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try { 
                int cID = (int)long.Parse(course.Text);
                int loggedUser = (int)Session["user"];

                SqlCommand certify = new SqlCommand("viewCertificate", conn);
                certify.CommandType = System.Data.CommandType.StoredProcedure;
                certify.Parameters.Add(new SqlParameter("@cid", cID));
                certify.Parameters.Add(new SqlParameter("@Sid", loggedUser));

                conn.Open();
                certify.ExecuteNonQuery();
                //SqlDataReader rdr = assignproc.ExecuteReader(CommandBehavior.CloseConnection);
                StringBuilder table = new StringBuilder();


                SqlDataReader rdr = certify.ExecuteReader();
                if (rdr.HasRows)
                {
                    table.Append("<table border='1'>");
                    table.Append("<tr><th>Student ID</th>" +
                                 "<th>Course ID</th>" +
                                 "<th>Issue Date</th>");
                    table.Append("</tr>");

                    while (rdr.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + rdr[0] + "</td>");
                        table.Append("<td>" + rdr[1] + "</td>");
                        table.Append("<td>" + rdr[2] + "</td>");
                        table.Append("</tr>");
                    }
                    table.Append("</table>");
                }
                else { table.Append("Unfortunately, you do not have a certificate for this course!<br />" +
                    "You are either not enrolled in it or did not finish it<hr />"); }

                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rdr.Close();


                conn.Close();
            }
            catch(Exception){
                PlaceHolder1.Controls.Add(new Literal { Text ="Please enter a valid course code!<br />" });
            }
        }
    }
}