using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Net.Mail;

namespace login
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = Session["login"];

            if (obj != null)
            {
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button1.Visible = false;
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (var dbContext = new Database1Entities())
            {
                var uzytkownik = dbContext.uzytkownicy.Where(x => x.login == TextBox1.Text).FirstOrDefault();
                if (uzytkownik != null)
                {
                    if (uzytkownik.haslo == TextBox2.Text)
                    {
                        Session["login"] = true;
                        Response.Redirect("Contact.aspx", false);
                        //Response.Write(Request.RawUrl.ToString());
                    }
                    else
                    {
                        TextBox2.Text = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('podano niewłaściwe hasło')", true);
                    }
                }
                else
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('nie ma takiego użytkownika')", true);
                }
            }

        }

        protected void ButtonRegister_Click1(object sender, EventArgs e)
        {
            if (TextBoxRegisterLogin.Text=="" ||TextBoxRegisterPassword.Text == "" || TextBoxRegisterPasswordConfirmation.Text == "" || TextBoxRegisterQuestion.Text == "" || TextBoxRegisterAnwser.Text == "") {
                string msg = "wypełnij wszystkie pola";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
                return;
            }


            if (TextBoxRegisterPassword.Text != TextBoxRegisterPasswordConfirmation.Text)
            {
                string msg = "Hasła nie zgadzają się";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
            } else
            {
                using (var dbContext = new Database1Entities())
                {
                    var uzytkownik = dbContext.uzytkownicy.Where(x => x.login == TextBoxRegisterLogin.Text).FirstOrDefault();
                    if (uzytkownik != null)
                    {
                        string msg = "podany użytkownik już istnieje w bazie";
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
                    } else
                    {
                        var newUser = new uzytkownicy();
                        newUser.login = TextBoxRegisterLogin.Text;
                        newUser.haslo = TextBoxRegisterPassword.Text;
                        newUser.pytanie = TextBoxRegisterQuestion.Text;
                        newUser.odpowiedz = TextBoxRegisterAnwser.Text;
                        newUser.Id = dbContext.uzytkownicy.Count() + 1;
                        dbContext.uzytkownicy.Add(newUser);
                        dbContext.SaveChanges();

                        string msg = "zarejestrowano użytkownika o loginie " + newUser.login + " pomyślnie";
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
                    }
                }

            }


        }

        protected void ButtonRecovery_Click1(object sender, EventArgs e)
        {
            using (var dbContext = new Database1Entities())
            {
                var uzytkownik = dbContext.uzytkownicy.Where(x => x.login == TextBoxRecoveryLogin.Text).FirstOrDefault();
                if (uzytkownik != null)
                {
                    if (uzytkownik.login == TextBoxRecoveryLogin.Text)
                    {
                        if (uzytkownik.odpowiedz == TextBoxRecoveryQuestion.Text)
                        {
                            string msg = "haslo dla " + uzytkownik.login + " wyslane na maila";
                            Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
                            //wysylanie hasla: nalezy wprowadzic wlasne dane do skrzynki gmail
                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                            mail.To.Add(uzytkownik.login); ;
                            mail.From = new MailAddress("*login gmail*", "Email head", System.Text.Encoding.UTF8);
                            mail.Subject = "Twoje hasło do lab06";
                            mail.SubjectEncoding = System.Text.Encoding.UTF8;
                            mail.Body = "Twoje hasło to: " + uzytkownik.haslo;
                            mail.BodyEncoding = System.Text.Encoding.UTF8;
                            mail.IsBodyHtml = true;
                            mail.Priority = MailPriority.High;
                            SmtpClient client = new SmtpClient();
                            client.Credentials = new System.Net.NetworkCredential("*login gmail*", "*haslo gmail*");
                            client.Port = 587;
                            client.Host = "smtp.gmail.com";
                            client.EnableSsl = true;
                            try
                            {
                                client.Send(mail);
                                string msgJS = "haslo dla " + uzytkownik.login + " wyslane na maila";
                                Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msgJS + "');</script>");
                            }
                            catch (Exception ex)
                            {
                                Exception ex2 = ex;
                                string errorMessage = string.Empty;
                                while (ex2 != null)
                                {
                                    errorMessage += ex2.ToString();
                                    ex2 = ex2.InnerException;
                                }
                                string msgJS = "haslo dla " + uzytkownik.login + " nie zostalo wyslane";
                                Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msgJS + "');</script>");
                            }


                        }
                        else
                        {
                            string msg = "zla odpowiedz na pytanie pomocnicze dla uzytkownika " + uzytkownik.login;
                            Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
                        }
                    }
                }
                else
                {
                    string msg = "nie ma takiego uzytkownika";
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "well1", "<script>alert('" + msg + "');</script>");
                }
            }
        }
    }
}