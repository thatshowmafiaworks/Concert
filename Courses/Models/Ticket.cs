using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid ConcertId { get; set; }
        public string Place { get; set; } = String.Empty;
        public TimeOnly BeginningDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
