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
    public class CategorieController : Controller
    {
        private readonly dataContext _context;

        public CategorieController(dataContext context)
        {
            _context = context;
        }

        // GET: Categorie
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.categories.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            _context.Add(category);
           await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }
       
        [HttpPut]
        public async Task<IActionResult> Put(Category category)
        {
            _context.Update(category);
           await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Category category1 = _context.categories.SingleOrDefault(X => X.id == id);
            _context.categories.Remove(category1);
          await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
        
    }
}
