using Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.ViewModels
{
    public class CreateConcertViewModel
    {
        public string Title { get; set; } = String.Empty;
        public string Artist { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int SeatsNumber { get; set; }
        public EventType EventType { get; set; }
    }
}
