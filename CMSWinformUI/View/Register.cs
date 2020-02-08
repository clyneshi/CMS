using CMSLibrary.Global;
using CMSLibrary.Model;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            comboBox_conf.DataSource = DataProcessor.GetConferences();
            comboBox_conf.DisplayMember = "confTitle";
            comboBox_conf.ValueMember = "confId";
            comboBox_conf.SelectedIndex = -1;

            comboBox_role.DataSource = DataProcessor.GetRoles();
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

        private bool AddRequest()
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

            return DataProcessor.AddRegisterRequest(request);

        }

        // TODO: extract validation method
        private string UserRegValidation()
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
            string error = UserRegValidation();
            if (error.Equals("") && AddRequest() == true)
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
