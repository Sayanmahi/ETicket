using ETicket.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Data.ViewComponents
{
    
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartSummary(ShoppingCart _shoppingCart)
        {
            shoppingCart = _shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var item = shoppingCart.GetShoppingCartItems();
            return View(item.Count);
        }
    }
}
