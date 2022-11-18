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
    public class RoomControlller : Controller
    {
        private readonly IRoom _room;

        public RoomControlller(IRoom r)
        {
            _room = r;
        }

        // GET: RoomControlller
        public async Task<IActionResult> Index()
        {
            return View(await _room.GetRooms());
        }

        // GET: RoomControlller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _room.GetRooms() == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: RoomControlller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomControlller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _room.Create(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: RoomControlller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _room.GetRooms() == null)
            {
                return NotFound();
            }

            var room = await _room.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: RoomControlller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _room.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            return View(room);
        }

        // GET: RoomControlller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _room.GetRooms() == null)
            {
                return NotFound();
            }

            var room = await _room.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: RoomControlller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_room.GetRooms == null)
            {
                return Problem("Entity set 'TestDbContext.Rooms'  is null.");
            }
            var room = await _room.Find(id);

            if(room != null)
            {
                await _room.Delete(room);
            }
            
            await _room.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _room.Exists(id);
        }
    }
}
