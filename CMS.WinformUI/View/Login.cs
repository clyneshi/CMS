using CMS.Library.App_Start;
using CMS.Library.Global;
using System;
using System.Windows.Forms;
using Unity;

namespace CMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var use = DataProcessor.AuthenticateUser(textBox_userName.Text, textBox_passwrd.Text);

            if (use != null)
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
            var reg = UnityConfig.UIContainer.Resolve<Register>();
            this.Hide();
            reg.Show();
        }
    }
}
