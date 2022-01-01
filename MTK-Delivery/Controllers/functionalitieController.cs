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
    public class functionalitieController : Controller
    {
        private readonly dataContext _context;

        public functionalitieController(dataContext context)
        {
            _context = context;
        }

        // GET: functionalitie
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.functionalities.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(functionality fun)
        {
            _context.Add(fun);
          await  _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(functionality fun)
        {
            _context.Update(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            functionality res = _context.functionalities.SingleOrDefault(X => X.id == id);
            _context.functionalities.Remove(res);
           await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
