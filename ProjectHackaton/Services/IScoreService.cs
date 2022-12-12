using Votes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Votes.Services
{
    public interface IScoreService
    {
        public void Create(Score score);
        public List<Score> GetScore(string Id);
    }
}
