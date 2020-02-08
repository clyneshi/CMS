using CMS.Library.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Linq;

namespace CMS.Library.Global
{
    /// <summary>
    /// Handles all data fetching and saving functions
    /// </summary>
    public static partial class DataProcessor
    {
        public static void AddFeedback(Feedback feedback)
        {
            GlobalVariable.DbModel.Feedbacks.Add(feedback);
            GlobalVariable.DbModel.SaveChanges();
        }

        public static User AuthenticateUser(string email, string passWord)
        {
            //TODO: change behavior in accordince with user logic changes 
            // in the past, user - author, reviewer are tied to a single conference
            // after logic changes, author and reviewer can have register in multiple conferences

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passWord))
                return null;

            var user = GlobalVariable.DbModel.Users.FirstOrDefault(x => x.userEmail == email && x.userPasswrd == passWord);

            if (user == null)
                return null;

            ConferenceMember conferenceMembers;
            if (user.roleId == (int)RoleTypes.Author || user.roleId == (int)RoleTypes.Reviewer)
            {
                conferenceMembers = GlobalVariable.DbModel.ConferenceMembers.FirstOrDefault(x => x.userId == user.userId);
                GlobalVariable.UserConference = conferenceMembers?.confId ?? 0;
            }
            GlobalVariable.CurrentUser = user;

            return user;
        }

        public static void ClearControls(Control.ControlCollection C)
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

        public static void SendEmail(string toAddr, string mes)
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
