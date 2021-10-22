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
    public class RestaurantController : Controller
    {
        private readonly dataContext _context;

        public RestaurantController(dataContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.restaurants;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(Restaurant restaurant)
        {
            _context.Add(restaurant);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Restaurant restaurant)
        {
            _context.Update(restaurant);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Restaurant res = _context.restaurants.SingleOrDefault(X => X.id == id);
            _context.restaurants.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
