using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votes.Models;
using Votes.Services;
using Votes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Votes.Data;

namespace Votes.Controllers
{
    [Authorize]
    public class ScoreController : Controller
    {
        private readonly IScoreService _scoreService;
        private readonly ApplicationDbContext _context;
        public ScoreController(IScoreService scoreService, ApplicationDbContext context)
        {
            _context = context;
            _scoreService = scoreService;
        }
        [HttpGet]
        public IActionResult Evaluation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Evaluation(int scored)
        {
            var scr = new Score()
            {
                Scored = scored,
                EmployeeId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            _scoreService.Create(scr);
            return Ok("Благодарим за отзыв!");
        }
        [HttpGet]

        public IActionResult GetScores()
        {
            var employeeEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var scr = _scoreService.GetScore(employeeEmail);
            var scrs = new List<ScoreViewModel>();

            foreach(var item in scr)
            {
                scrs.Add(new ScoreViewModel()
                {
                    Id = item.Id,
                    EmployeeId = employeeEmail,
                    Scored = item.Scored,
                    Created = item.Created,
                    AverageScore = Math.Round(_context.Scores.Where(x => x.EmployeeId == employeeEmail).Average(x => x.Scored), 1)
                });
            }
            return View(scrs);
        }
    }
}