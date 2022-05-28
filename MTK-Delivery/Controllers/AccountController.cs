using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MTK_Delivery.Models;
using Newtonsoft.Json;

namespace MTK_Delivery.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AccountController(dataContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: Account
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.accounts.ToArrayAsync());
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Account users)
        {
            var token = jwtAuthenticationManager.Authenticate(users.phonenumber, users.password);
            if (token == null)
                return Unauthorized();
            return Json(token);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Account account)
        {
            _context.Add(account);
         await _context.SaveChangesAsync();
          return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Put(Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.accounts.FindAsync(id);
            Account account1 = _context.accounts.SingleOrDefault(X=>X.id==id);
                _context.accounts.Remove(account1);
             await   _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
       
     }
}
