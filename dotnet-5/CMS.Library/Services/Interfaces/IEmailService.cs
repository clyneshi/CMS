using System.Threading.Tasks;

namespace CMS.BL.Services.Interfaces;
public interface IEmailService
{
    Task SendEmailAsync(string toAddr, string mes);
}