using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class RatingBox : Form
    {
        static RatingBox RtBox;
        static DialogResult result = DialogResult.No;
        static public int rating = 0;

        public RatingBox()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            rating = 0;
            RtBox = new RatingBox();
            result = DialogResult.No;
            RtBox.ShowDialog();
            return result;
        }

        private int ratePick()
        {
            int find = 0;
            foreach (Control c in groupBox1.Controls)
            {
                RadioButton rb = c as RadioButton;
                if (rb != null && rb.Checked)
                    find = Convert.ToInt32(rb.Text);
            }
            return find;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rating = ratePick();
            result = DialogResult.Yes;
            RtBox.Close();
        }
    }
}
