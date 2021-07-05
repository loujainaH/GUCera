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
    public partial class viewProfile : System.Web.UI.Page
    {
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }

        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int loggedUser = (int)Session["user"];

            SqlCommand viewprof = new SqlCommand("viewMyProfile", conn);
            viewprof.CommandType = System.Data.CommandType.StoredProcedure;

            viewprof.Parameters.Add(new SqlParameter("@id", loggedUser));

            //  try {
            conn.Open();
            viewprof.ExecuteNonQuery();
            //SqlDataReader rdr = assignproc.ExecuteReader(CommandBehavior.CloseConnection);
            StringBuilder t = new StringBuilder();

            SqlDataReader reader = viewprof.ExecuteReader();
            t.Append("<table border='8'>");
            t.Append("<tr><th>ID</th>" + "<th>GPA</th>" + "<th>ID</th>" + "<th>FirstName</th>" + "<th>LastName</th>" +
                         "<th>Password</th>" + "<th>Gender</th>" + "<th>Email</th>" + "<th>Address</th>");
            t.Append("</tr>");
            // string gend;

            // string V="";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // V = rdr.GetByte(rdr.GetOrdinal("gender")).ToString();
                    // if (rdr[6].Equals(V))
                    //  { gend = "Female"; }
                    //  else { gend = "Male"; }
                    Byte[] gender = (byte[])
                    reader.GetSqlBinary(reader.GetOrdinal("gender"));
                    string gend = "";
                    if (gender[0].Equals(1))
                    { gend = "Female"; }
                    else { gend = "Male"; }

                    t.Append("<tr>");
                    t.Append("<td>" + reader[0] + "</td>");
                    t.Append("<td>" + reader[1] + "</td>");
                    t.Append("<td>" + reader[2] + "</td>");
                    t.Append("<td>" + reader[3] + "</td>");
                    t.Append("<td>" + reader[4] + "</td>");
                    t.Append("<td>" + reader[5] + "</td>");
                    t.Append("<td>" + gend + "</td>");
                    t.Append("<td>" + reader[7] + "</td>");
                    t.Append("<td>" + reader[8] + "</td>");
                    t.Append("</tr>");

                }
            }
            t.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = t.ToString() });
            //Response.Write(V);
            reader.Close();




            conn.Close();





        }
    }
}