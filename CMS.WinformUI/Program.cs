using CMS.Library.App_Start;
using System;
using System.Windows.Forms;
using Unity;

namespace CMS.WinformUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UnityConfig.TypeRegister();
            Application.Run(new Login());
        }
    }
}
