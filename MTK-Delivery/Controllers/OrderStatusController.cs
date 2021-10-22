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
    public class OrderStatusController : Controller
    {
        private readonly dataContext _context;

        public OrderStatusController(dataContext contcext)
        {
            _context = contcext;
        }

        // GET: OrderStatus
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.orderStatuses;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(OrderStatus orderStatus)
        {
            _context.Add(orderStatus);
            _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            OrderStatus res = _context.orderStatuses.SingleOrDefault(X => X.id == id);
            _context.orderStatuses.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
