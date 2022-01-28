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
    public class CartController : Controller
    {
        private readonly dataContext _context;
        private readonly IConfiguration _configuration;
        public CartController(dataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: cart
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.carts.OrderByDescending(x => x.createdAt).ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Cart cart)
        {
            _context.Add(cart);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Put(Cart cart)
        {
            _context.Update(cart);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.carts.FindAsync(id);
            Cart cart = _context.carts.SingleOrDefault(X => X.id == id);
            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        } 
  }
}
