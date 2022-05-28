using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;

namespace MTK_Delivery.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public OrderStatusController(dataContext context,IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: OrderStatus
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.orderStatuses.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderStatus orderStatus)
        {
            _context.Add(orderStatus);
           await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OrderStatus res = _context.orderStatuses.SingleOrDefault(X => X.id == id);
            _context.orderStatuses.Remove(res);
           await  _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
