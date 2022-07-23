using Core.Application.Repositories;

namespace Core.Application.Abstractions.Services.General
{
    public interface IMailService : ITransientService
    {
         Task SendAsync(MailRequest request);
    }
    public class MailRequest
    {

    }
}