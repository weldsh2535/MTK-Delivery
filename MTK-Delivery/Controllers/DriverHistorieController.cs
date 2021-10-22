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
    public class DriverHistorieController : Controller
    {
        private readonly dataContext _context;

        public DriverHistorieController(dataContext context)
        {
            _context = context;
        }

        // GET: DriverHistorie
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.driverHistories;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(DriverHistory driverHistory)
        {
            _context.Add(driverHistory);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(DriverHistory driver)
        {
            _context.Update(driver);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            DriverHistory res = _context.driverHistories.SingleOrDefault(X => X.id == id);
            _context.driverHistories.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
