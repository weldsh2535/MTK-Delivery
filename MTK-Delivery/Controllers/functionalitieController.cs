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
        public JsonResult Get()
        {
            var dataContext = _context.functionalities;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(functionality fun)
        {
            _context.Add(fun);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(functionality fun)
        {
            _context.Update(fun);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            functionality res = _context.functionalities.SingleOrDefault(X => X.id == id);
            _context.functionalities.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
