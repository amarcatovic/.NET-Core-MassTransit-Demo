using System.Threading.Tasks;

namespace Order.API.Services
{
    public interface IOrderService
    {
        Task SendMessageAsync(Domain.Models.Order order);
    }
}
