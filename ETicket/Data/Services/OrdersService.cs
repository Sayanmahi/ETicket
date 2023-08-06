using ETicket.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext db;
        public OrdersService(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<List<Order>> GetOrdersByUserId(string userId,string userRole)
        {
            var o =await db.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n=>n.User).ToListAsync();
            if(userRole !="Admin")
            {
                o=o.Where(n=>n.UserId==userId).ToList();
            }
            return o;
        }

        public async Task StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress

            };
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await db.OrderItems.AddAsync(orderItem);
            }
               await db.SaveChangesAsync();
            

        }
    }
}
