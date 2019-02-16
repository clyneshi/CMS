using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace CMS.Module
{
    class CMSsystem
    {
        public static int? user_role = 0;
        public static string user_name = "";
        public static int user_id = 0;
        public static int user_conf = 0;

        // cleaer controls 
        public void clearControls(Control.ControlCollection C)
        {
            foreach (Control c in C)
            {
                if (c.GetType().Name == "RichTextBox")
                    if (((RichTextBox)c).Visible == true)
                        ((RichTextBox)c).Clear();
                if (c.GetType().Name == "TextBox")
                    if (((TextBox)c).Visible == true)
                        ((TextBox)c).Clear();
                if (c.GetType().Name == "ListBox")
                    if (((ListBox)c).Visible == true)
                        ((ListBox)c).DataSource = null;
                if (c.GetType().Name == "ComboBox")
                    if (((ComboBox)c).Visible == true)
                        ((ComboBox)c).SelectedIndex = -1;
                if (c.GetType().Name == "DateTimePicker")
                    if (((DateTimePicker)c).Visible == true)
                        ((DateTimePicker)c).Value = DateTime.Today;
            }

        }

        // send email
        public void sendEmail(string toAddr, string mes)
        {
            string FromName = "Conference Management System";
            string FromEmail = "address@email";

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            //message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
            message.To.Add(new MailAddress(toAddr));  // replace with valid value 
                                                         //message.From = new MailAddress("sender@outlook.com");  // replace with valid value
            message.From = new MailAddress("address@email");  // replace with valid value
            message.Subject = "Your email subject";
            message.Body = string.Format(body, FromName, FromEmail, mes);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "address@email",  // replace with valid value
                    Password = "password"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.live.com";
                //smtp.Host = "smtp.monash.edu.au";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
