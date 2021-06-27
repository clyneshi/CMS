using System;
using System.Windows.Forms;

namespace CMS.WinformUI.Utils
{
    public static class ControlExtensions
    {
        public static void Clear(Control.ControlCollection C)
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
    }
}
