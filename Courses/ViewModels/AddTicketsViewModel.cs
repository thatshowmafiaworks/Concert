using Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.ViewModels
{
    public class AddTicketsViewModel
    {
        public Guid ConcertId { get; set; }
        public DateTime Date { get; set; }

        public DateTime Day { get; set; }
        public DateTime Time { get; set; }

        public int SeatsNumber { get; set; }

    }
}
