using ETicket.Data.Cart;
using ETicket.Data.Services;
using ETicket.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService movieService;
        private readonly ShoppingCart shoppingCart;
        public OrdersController(IMovieService _movieService,ShoppingCart _shoppingCart) 
        {
            movieService = _movieService;
            shoppingCart = _shoppingCart;
        }
        public IActionResult Index()
        {
            var it=shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems=it;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<RedirectToActionResult> AddToShoppingCart(int  id) 
        {
            var i =await movieService.GetMovieById(id);     
            if(i!=null)
            {
                shoppingCart.AddItemCart(i);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
