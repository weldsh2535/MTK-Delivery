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
    public class VehicleController : Controller
    {
        private readonly dataContext _context;

        public VehicleController(dataContext context)
        {
            _context = context;
        }

        // GET: Vehicle
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.vehicles.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vehicle vehicle)
        {
            if (vehicle.id == 0)
            {
                _context.Add(vehicle);
            await    _context.SaveChangesAsync();
            }
            _context.Add(vehicle);
           await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vehicle vehicle)
        {
            _context.Update(vehicle);
          await  _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Vehicle vehicle = _context.vehicles.SingleOrDefault(X => X.id == id);
            _context.vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
