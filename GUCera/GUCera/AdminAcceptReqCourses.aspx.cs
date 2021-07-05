using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminAcceptReqCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("AdminHome.aspx"); }

        protected void Accept(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            //try{
                PlaceHolder p = new PlaceHolder();
                // int id = Int16.Parse(ID.Text);
                String code = Code.Text;
                int loggedUser =(int)Session["user"];
                Boolean flag = false;
                Boolean found = false;

            SqlCommand aproc = new SqlCommand("AdminAcceptRejectCourse ", conn);
                aproc.CommandType = System.Data.CommandType.StoredProcedure;
                aproc.Parameters.Add(new SqlParameter("@adminid", loggedUser));
                aproc.Parameters.Add(new SqlParameter("@courseId", code));
                conn.Open();
               

                SqlCommand courses = new SqlCommand("Select id,accepted  from Course ", conn);
               // courses.CommandType = System.Data.CommandType.StoredProcedure;
                courses.ExecuteNonQuery();
                SqlDataReader rdr = courses.ExecuteReader();
            if (code == "")
            {
                Response.Write("Please enter course id");
            }
            else
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (((rdr[0] + "") == code) && (rdr[1].ToString() == "True"))
                        {
                            Response.Write("The Course is already accepted");
                            flag = true;
                        }
                        if ((rdr[0] + "") == code) {
                            found = true;
                        }
                    }
                    rdr.Close();
                    //   }
                    //}
                }
                if ((flag == false) && (found==true))
                {
                    aproc.ExecuteNonQuery();
                    Response.Write("Course accpeted succcessfully<br />");
                }
                if (found == false) { Response.Write("The Course Does Not Exist"); }
            }
                conn.Close();

            //} catch {Response.Write("Invalid input<br />");}
        }
    }
}