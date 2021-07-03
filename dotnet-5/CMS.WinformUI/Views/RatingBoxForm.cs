using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class RatingBoxForm : Form
    {
        public static int Rating { get; private set; }
        
        private static RatingBoxForm _ratingBox;
        private static DialogResult _result = DialogResult.No;

        public RatingBoxForm()
        {
            InitializeComponent();
        }

        public new static DialogResult Show()
        {
            Rating = 0;
            _ratingBox = new RatingBoxForm();
            _result = DialogResult.No;
            _ratingBox.ShowDialog();
            return _result;
        }

        private int? PickRating()
        {
            foreach (var control in groupBox1.Controls)
            {
                var radioButton = control as RadioButton;
                if (radioButton != null && radioButton.Checked && int.TryParse(radioButton.Text, out var rating))
                    return rating;
            }
            return null;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            var rating = PickRating();
            if (rating == null)
            {
                MessageBox.Show("Must choose a rating");
                return;
            }
            Rating = rating.Value;
            _result = DialogResult.Yes;
            _ratingBox.Close();
        }
    }
}
