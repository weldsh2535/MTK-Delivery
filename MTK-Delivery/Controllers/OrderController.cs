using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public OrderController(dataContext context , IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }
        //GET:order
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.orders.Include(o => o.orderStatuses).Include(o => o.restaurantStatuses).Include(o => o.statuses).OrderByDescending(c => c.id).ToArrayAsync());
        }
        //[HttpGet("{date}")]
        //public JsonResult Get(DateTime date)
        //{
        //    Order order = _context.orders.SingleOrDefault(X => X.DateTime == date);
        //    return new JsonResult(order);
        //}
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Order order = _context.orders.SingleOrDefault(X => X.id == id);
           return new JsonResult(order);
        }
        [HttpGet("{driverId}")]
        public JsonResult getOrderByDriverId(string driverId)
        {
            Order order = _context.orders.SingleOrDefault(x => x.Driver == driverId);
            return new JsonResult(order);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            //ViewData["orderStatuses"] = new SelectList(_context.orderStatuses, "id", "val");
            //ViewData["restaurantStatuses"] = new SelectList(_context.restaurantStatuses, "id", "val");
            //ViewData["statuses"] = new SelectList(_context.statuses, "id", "val");
            _context.Add(order);
           await _context.SaveChangesAsync();
            Order order1 = new Order();
            int id = order1.id;
            return new JsonResult(id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            try
            {
                _context.Update(order);
               await _context.SaveChangesAsync();
                return new JsonResult("Updated Successfully");
            }
            catch
            {
                throw new Exception("An error has occured in this method");
            }
           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.orders.FindAsync(id);
            Order order = _context.orders.SingleOrDefault(X => X.id == id);
            _context.orders.Remove(order);
            await  _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
      }
}
