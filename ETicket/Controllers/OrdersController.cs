using ETicket.Data.Cart;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ETicket.Controllers
{
    [Authorize]
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders =await ordersService.GetOrdersByUserId(userId,userRole);
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await ordersService.StoreOrder(items, userId, userEmailAddress);
            await shoppingCart.ClearShoppingCart();
            return View("OrderCompleted");
        }
    }
}
                   