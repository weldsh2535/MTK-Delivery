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
        public JsonResult Get()
        {
            var dataContext = _context.restaurantStatuses;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(RestaurantStatus restaurant)
        {
            _context.Add(restaurant);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(RestaurantStatus restaurant)
        {
            _context.Update(restaurant);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            RestaurantStatus res = _context.restaurantStatuses.SingleOrDefault(X => X.id == id);
            _context.restaurantStatuses.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }

    }
}
