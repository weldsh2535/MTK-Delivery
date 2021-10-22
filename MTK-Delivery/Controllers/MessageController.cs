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
    public class MessageController : Controller
    {
        private readonly dataContext _context;

        public MessageController(dataContext context)
        {
            _context = context;
        }

        // GET: Message
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.messages;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(Message message)
        {
            _context.Add(message);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Message message)
        {
            _context.Update(message);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Message res = _context.messages.SingleOrDefault(X => X.id == id);
            _context.messages.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
