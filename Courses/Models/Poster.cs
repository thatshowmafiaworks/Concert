using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Models
{
    public class Poster
    {
        public Guid Id { get; set; }
        public string Path { get;set; } = string.Empty;
        public Guid ConcertId { get; set; }
        public Concert Concert { get; set; }
    }
}
