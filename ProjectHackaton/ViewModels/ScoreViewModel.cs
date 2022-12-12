using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Votes.ViewModels
{
    public class ScoreViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Scored { get; set; }
        public DateTime Created { get; set; }
        public string EmployeeId { get; set; }
        public double AverageScore { get; set; }
    }
}
