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
    public class DriverHistorieController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public DriverHistorieController(dataContext context , IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: DriverHistorie
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.driverHistories.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(DriverHistory driverHistory)
        {
            _context.Add(driverHistory);
          await  _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(DriverHistory driver)
        {
            _context.Update(driver);
         await   _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DriverHistory res = _context.driverHistories.SingleOrDefault(X => X.id == id);
            _context.driverHistories.Remove(res);
          await  _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
