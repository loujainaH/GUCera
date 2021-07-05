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
    public partial class AdminCreatePromoCode : System.Web.UI.Page
    {

        protected void Home(object sender, EventArgs e)
        { Response.Redirect("AdminHome.aspx"); }
        protected void Page_Load(object sender, EventArgs e)
        { }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                // int id = Int16.Parse(ID.Text);
                Decimal discount = decimal.Parse(Discount.Text);
                String code = Code.Text;
                String issue = IssueDate.Text;
                String exp = ExpDate.Text;
                int loggedUser = (int)Session["user"];

                SqlCommand createpromo = new SqlCommand("AdminCreatePromocode", conn);

                createpromo.CommandType = System.Data.CommandType.StoredProcedure;

                if (code == "" || issue == "" || exp == "")
                {
                    Response.Write("Please make sure you've entered all data");
                }
                else
                {

                    createpromo.Parameters.Add(new SqlParameter("@code", code));
                    createpromo.Parameters.Add(new SqlParameter("@isuueDate", issue));
                    createpromo.Parameters.Add(new SqlParameter("@expiryDate", exp));
                    createpromo.Parameters.Add(new SqlParameter("@discount", discount));
                    createpromo.Parameters.Add(new SqlParameter("@adminId", loggedUser));

                    conn.Open();

                    createpromo.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("PromoCode added successfully<br />");
                }

            }
            catch
            {

                Response.Write("Invalid Input ");

            }


        }

    }
}