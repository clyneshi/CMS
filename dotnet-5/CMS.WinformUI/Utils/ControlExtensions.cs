using System;
using System.Windows.Forms;

namespace CMS.WinformUI.Utils;

public static class ControlExtensions
{
    public static void ClearData(this Control.ControlCollection controls)
    {
        foreach (var control in controls)
        {
            if (control.GetType().Name == "RichTextBox")
                if (((RichTextBox)control).Visible == true)
                    ((RichTextBox)control).Clear();
            if (control.GetType().Name == "TextBox")
                if (((TextBox)control).Visible == true)
                    ((TextBox)control).Clear();
            if (control.GetType().Name == "ListBox")
                if (((ListBox)control).Visible == true)
                    ((ListBox)control).DataSource = null;
            if (control.GetType().Name == "ComboBox")
                if (((ComboBox)control).Visible == true)
                    ((ComboBox)control).SelectedIndex = -1;
            if (control.GetType().Name == "DateTimePicker")
                if (((DateTimePicker)control).Visible == true)
                    ((DateTimePicker)control).Value = DateTime.Today;
        }
    }
}
