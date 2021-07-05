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
    public partial class viewPromocode : System.Web.UI.Page
    {
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int loggedUser = (int)Session["user"];

            SqlCommand viewpromo = new SqlCommand("viewPromocode", conn);
            viewpromo.CommandType = System.Data.CommandType.StoredProcedure;

            viewpromo.Parameters.Add(new SqlParameter("@sid", loggedUser));

            //  try {
            conn.Open();
            viewpromo.ExecuteNonQuery();
            //SqlDataReader rdr = assignproc.ExecuteReader(CommandBehavior.CloseConnection);
            StringBuilder t = new StringBuilder();

            SqlDataReader reader = viewpromo.ExecuteReader();
            t.Append("<table border='8'>");
            t.Append("<tr><th>Code</th>" +
                         "<th>Issue Date</th>" +
                         "<th>Expiry DateD</th>" +
                         "<th>Discount</th>" +
                         "<th>AdminID</th>"
                        );
            t.Append("</tr>");

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    t.Append("<tr>");
                    t.Append("<td>" + reader[0] + "</td>");
                    t.Append("<td>" + reader[1] + "</td>");
                    t.Append("<td>" + reader[2] + "</td>");
                    t.Append("<td>" + reader[3] + "</td>");
                    t.Append("<td>" + reader[4] + "</td>");


                    t.Append("</tr>");
                }
            }
            t.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = t.ToString() });
            reader.Close();




            conn.Close();





        }
    }
}