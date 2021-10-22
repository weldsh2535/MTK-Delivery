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
    public class FoodContentController : Controller
    {
        private readonly dataContext _context;

        public FoodContentController(dataContext context)
        {
            _context = context;
        }

        // GET: FoodContent
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.foodContents;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(FoodContent foodContent)
        {
            _context.Add(foodContent);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(FoodContent foodContent)
        {
            _context.Update(foodContent);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            FoodContent res = _context.foodContents.SingleOrDefault(X => X.id == id);
            _context.foodContents.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
