using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity a)
        {
            _amenity = a;
        }



        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            return View(await _amenity.GetAmenities());
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _amenity.GetAmenities() == null)
            {
                return NotFound();
            }

            var amenity = await _amenity.GetAmenity(id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Smoking","Non Smoking")] Amenity amenity)
        {
            if (ModelState.IsValid)
            {
                await _amenity.Create(amenity);
                return RedirectToAction(nameof(Index));
            }
            return View(amenity);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _amenity.GetAmenities() == null)
            {
                return NotFound();
            }

            var amenity = await _amenity.Find(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return View(amenity);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AirConditioning,Coffee,OceanView,MiniBar,Fridge,Safe,PetFriendly")] Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _amenity.UpdateAmenity(amenity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityExists(amenity.Id))
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
            return View(amenity);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _amenity.GetAmenities() == null)
            {
                return NotFound();
            }

            var amenity = await _amenity.GetAmenity(id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_amenity.GetAmenities() == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Amenities'  is null.");
            }
            var amenity = await _amenity.Find(id);
            if (amenity != null)
            {
                _amenity.Delete(amenity);
            }

            await _amenity.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityExists(int id)
        {
            return _amenity.AmenityExists(id);
        }
    }
}