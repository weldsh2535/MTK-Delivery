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
    public class OrderController : Controller
    {
        private readonly dataContext _context;

        public OrderController(dataContext context)
        {
            _context = context;
        }
        //GET:order
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.orders.Include(o => o.orderStatuses).Include(o => o.restaurantStatuses).Include(o => o.statuses).OrderByDescending(c=>c.id);
            return new JsonResult(dataContext);
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Order order = _context.orders.SingleOrDefault(X => X.id == id);
           return new JsonResult(order);
        }
        [HttpGet("{driverId}")]
        public JsonResult getOrderByDriverId(string driverId)
        {
            Order order = _context.orders.SingleOrDefault(x => x.Driver == driverId);
            return new JsonResult(order);
        }
        [HttpPost]
        public JsonResult Post(Order order)
        {
            //ViewData["orderStatuses"] = new SelectList(_context.orderStatuses, "id", "val");
            //ViewData["restaurantStatuses"] = new SelectList(_context.restaurantStatuses, "id", "val");
            //ViewData["statuses"] = new SelectList(_context.statuses, "id", "val");
            _context.Add(order);
            _context.SaveChangesAsync();
            int id = order.id;
            return new JsonResult(id);
        }
        [HttpPut]
        public JsonResult Put(Order order)
        {
            _context.Update(order);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var acc = _context.orders.FindAsync(id);
            Order order = _context.orders.SingleOrDefault(X => X.id == id);
            _context.orders.Remove(order);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
        // GET: Order
        //public async Task<IActionResult> Index()
        //{
        //    var dataContext = _context.orders.Include(o => o.Location).Include(o => o.OrderStatus).Include(o => o.RestaurantStatus).Include(o => o.Status);
        //    return View(await dataContext.ToListAsync());
        //}

        // GET: Order/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.orders
        //        .Include(o => o.orderStatuses)
        //        .Include(o => o.restaurantStatuses)
        //        .Include(o => o.statuses)
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //// GET: Order/Create
        //public IActionResult Create()
        //{
        //    ViewData["orderStatusId"] = new SelectList(_context.orderStatuses, "id", "val");
        //    ViewData["restaurantStatusId"] = new SelectList(_context.restaurantStatuses, "id", "val");
        //    ViewData["statusId"] = new SelectList(_context.statuses, "id", "val");
        //    return View();
        //}

        //// POST: Order/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,orderLocation,customerStatus,locationId,orderStatusId,restaurantStatusId,statusId")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(order);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["orderStatusId"] = new SelectList(_context.orderStatuses, "id", "val", order.orderStatusId);
        //    //ViewData["restaurantStatusId"] = new SelectList(_context.restaurantStatuses, "id", "val", order.restaurantStatusId);
        //    //ViewData["statusId"] = new SelectList(_context.statuses, "id", "val", order.statusId);
        //    return View(order);
        //}

        //// GET: Order/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    //ViewData["orderStatusId"] = new SelectList(_context.orderStatuses, "id", "val", order.orderStatusId);
        //    //ViewData["restaurantStatusId"] = new SelectList(_context.restaurantStatuses, "id", "val", order.restaurantStatusId);
        //    //ViewData["statusId"] = new SelectList(_context.statuses, "id", "val", order.statusId);
        //    return View(order);
        //}

        //// POST: Order/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,RestaurantId,DateTime,Customer,Total,Driver,Vehicle,orderLocation,customerStatus,locationId,orderStatusId,restaurantStatusId,statusId")] Order order)
        //{
        //    if (id != order.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(order);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderExists(order.id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["orderStatusId"] = new SelectList(_context.orderStatuses, "id", "val", order.orderStatusId);
        //    //ViewData["restaurantStatusId"] = new SelectList(_context.restaurantStatuses, "id", "val", order.restaurantStatusId);
        //    //ViewData["statusId"] = new SelectList(_context.statuses, "id", "val", order.statusId);
        //    return View(order);
        //}

        //// GET: Order/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.orders
        //        .Include(o => o.orderStatuses)
        //        .Include(o => o.restaurantStatuses)
        //        .Include(o => o.statuses)
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //// POST: Order/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var order = await _context.orders.FindAsync(id);
        //    _context.orders.Remove(order);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrderExists(int id)
        //{
        //    return _context.orders.Any(e => e.id == id);
        //}
    }
}
