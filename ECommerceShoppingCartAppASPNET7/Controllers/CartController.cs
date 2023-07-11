using ECommerceShoppingCartAppASPNET7.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerceShoppingCartAppASPNET7.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace ECommerceShoppingCartAppASPNET7.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CartController(CartService cartService, ProductContext context, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {

            //_cartService.ClearCart(); 
            var cart = _cartService.GetCart();

            return View(cart);
        }



        public async Task<IActionResult> Buy(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _cartService.AddItem(product, 1);
            }

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Add(string productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                _cartService.AddItem(product, quantity);
                return Ok();
            }

            return BadRequest();
        }

        
        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cart = _cartService.GetCart();

                // Check if the product already exists in the cart
                var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == model.ProductId);
                if (existingItem != null)
                {
                    // Update the quantity of the existing item
                    existingItem.Quantity = model.Quantity;
                    _cartService.UpdateCart(cart);

                    // Return a JSON response with the updated flag
                    return Json(new { updated = true });
                }

                // The product is not in the cart, add it
                _cartService.AddToCart(model.ProductId, model.Quantity);
                _cartService.UpdateCart(cart);

                // Return a JSON response with the updated flag set to false
                return Json(new { updated = false });
            }

            // Model validation failed, return a BadRequest response
            return BadRequest();
        }



        public IActionResult Remove(string productId)
        {
            _cartService.RemoveItem(productId);
            return RedirectToAction("Index");
        }
    }





        //public IActionResult Clear()
        //{
        //    _cartService.ClearCart();
        //    return RedirectToAction("Index", "Cart");
        //}
    }


