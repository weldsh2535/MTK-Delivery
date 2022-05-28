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
    public class UserRoleController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public UserRoleController(dataContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: UserRole
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.userRoles.ToArrayAsync());
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
           return  Json(await _context.userRoles.FindAsync(userId));
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserRole user)
        {
            _context.Add(user);
           await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserRole user)
        {
            _context.Update(user);
           await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            UserRole res = _context.userRoles.SingleOrDefault(X => X.id == id);
            _context.userRoles.Remove(res);
           await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
