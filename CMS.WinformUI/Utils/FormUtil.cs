using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CMS.WinformUI.Utils
{
    public interface IFormUtil
    {
        TForm GetForm<TForm>() where TForm : Form;
    }

    public class FormUtil: IFormUtil
    {
        private readonly IServiceProvider _serviceProvider;

        public FormUtil(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TForm GetForm<TForm>() where TForm : Form
        {
            return _serviceProvider.GetRequiredService<TForm>();
        }
    }
}
