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
    public partial class viewInstructors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }

        protected void Yes(object sender, EventArgs e)
        {
            Response.Redirect("Enroll.aspx"); ;
        }

        protected void Instructors(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            //int loggedUser = 4;
            // int loggedUser = (int)Session["user"];
            int course = Int32.Parse(cid.Text);


            SqlCommand enr = new SqlCommand("cInstructors", conn);



            enr.CommandType = System.Data.CommandType.StoredProcedure;





            //Executing the SQLCommand
            conn.Open();
            try
            {
                enr.Parameters.Add(new SqlParameter("@cid", course));
                enr.ExecuteNonQuery();
                first.Style.Add("visibility", "hidden");
                t.Style.Add("visibility", "visible");
                StringBuilder table = new StringBuilder();

                SqlDataReader rdr = enr.ExecuteReader();
                table.Append("<table border='8'>");
                table.Append("<tr><th>Course Name</th>" + "<th>Course  ID</th>" + "<th>Instructor ID</th>" + "<th>First Name </th>" + "<th>Last Name </th>");
                table.Append("</tr>");
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        table.Append("<tr>");
                        table.Append("<td>" + rdr[0] + "</td>");
                        table.Append("<td>" + rdr[1] + "</td>");
                        table.Append("<td>" + rdr[2] + "</td>");
                        table.Append("<td>" + rdr[3] + "</td>");
                        table.Append("<td>" + rdr[4] + "</td>");
                    }
                }
                table.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rdr.Close();

            }
            catch (Exception)
            {
                Response.Write("Invalid Input! ");
            }

            conn.Close();

        }



    }
}