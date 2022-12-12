using Votes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Votes.Models
{
    public class Score : IEntity<int>
    {
        public int Id { get; set; }
        public int Scored { get; set; }
        public DateTime Created { get; set; }
        public string EmployeeId { get; set; }
    }
}
