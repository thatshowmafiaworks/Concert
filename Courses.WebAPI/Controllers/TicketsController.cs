using Courses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.WebAPI.Controllers
{
    public class TicketsController: ControllerBase
    {
        public TicketsController()
        {
            throw new NotImplementedException();
        }

        //[HttpGet("{concertId}")]
        //public ActionResult<IEnumerable<Ticket>> Tickets(Guid concertId)
        //{
        //    IEnumerable<Concert> tickets = new List<Concert>();

        //    return Ok(tickets);
        //}
    }
}
