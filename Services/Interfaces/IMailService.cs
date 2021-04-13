using System.Threading.Tasks;

namespace functions.Services.Interfaces
{
    public interface IMailService
    {
        Task SendInvitation(string emailAddress);
    }
}