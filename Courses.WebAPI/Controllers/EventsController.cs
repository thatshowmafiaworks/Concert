using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Models;
using Courses.Data;
using AutoMapper;

namespace Courses.WebAPI.Controllers
{
    public class ApiController: ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ApiController(ApplicationContext context, IMapper mapper) =>
            (_context,_mapper) = (context, mapper);

        public ActionResult<IEnumerable<Concert>> Events(int count, int page)
        {
            IEnumerable<Concert> events = new List<Concert>();

            return Ok(events);
        }

        public ActionResult<IEnumerable<Ticket>> Tickets()
        {
            IEnumerable<Concert> tickets = new List<Concert>();

            return Ok(tickets);
        }

        

    }
}
