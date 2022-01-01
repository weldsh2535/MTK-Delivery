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
    public class StatusController : Controller
    {
        private readonly dataContext _context;

        public StatusController(dataContext context)
        {
            _context = context;
        }

        // GET: Status
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.statuses.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Status status)
        {
            _context.Add(status);
           await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Status status)
        {
            _context.Update(status);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Status res = _context.statuses.SingleOrDefault(X => X.id == id);
            _context.statuses.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
