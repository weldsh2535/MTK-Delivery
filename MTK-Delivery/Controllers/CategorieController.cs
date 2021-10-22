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
        public JsonResult Get()
        {
            var dataContext = _context.categories;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(Category category)
        {
            _context.Add(category);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }
       
        [HttpPut]
        public JsonResult Put(Category category)
        {
            _context.Update(category);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category1 = _context.categories.SingleOrDefault(X => X.id == id);
            _context.categories.Remove(category1);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
        
    }
}
