using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAPICore.DTOs;
using WepAPICore.Models;

namespace WepAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        MyDbContext _db;

        public CartController(MyDbContext db)
        {
            _db = db;
        }

        [Route("GetToCartItem")]
        [HttpGet]
        public IActionResult Get()
        {
            var cartItem = _db.CartItems.Select(
                x => new cartItemResponseDTO
                {
                    CartItemId = x.CartItemId,
                    CartId = x.CartId,
                    Quantity = x.Quantity,
                    Product = new productDTO
                    {
                        ProductId = x.Product.ProductId,
                        ProductName = x.Product.ProductName,
                        Price = x.Product.Price,
                    }
                }



                );
            return Ok(cartItem);
        }

        [HttpPost]
        public IActionResult addCartItem([FromBody] addCartItemRequestDTO cart)
        {
            var data = new CartItem
            {
                CartId = cart.CartId,
                Quantity = cart.Quantity,
                ProductId = cart.ProductId,
            };
            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok();
        }
    }
}
