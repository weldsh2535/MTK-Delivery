using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MTK_Delivery.Models;
using Newtonsoft.Json;

namespace MTK_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : Controller
    {
        private readonly dataContext _context;
        private readonly IConfiguration _configuration;
        public CartItemController(dataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: cart_Items
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.cart_Items.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Cart_Item cart)
        {
            _context.Add(cart);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Put(Cart_Item cart)
        {
            _context.Update(cart);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.carts.FindAsync(id);
            Cart_Item cart = _context.cart_Items.SingleOrDefault(X => X.id == id);
            _context.cart_Items.Remove(cart);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
