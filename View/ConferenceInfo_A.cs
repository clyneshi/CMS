using CMSLibrary.Global;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfo_A : Form
    {

        public ConferenceInfo_A(int type)
        {
            InitializeComponent();
            Init(type);
        }

        public void Init(int type)
        {
            switch (type)
            {
                case 1:
                    dataGridView1.DataSource = DataProcessor.GetConferencesUser();
                    break;
                case 2:
                    dataGridView1.DataSource = DataProcessor.GetUserRole();
                    break;
                case 3:
                    dataGridView1.DataSource = DataProcessor.GetPaperUser();
                    break;
                default:
                    break;
            }
        }
    }
}
