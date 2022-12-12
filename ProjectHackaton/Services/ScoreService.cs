using Votes.Data;
using Votes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Votes.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ApplicationDbContext _context;
        public ScoreService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Score score)
        {

            var scr = new Score
            {
                EmployeeId = score.EmployeeId,
                Created = DateTime.Now,
                Scored = score.Scored,
            };

            _context.Scores.Add(scr);
            _context.SaveChanges();
        }
        public List<Score> GetScore(string Id)
        {
            var scr = _context.Scores.Where(x => x.EmployeeId == Id)
                .ToList();
            return scr;
        }
    }
}
