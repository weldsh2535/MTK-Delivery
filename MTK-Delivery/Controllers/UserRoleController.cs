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
    public class UserRoleController : Controller
    {
        private readonly dataContext _context;

        public UserRoleController(dataContext context)
        {
            _context = context;
        }

        // GET: UserRole
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.userRoles;
            return new JsonResult(dataContext);
        }
        [HttpGet("{userId}")]
        public JsonResult Get(string userId)
        {
            var res = _context.userRoles.FindAsync(userId);
           return new JsonResult(res);
        }
        [HttpPost]
        public JsonResult Post(UserRole user)
        {
            _context.Add(user);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(UserRole user)
        {
            _context.Update(user);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            UserRole res = _context.userRoles.SingleOrDefault(X => X.id == id);
            _context.userRoles.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
