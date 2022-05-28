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
    public class MessageController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public MessageController(dataContext context , IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: Message
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Json(await _context.messages.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Message message)
        {
            _context.Add(message);
           await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Message message)
        {
            _context.Update(message);
           await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Message res = _context.messages.SingleOrDefault(X => X.id == id);
            _context.messages.Remove(res);
           await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
