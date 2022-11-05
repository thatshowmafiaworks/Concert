using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Models
{
    public class Concert
    {
        public Guid ID { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Artist { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
