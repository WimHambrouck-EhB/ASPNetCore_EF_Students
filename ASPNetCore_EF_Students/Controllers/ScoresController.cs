﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_EF_Students.Data;
using ASPNetCore_EF_Students.Models;

namespace ASPNetCore_EF_Students.Controllers
{
    public class ScoresController : Controller
    {
        private readonly StudentsContext _context;

        public ScoresController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Scores
        public async Task<IActionResult> Index()
        {
            var studentenMetPunten = _context.Students.Include(s => s.Points!).ThenInclude(p => p.Course);
            return View(await studentenMetPunten.ToListAsync());
        }

        // GET: Scores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Scores == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // GET: Scores/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId,Points")] Score score)
        {
            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", score.StudentId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Scores == null)
            {
                return NotFound();
            }

            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", score.StudentId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,Points")] Score score)
        {
            if (id != score.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(score);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoreExists(score.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", score.StudentId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Scores == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Scores == null)
            {
                return Problem("Entity set 'ASPNetCore_EF_StudentsContext.Score'  is null.");
            }
            var score = await _context.Scores.FindAsync(id);
            if (score != null)
            {
                _context.Scores.Remove(score);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScoreExists(int id)
        {
          return (_context.Scores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
