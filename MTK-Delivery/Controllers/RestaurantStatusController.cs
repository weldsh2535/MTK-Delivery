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
    public class RestaurantStatusController : Controller
    {
        private readonly dataContext _context;

        public RestaurantStatusController(dataContext context)
        {
            _context = context;
        }

        // GET: RestaurantStatus
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.restaurantStatuses.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(RestaurantStatus restaurant)
        {
            _context.Add(restaurant);
          await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(RestaurantStatus restaurant)
        {
            _context.Update(restaurant);
           await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            RestaurantStatus res = _context.restaurantStatuses.SingleOrDefault(X => X.id == id);
            _context.restaurantStatuses.Remove(res);
           await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }

    }
}
