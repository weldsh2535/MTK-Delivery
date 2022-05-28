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
    public class FoodController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public FoodController(dataContext context , IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: Food
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.foods.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Food food)
        {
            _context.Add(food);
           await  _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Food food)
        {
            _context.Update(food);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Food food = _context.foods.SingleOrDefault(X => X.id == id);
            _context.foods.Remove(food);
           await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
