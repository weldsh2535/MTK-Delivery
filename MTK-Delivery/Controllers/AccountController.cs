using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MTK_Delivery.Models;
using Newtonsoft.Json;

namespace MTK_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly dataContext _context;
        private readonly IConfiguration _configuration;
        public AccountController(dataContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Account
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.accounts.ToArrayAsync());
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
