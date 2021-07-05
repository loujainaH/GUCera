using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class addCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Yes(object sender, EventArgs e)
        {
            Response.Redirect("addCreditCard.aspx"); ;
        }
        protected void text1(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "YYYY/MM/DD")
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.Color.Black;


            }
        }
        protected void Home(object sender, EventArgs e)
        { Response.Redirect("studentHome.aspx"); }

        protected void add(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //int loggedUser = (int)Session["user"];
            // exdate.Text = "YYYY-MM-DD";
            // exdate.Attributes.Add("onFocus", "if(document.form1.exdate.value=='YYYY-MM-DD'){document.Form1.exdate.value='';}");
            exdate.Attributes.Add("OnClick", "this.value=");
            int loggedUser = (int)Session["user"];
            String num = number.Text;
            String name = chname.Text;
            var ex = exdate.Text;
            string cv = cvv.Text;
            if (num.Equals("") || name.Equals("") || ex.Equals("") || cv.Equals(""))
            {
                PlaceHolder2.Controls.Add(new Literal { Text = "<br/><hr/><br/>Make sure you add all data!<br/><hr/><br/>" });

            }
            else
            {

                SqlCommand addc = new SqlCommand("addCreditCard", conn);

                addc.CommandType = System.Data.CommandType.StoredProcedure;

                addc.Parameters.Add(new SqlParameter("@sid", loggedUser));
                addc.Parameters.Add(new SqlParameter("@number", num));
                addc.Parameters.Add(new SqlParameter("@cardHolderName", name));
                addc.Parameters.Add(new SqlParameter("@expiryDate", ex));
                addc.Parameters.Add(new SqlParameter("@cvv", cv));

                //Executing the SQLCommand
                conn.Open();
                try
                {
                    addc.ExecuteNonQuery();
                    firstOne.Style.Add("visibility", "hidden");
                    anotherOne.Style.Add("visibility", "visible");
                }
                catch (Exception)
                {
                    Response.Write("Invalid Input! ");
                }

                conn.Close();

            }
        }
    }
}