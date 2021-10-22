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
        public JsonResult Get()
        {
            var dataContext = _context.accounts;
            //foreach(var item in dataContext)
            //{
            //   var owner= item._Owner;
            //    return new JsonResult(owner);
            //}
            //var result = JsonConvert.SerializeObject(dataContext);
            //var status = _context.statuses; 
            //var test = JsonConvert.DeserializeObject<List<Account>>(result);
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(Account account)
        {
            _context.Add(account);
            _context.SaveChangesAsync();
           // ViewData["LocationId"] = new SelectList(_context.locations, "id", "id", account.LocationId);
         return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public  JsonResult Put(Account account)
        {
            _context.Update(account);
             _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var acc = _context.accounts.FindAsync(id);
            Account account1 = _context.accounts.SingleOrDefault(X=>X.id==id);
                _context.accounts.Remove(account1);
                _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
       
     }
}
