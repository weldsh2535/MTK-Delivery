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
    public class DriverController : Controller
    {
        private readonly dataContext _context;

        public DriverController(dataContext context)
        {
            _context = context;
        }

        // GET: Driver
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.drivers;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(Driver driver)
        {
            _context.Add(driver);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Driver driver)
        {
            _context.Update(driver);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Driver driver = _context.drivers.SingleOrDefault(X => X.id == id);
            _context.drivers.Remove(driver);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
