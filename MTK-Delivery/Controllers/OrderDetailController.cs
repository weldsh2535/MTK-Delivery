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
    public class OrderDetailController : Controller
    {
        private readonly dataContext _context;

        public OrderDetailController(dataContext context)
        {
            _context = context;
        }

        // GET: OrderDetail
        [HttpGet]
        public JsonResult Get()
        {
            var dataContext = _context.orderDetails;
            return new JsonResult(dataContext);
        }
        [HttpPost]
        public JsonResult Post(OrderDetail account)
        {
            _context.Add(account);
            _context.SaveChangesAsync();
            // ViewData["LocationId"] = new SelectList(_context.locations, "id", "id", account.LocationId);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(OrderDetail account)
        {
            _context.Update(account);
            _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var acc = _context.orderDetails.FindAsync(id);
            OrderDetail account1 = _context.orderDetails.SingleOrDefault(X => X.id == id);
            _context.orderDetails.Remove(account1);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
        //public async Task<IActionResult> Index()
        //{
        //    var dataContext = _context.orderDetails.Include(o => o.Food).Include(o => o.Order);
        //    return View(await dataContext.ToListAsync());
        //}

        //// GET: OrderDetail/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDetail = await _context.orderDetails
        //        .Include(o => o.Food)
        //        .Include(o => o.Order)
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (orderDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderDetail);
        //}

        //// GET: OrderDetail/Create
        //public IActionResult Create()
        //{
        //    ViewData["foodId"] = new SelectList(_context.foods, "id", "Name");
        //    ViewData["orderId"] = new SelectList(_context.orders, "id", "Customer");
        //    return View();
        //}

        //// POST: OrderDetail/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,Qty,Price,foodId,orderId")] OrderDetail orderDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(orderDetail);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["foodId"] = new SelectList(_context.foods, "id", "Name", orderDetail.foodId);
        //    ViewData["orderId"] = new SelectList(_context.orders, "id", "Customer", orderDetail.orderId);
        //    return View(orderDetail);
        //}

        //// GET: OrderDetail/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDetail = await _context.orderDetails.FindAsync(id);
        //    if (orderDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["foodId"] = new SelectList(_context.foods, "id", "Name", orderDetail.foodId);
        //    ViewData["orderId"] = new SelectList(_context.orders, "id", "Customer", orderDetail.orderId);
        //    return View(orderDetail);
        //}

        //// POST: OrderDetail/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,Qty,Price,foodId,orderId")] OrderDetail orderDetail)
        //{
        //    if (id != orderDetail.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(orderDetail);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderDetailExists(orderDetail.id))
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
        //    ViewData["foodId"] = new SelectList(_context.foods, "id", "Name", orderDetail.foodId);
        //    ViewData["orderId"] = new SelectList(_context.orders, "id", "Customer", orderDetail.orderId);
        //    return View(orderDetail);
        //}

        //// GET: OrderDetail/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDetail = await _context.orderDetails
        //        .Include(o => o.Food)
        //        .Include(o => o.Order)
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (orderDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderDetail);
        //}

        //// POST: OrderDetail/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var orderDetail = await _context.orderDetails.FindAsync(id);
        //    _context.orderDetails.Remove(orderDetail);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrderDetailExists(int id)
        //{
        //    return _context.orderDetails.Any(e => e.id == id);
        //}
    }
}
