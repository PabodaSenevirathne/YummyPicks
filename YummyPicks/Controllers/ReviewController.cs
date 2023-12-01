using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YummyPicks.Data;
using YummyPicks.Models;

namespace YummyPicks.Controllers
{
    public class ReviewController : Controller
    {
        private readonly YummyPicksContext _context;

        public ReviewController(YummyPicksContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            return _context.Review != null ?
                        View(await _context.Review.ToListAsync()) :
                        Problem("Entity set 'YummyPicksContext.Review'  is null.");
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,RestaurantName,FoodName,Price,PublishingDate,Image")] Review review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(review);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(review);
        //}

        public async Task<IActionResult> Create(ReviewViewModel Re)
        {
            string filename = "";
            if (Re.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Re.Photo.CopyToAsync(memoryStream);

                    Review Review1 = new Review()
                    {
                        Id = Re.Id,
                        RestaurantName = Re.RestaurantName,
                        FoodName = Re.FoodName,
                        Price = Re.Price,
                        PublishingDate = Re.PublishingDate,
                        Image = memoryStream.ToArray()
                    };
                    _context.Add(Review1);
                    _context.SaveChangesAsync();

                    ViewBag.success = "record added";
                    return RedirectToAction(nameof(Index));

                }
            }

            else
            {
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetImage(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review.Image != null)
            {
                return File(review.Image, "image/jpeg"); // Change "image/jpeg" based on your image type
            }
            return NotFound();
        }
        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RestaurantName,FoodName,Price,PublishingDate,Image")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Review == null)
            {
                return Problem("Entity set 'YummyPicksContext.Review'  is null.");
            }
            var review = await _context.Review.FindAsync(id);
            if (review != null)
            {
                _context.Review.Remove(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return (_context.Review?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
