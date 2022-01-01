using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;

namespace MTK_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly dataContext _context;

        public OrderDetailController(dataContext context)
        {
            _context = context;
        }

        // GET: OrderDetail
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             return  Json(await _context.orderDetails.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderDetail account)
        {
            _context.Add(account);
           await _context.SaveChangesAsync();
            // ViewData["LocationId"] = new SelectList(_context.locations, "id", "id", account.LocationId);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Put(OrderDetail account)
        {
            _context.Update(account);
           await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.orderDetails.FindAsync(id);
            OrderDetail account1 = _context.orderDetails.SingleOrDefault(X => X.id == id);
            _context.orderDetails.Remove(account1);
           await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
       
    }
}
