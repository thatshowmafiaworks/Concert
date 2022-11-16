using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Models
{
    public class Concert
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Artist { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Place { get; set; } = String.Empty;
        public int SeatsNumber { get; set; } = 0;
        public Poster? Image { get; set; }
        public EventType EventType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
