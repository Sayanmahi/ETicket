﻿using ETicket.Migrations;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext db { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext _db)
        {
            db = _db;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context=services.GetService<AppDbContext>();    
            string cartId=session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId=cartId};
        }
        public void AddItemCart(Movie movie)
        {
            var ss=db.ShoppingCartItems.FirstOrDefault(n=>n.Movie.Id==movie.Id && n.ShoppingCartId==ShoppingCartId);
            if (ss==null) 
            {
                ss = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                db.ShoppingCartItems.Add(ss);
                
            }
            else
            {
                ss.Amount = ss.Amount + 1;
            }   
            db.SaveChanges();

        }
        public void RemoveItemFromCart(Movie movie) 
        {
            var ss = db.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (ss != null)
            {
                if(ss.Amount > 1)
                {
                    ss.Amount = ss.Amount - 1;
                }
                else
                {
                    db.ShoppingCartItems.Remove(ss);
                }
            }
            db.SaveChanges();

        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n =>n.Movie).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total=db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n =>n.Movie.Price *n.Amount).Sum();
            return total;
        }
        public async Task ClearShoppingCart()
        {
            var items =await db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            db.ShoppingCartItems.RemoveRange(items);
            await db.SaveChangesAsync();
        }
    }
}
