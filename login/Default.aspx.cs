using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace login
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                var obj = Session["login"];

                if(obj != null)
                {
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    Button1.Visible = false;
                }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //connection.Open();
            //string searchLoginQuery = "select from uzytkownicy where 'login' = @login";
            //SqlCommand cmd = new SqlCommand(searchLoginQuery, connection);
            //cmd.Parameters.AddWithValue("@login", TextBox1.Text);

            using (var dbContext = new Database1Entities())
            {
                var uzytkownik = dbContext.uzytkownicy.Where(x => x.login == TextBox1.Text).FirstOrDefault();
                if (uzytkownik != null)
                {
                    if(uzytkownik.haslo == TextBox2.Text)
                    {
                        Session["login"] = true;
                        Response.Redirect("Contact.aspx", false);
                        //Response.Write(Request.RawUrl.ToString());
                    } else
                    {
                        TextBox2.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('podano niewłaściwe hasło')", true);
                    }
                } else
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('nie ma takiego użytkownika')", true);
                }
            }

        }
    }
}