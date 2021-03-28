using System.Threading.Tasks;

namespace Order.Email.Communication
{
    public interface IEmailSender
    {
        Task SendOrderConfirmationEmailAsync(Domain.Models.Order order);
    }
}