using CMSLibrary.Global;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            RoleDisplay();
            ConfDisplay();
        }

        private void RoleDisplay()
        {
            comboBox_role.DataSource = DataProcessor.GetRoles();
            comboBox_role.DisplayMember = "roleType";
            comboBox_role.ValueMember = "roleId";
        }

        private void ConfDisplay()
        {
            comboBox_conf.DataSource = DataProcessor.GetConferences();
            comboBox_conf.DisplayMember = "confTitle";
            comboBox_conf.ValueMember = "confId";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // validate if user exists
            bool isUser = DataProcessor.ValidateUser(
                textBox_userName.Text,
                textBox_passwrd.Text,
                (int)comboBox_role.SelectedValue,
                (int)comboBox_conf.SelectedValue
            );

            if (isUser)
            {
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Incorrect user info!");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.Show();
        }

        private void comboBox_role_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)comboBox_role.SelectedValue > 2)
                comboBox_conf.Enabled = true;
            else
                comboBox_conf.Enabled = false;
        }
    }
}
