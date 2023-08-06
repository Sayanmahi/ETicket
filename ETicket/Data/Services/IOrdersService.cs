using ETicket.Models;

namespace ETicket.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserId(string userId,string userRole);
    }
}
