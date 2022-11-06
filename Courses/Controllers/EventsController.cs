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
using Microsoft.EntityFrameworkCore;

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
            mapped.UpdatedDate = mapped.CreatedDate;
            await _context.Concerts.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return Redirect("/Events/AddTikets/");
        }

        [HttpGet]
        public IActionResult AddTickets()
        {
            //TODO: Add view for this action
            throw new NotImplementedException();
            return View();
        }

        [HttpPost]
        public IActionResult AddTickets(AddTicketsViewModel viewModel)
        {
            //TODO: add logic for creating new ticket
            throw new NotImplementedException();
            return Redirect("/Events/Index/");
        }

    }
}
