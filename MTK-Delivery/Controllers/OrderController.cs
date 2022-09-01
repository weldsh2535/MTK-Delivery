using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public OrderController(dataContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }
        //GET:order
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.orders.Include(o => o.orderStatuses).Include(o => o.restaurantStatuses).Include(o => o.statuses).OrderByDescending(c => c.id).ToArrayAsync());
        }
        [HttpGet("getDate/{date}")]
        public JsonResult getDateOrder(DateTime date)
        {
            var order = _context.orders.Where(x => x.DateTime == date);
            return new JsonResult(order);
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Order order = _context.orders.SingleOrDefault(X => X.id == id);
            return new JsonResult(order);
        }
        [HttpGet("ByDriverId/{driverId}")]
        public JsonResult getOrderByDriverId(string driverId)
        {
            var order = _context.orders.Where(x => x.Driver == driverId);
            return new JsonResult(order);
        }
        //restaurant home filter by userId with restaurantId
        [HttpGet("latestOrders/{UserId}")]
        public JsonResult getOrderByUserId(string UserId)
        {
            var order = _context.orders.FromSqlRaw($"select DISTINCT dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders" +
                $" left join  dbo.restaurantStatuses ON dbo.restaurantStatuses.Orderid = dbo.orders.id " +
                $"left join  dbo.statuses on dbo.statuses.Orderid = dbo.orders.id " +
                $"where dbo.restaurantStatuses.isChecked = 0 and dbo.restaurantStatuses.val = 'ready to service' and dbo.orders.RestaurantId = {UserId} and dbo.statuses.isChecked = 0 and dbo.statuses.val = 'Reject'  ORDER BY DateTime");
            var model = (from r in _context.orders
                         orderby r.DateTime
                         where r.RestaurantId == UserId
                         select r);
            return new JsonResult(order);
        }
        //restaurant home filter by orderStatus
        [HttpGet("orderStatus")]
        public JsonResult getOrderRestaurantStatuses()
        {
            var orderStatus = _context.orders.FromSqlRaw("select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders " +
                $" left join  dbo.restaurantStatuses ON dbo.restaurantStatuses.Orderid = orders.id" +
                $" where dbo.restaurantStatuses.isChecked = 1 and dbo.restaurantStatuses.val = 'start cooking' or dbo.restaurantStatuses.val = 'cooked' or dbo.restaurantStatuses.val = 'ready to service'  ORDER BY DateTime");
            return new JsonResult(orderStatus);
        }
        //restaurant home filter by statuses
        [HttpGet("statuses")]
        public JsonResult getOrderStatuses()
        {
            var orderStatuses = _context.orders.FromSqlRaw("select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders " +
                $" left join  dbo.statuses ON dbo.statuses.Orderid = orders.id" +
                $" where dbo.statuses.isChecked = 1 and dbo.statuses.val = 'Accept'  ORDER BY DateTime");
            return new JsonResult(orderStatuses);
        }
        //Restaurant History filter By restaurantId 
        [HttpGet("historyOrder/{restaurantId}")]
        public JsonResult getOrderHistory(string restaurantId)
        {
            var orderHistory = _context.orders.FromSqlRaw("select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders " +
                                                          $" left join  dbo.restaurantStatuses ON dbo.restaurantStatuses.Orderid = dbo.orders.id" +
                                                         $" where dbo.restaurantStatuses.isChecked = 0 and dbo.restaurantStatuses.val = 'ready to service' and dbo.orders.RestaurantId = {restaurantId}  ORDER BY DateTime");
            return new JsonResult(orderHistory);
        }
        //Driver Home filter by DriverId
        [HttpGet("driverHome/{driverID}")]
        public JsonResult getOrderDriverId(string driverID)
        {
            var orders = _context.orders.FromSqlRaw("select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders" +
                $" left join  dbo.orderStatuses ON dbo.orderStatuses.Orderid = dbo.orders.id" +
                $" left join  dbo.statuses on dbo.statuses.Orderid = dbo.orders.id" +
                $" where dbo.orderStatuses.isChecked = 0 and dbo.orderStatuses.val = 'delivered'" +
                $" and dbo.orders.Driver = {driverID} and dbo.statuses.isChecked = 0 and dbo.statuses.val = 'Reject'  ORDER BY DateTime");
            return new JsonResult(orders);
        }
        //Driver Home filter By orderStatus and Statuses
        [HttpGet("driverHomeStatuses")]
        public JsonResult getOrderStatusAndOrderStatuses()
        {
            var orderStatus = _context.orders.FromSqlRaw(" select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders " +
                $" left join  dbo.orderStatuses ON dbo.orderStatuses.Orderid = dbo.orders.id" +
                $" left join  dbo.statuses on dbo.statuses.Orderid = dbo.orders.id" +
                $" where dbo.orderStatuses.isChecked = 0 and dbo.orderStatuses.val = 'picked'" +
                $" and dbo.orderStatuses.isChecked = 0 and dbo.orderStatuses.val = 'delivered'" +
                $"  and dbo.orderStatuses.isChecked = 0 and dbo.orderStatuses.val = 'start moving'" +
                $"  and dbo.statuses.isChecked = 0 and dbo.statuses.val = 'Reject'  ORDER BY DateTime");
            return new JsonResult(orderStatus);
        }
        //Customer Order getAllOrder by filter customerId AND customerStatus
        [HttpGet("allOrders/{customerId}")]
        public JsonResult getAllOrderByCustomerId(string customerId)
        {
            var allOrders = (from r in _context.orders
                             orderby r.DateTime
                             where r.Customer == customerId && r.customerStatus == "true"
                             select r);
            return new JsonResult(allOrders);
        }
        //Customer Order getProcessingOrder by filter customerId,orderStatus and customerStatus
        [HttpGet("prcoessingOrders/{customerID}")]
        public JsonResult getAllProcessingOrders(string customerID)
        {
            var processingOrder = _context.orders.FromSqlRaw(" select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders " +
                $" left join  dbo.orderStatuses ON dbo.orderStatuses.Orderid = dbo.orders.id" +
                $" where  dbo.orders.Customer = {customerID} and dbo.orders.customerStatus = 'true'" +
                $" and dbo.orderStatuses.isChecked = 0 and dbo.orderStatuses.val = 'delivered'  ORDER BY DateTime");
            return new JsonResult(processingOrder);
        }
        //Customer Order GetAllCompleted order By filter customerID , orderStatus and customerStatus
        [HttpGet("AllCompleteOrders/{customerID}")]
        public JsonResult getAllCompletedOrders(string customerID)
        {
            var completedOrders = _context.orders.FromSqlRaw(" select DISTINCT  dbo.orders.id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,location,orderLocation,customerStatus from dbo.orders " +
                $" left join  dbo.orderStatuses ON dbo.orderStatuses.Orderid = dbo.orders.id" +
                $" where  dbo.orders.Customer = {customerID} and dbo.orders.customerStatus = 'true'" +
                $" and dbo.orderStatuses.isChecked = 1 and dbo.orderStatuses.val = 'delivered'  ORDER BY DateTime");
            return new JsonResult(completedOrders);
        }
        //Customer order GetAllCancelled order 
        [HttpGet("cancelledOrders/{customerId}")]
        public JsonResult getAllCancelledOrder(string customerID)
        {
            var allCancelledOrders = (from r in _context.orders
                             orderby r.DateTime
                             where r.Customer == customerID && r.customerStatus == "false"
                             select r);
            return new JsonResult(allCancelledOrders);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            Order order1 = new Order();
            int id = order1.id;
            return new JsonResult(id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return new JsonResult("Updated Successfully");
            }
            catch
            {
                throw new Exception("An error has occured in this method");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.orders.FindAsync(id);
            Order order = _context.orders.SingleOrDefault(X => X.id == id);
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
