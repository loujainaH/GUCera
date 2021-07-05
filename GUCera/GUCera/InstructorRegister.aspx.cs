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
    public partial class InstructorRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void RegDone(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
            protected void Register(object sender, EventArgs e)
        {
           
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
            try
            {
                String first_name = firstName.Text;
                String last_name = lastName.Text;
                String password = Password.Text;
                String email = Email.Text;
                String address = Address.Text;
                String gender = Gender.Text;
                bool gen;
                if (gender.Equals("Female"))
                { gen = true; }
                else { gen = false; }
                // byte[] gender = (byte[]).Parse(Gender.Text);

                if (first_name.Equals("") || last_name.Equals("") || password.Equals("") || email.Equals("") || address.Equals("") || gender.Equals(""))
                {
                    PlaceHolder2.Controls.Add(new Literal { Text = "<br /><hr /><br />Please fill all data!!<br /><br /><hr /><br />" });

                }
                else
                {
                    SqlCommand instRegisterProc = new SqlCommand("InstructorRegister", conn);

                    //removed the : proc. ... needs @... which was not supplied
                    instRegisterProc.CommandType = System.Data.CommandType.StoredProcedure;

                    instRegisterProc.Parameters.Add(new SqlParameter("@first_name", first_name));
                    instRegisterProc.Parameters.Add(new SqlParameter("@last_name", last_name));
                    instRegisterProc.Parameters.Add(new SqlParameter("@password", password));
                    instRegisterProc.Parameters.Add(new SqlParameter("@email", email));
                    instRegisterProc.Parameters.Add(new SqlParameter("@address", address));
                    instRegisterProc.Parameters.Add(new SqlParameter("@gender", gen));

                    conn.Open();
                    instRegisterProc.ExecuteNonQuery();

                    SqlCommand instID = new SqlCommand("select id from instructor", conn);
                    instID.ExecuteNonQuery();
                    SqlDataReader rdr = instID.ExecuteReader();
                    String ID = "";
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ID = (rdr.GetInt32(rdr.GetOrdinal("id"))).ToString();
                        }
                    }
                    conn.Close();
                    //string page = "login.aspx";
                    string msg = "<br /><hr /><br />Your registration was completed successfuly!" +
                                 "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                 "Your ID is: "
                                  + ID +
                                  "<br /><br /><hr /><br />";
                    PlaceHolder1.Controls.Add(new Literal { Text = msg });
                    regDone.Style.Add("visibility", "visible");
                    regForm.Style.Add("visibility", "hidden");

                }
            }
            catch (Exception)
            {
                PlaceHolder2.Controls.Add(new Literal { Text = "<br /><hr /><br />Please enter valid data and use a unique email address!!<br /><br /><hr /><br />" });

            }
        }


    }
}