using System;
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
            var studentMetScores = _context.Students.Include(s => s.Scores)
                                                   .ThenInclude(s => s.Course)
                                                   .OrderBy(s => s.Name);
            return View(await studentMetScores.ToListAsync());
        }

        // GET: Scores/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses?.OrderBy(c => c.Name), "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students?.OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,Grade")] Score score)
        {
            if (ScoreExists(score))
            {
                ModelState.AddModelError("Grade", "Student already has a grade for this course. Either delete or edit the original grade.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses?.OrderBy(c => c.Name), "Id", "Name", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students?.OrderBy(s => s.Name), "Id", "Name", score.StudentId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public async Task<IActionResult> Edit(int? StudentId, int? CourseId)
        {
            if (StudentId == null || CourseId == null || _context.Scores == null)
            {
                return NotFound();
            }

            var score = await _context.Scores.FindAsync(StudentId, CourseId);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses?.OrderBy(c => c.Name), "Id", "Name", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students?.OrderBy(s => s.Name), "Id", "Name", score.StudentId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int StudentId, int CourseId, [Bind("StudentId,CourseId,Grade")] Score score)
        {
            if (StudentId != score.StudentId || CourseId != score.CourseId)
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
                    if (!ScoreExists(score))
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
            ViewData["CourseId"] = new SelectList(_context.Courses?.OrderBy(c => c.Name), "Id", "Name", score.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students?.OrderBy(s => s.Name), "Id", "Name", score.StudentId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public async Task<IActionResult> Delete(int? StudentId, int? CourseId)
        {
            if (StudentId == null || CourseId == null || _context.Scores == null)
            {
                return NotFound();
            }

            var score = await _context.Scores
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == StudentId && m.CourseId == CourseId);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int StudentId, int CourseId)
        {
            if (_context.Scores == null)
            {
                return Problem("Entity set 'StudentsContext.Scores'  is null.");
            }
            var score = await _context.Scores.FindAsync(StudentId, CourseId);
            if (score != null)
            {
                _context.Scores.Remove(score);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScoreExists(Score score)
        {
            return (_context.Scores?.Any(e => e.StudentId == score.StudentId && e.CourseId == score.CourseId)).GetValueOrDefault();
        }
    }
}
