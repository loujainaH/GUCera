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
    public partial class Enroll : System.Web.UI.Page
    {
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }

        protected void Yes(object sender, EventArgs e)
        {
            Response.Redirect("Enroll.aspx"); ;
        }
        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void enrollcourse(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //int loggedUser = 6;
                int loggedUser = (int)Session["user"];
                int course = Int32.Parse(cid.Text);
                int instructor = Int32.Parse(instr.Text);

                SqlCommand enr = new SqlCommand("enrollInCourse", conn);

                enr.CommandType = System.Data.CommandType.StoredProcedure;

                enr.Parameters.Add(new SqlParameter("@sid", loggedUser));
                enr.Parameters.Add(new SqlParameter("@cid", course));
                enr.Parameters.Add(new SqlParameter("@instr", instructor));
                SqlParameter m = enr.Parameters.Add("@m", SqlDbType.Int);
                m.Direction = ParameterDirection.Output;
                SqlParameter i = enr.Parameters.Add("@i", SqlDbType.Int);
                i.Direction = ParameterDirection.Output;
                //Response.Write(pre.Value.ToString());
                //var l = (string)enr.Parameters["@m"].Value;
                //Executing the SQLCommand




                conn.Open();
                try
                {
                    enr.ExecuteNonQuery();
                    if (i.Value.ToString() == "0")
                    {
                        Response.Write("This instructor doesn't teach this course");

                    }
                    else
                    {
                        if (m.Value.ToString() == "0")
                        {
                            Response.Write("You didn't take this course pre-requisite");
                        }
                        else
                        {
                            //Response.Write("l is " + l);
                            firstCourse.Style.Add("visibility", "hidden");
                            enrollAgain.Style.Add("visibility", "visible");
                        }
                    }
                }
                catch (Exception)
                {
                    Response.Write("Invalid Input! ");
                }

                conn.Close();
            }
            catch (Exception) { Response.Write("Invalid Input! "); }
        }
    }
}


