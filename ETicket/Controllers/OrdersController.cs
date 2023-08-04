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
        private readonly IOrdersService ordersService;
        public OrdersController(IMovieService _movieService,ShoppingCart _shoppingCart, IOrdersService _ordersService) 
        {
            movieService = _movieService;
            shoppingCart = _shoppingCart;
            ordersService = _ordersService;
        }
        public async Task<IActionResult> GetWhatOrdered()
        {
            string userId = "1";
            var orders =await ordersService.GetOrdersByUserId(userId);
            return View(orders);
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
        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var i = await movieService.GetMovieById(id);
            if (i != null)
            {
                shoppingCart.RemoveItemFromCart(i);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = shoppingCart.GetShoppingCartItems();
            string userId = "1";
            string userEmailAddress = "sayanmukherjee37@gmail.com";
            await ordersService.StoreOrder(items, userId, userEmailAddress);
            await shoppingCart.ClearShoppingCart();
            return View("OrderCompleted");
        }
    }
}
                   