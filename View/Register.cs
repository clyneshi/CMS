using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Model;

using System.Data.Entity.Validation;
using System.Diagnostics;

namespace CMS
{
    public partial class Register : Form
    {
        Model.CMSDBEntities cms = new CMSDBEntities();
        Module.CMSsystem cmsm = new Module.CMSsystem();

        public Register()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            var conf = from c in cms.Conferences
                       select c;
            comboBox_conf.DataSource = conf.ToList();
            comboBox_conf.DisplayMember = "confTitle";
            comboBox_conf.ValueMember = "confId";
            comboBox_conf.SelectedIndex = -1;

            var role = from r in cms.Roles
                       where r.roleType != "Admin"
                       select r;
            comboBox_role.DataSource = role.ToList();
            comboBox_role.DisplayMember = "roleType";
            comboBox_role.ValueMember = "roleId";
            comboBox_role.SelectedIndex = -1;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void comboBox_role_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)comboBox_role.SelectedValue == 2)
            {
                comboBox_conf.Enabled = false;
            }
            else
                comboBox_conf.Enabled = true;
        }

        private bool addRequest()
        {
            try
            {
                RegisterRequest request = new RegisterRequest();
                if (comboBox_conf.Enabled == true)
                    request.confId = (int)comboBox_conf.SelectedValue;
                request.name = textBox_name.Text.Trim();
                request.password = textBox_password.Text;
                request.email = textBox_email.Text;
                request.contact = textBox_cont.Text;
                request.status = "Waiting for approval";
                request.roleId = (int)comboBox_role.SelectedValue;
                cms.RegisterRequests.Add(request);
                cms.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return false;
            }
        }

        private string userRegValidation()
        {
            string error = "";
            if (textBox_name.Text.Trim().Equals(""))
                return error = "User Name cannot be empty";
            if (textBox_password.Text.Trim().Equals(""))
                return error = "User Password cannot be empty";
            if (textBox_email.Text.Trim().Equals(""))
                return error = "User Email cannot be empty";
            if (comboBox_role.SelectedValue == null)
                return error = "User Role cannot be empty";
            if (((int)comboBox_role.SelectedValue == 3 || (int)comboBox_role.SelectedValue == 4) && comboBox_conf.SelectedValue == null)
                return error = "Conference cannot be empty";

            return error;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string error = userRegValidation();
            if (error.Equals("") && addRequest() == true)
            {
                MessageBox.Show("Submit Successful!");
                Login lg = new Login();
                lg.Show();
                this.Close();
            }
            else
                MessageBox.Show(error);
        }
    }
}
