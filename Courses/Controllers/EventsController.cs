using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using Courses.ViewModels;
using AutoMapper;
using Courses.Models;
using Courses.Data;

namespace Courses.Controllers
{
    public class EventsController: Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            //TODO: add main page with concerts 

            var events = _context.Concerts.ToList();
            
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertViewModel viewModel)
        {
            var mapped = _mapper.Map<Concert>(viewModel);
            mapped.CreatedDate = DateTime.Now;
            await _context.Concerts.AddAsync(mapped);
            await _context.SaveChangesAsync();

            //TODO: add logic for adding tickets to DB acc to Tickets number

            return Redirect("/Events/Index/");
        }

    }
}
