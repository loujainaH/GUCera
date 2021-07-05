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
    public partial class AdminIssuePromoCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("AdminHome.aspx"); }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                int id = Int16.Parse(ID.Text);
                String code = Code.Text;

                SqlCommand Issueproc = new SqlCommand("AdminIssuePromoCodeToStudent", conn);

                Issueproc.CommandType = System.Data.CommandType.StoredProcedure;

                Issueproc.Parameters.Add(new SqlParameter("@sid", id));
                Issueproc.Parameters.Add(new SqlParameter("@pid", code));
                conn.Open();
                Issueproc.ExecuteNonQuery();
                conn.Close();
                Response.Write("Promocode issued successfully!<br />");
            }
            catch
            {
                Response.Write("Invalid input");
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}