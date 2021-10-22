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
        public JsonResult Get()
        {
            var dataContext = _context.statuses;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(Status status)
        {
            _context.Add(status);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Status status)
        {
            _context.Update(status);
            _context.SaveChangesAsync();
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
