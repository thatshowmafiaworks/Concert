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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Courses.Controllers
{
    public class EventsController: Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<IdentityUser> _userManager;

        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationContext context, IWebHostEnvironment env, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _environment = env;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var events = _context.Concerts.ToList();
            
            return View(events);
        }

        [HttpGet]
        [Authorize(Policy = "AtLeastManager")]
        public IActionResult CreateConcert()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AtLeastManager")]
        public async Task<IActionResult> CreateConcert(CreateConcertViewModel viewModel)
        {
            var currentUser = await _userManager.GetUserAsync(this.User);
            var mapped = _mapper.Map<Concert>(viewModel);
            mapped.Id = Guid.NewGuid();
            mapped.CreatedDate = DateTime.Now;
            mapped.UpdatedDate = mapped.CreatedDate;
            mapped.CreatedBy = new Guid(currentUser.Id);
            mapped.UpdatedBy = new Guid(currentUser.Id);

            var fileName = mapped.Id.ToString() + Path.GetExtension(viewModel.Poster.FileName);
            var filePath = Path.Combine(_environment.WebRootPath, @"posters\", fileName);
            mapped.Poster = fileName;

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewModel.Poster.CopyTo(fileStream);
            }
            await _context.Concerts.AddAsync(mapped);
            //await _context.Posters.AddAsync(new Poster { ConcertId = mapped.Id, Path = filePath , Concert = mapped});
            await _context.SaveChangesAsync();
            return Redirect("/Events/AddTickets/");
        }

        [HttpGet]
        [Authorize(Policy = "AtLeastManager")]
        public IActionResult AddTickets()
        {
            var events = _context.Concerts.ToList();
            ViewBag.concerts = new SelectList(events,"Id","Title");
            return View();
        }

        [HttpPost]
        [Authorize(Policy ="AtLeastManager")]
        public async Task<IActionResult> AddTickets(AddTicketsViewModel viewModel)
        {
            DateOnly day = DateOnly.FromDateTime(viewModel.Day);
            TimeOnly time = TimeOnly.FromDateTime(viewModel.Time);

            var mapped = _mapper.Map<Ticket>(viewModel);
            var currentUser = await _userManager.GetUserAsync(this.User);
            mapped.CreatedBy = new Guid(currentUser.Id);
            mapped.UpdatedBy = new Guid(currentUser.Id);

            mapped.Date = day.ToDateTime(time);
            mapped.CreatedDate = DateTime.Now;
            mapped.UpdatedDate = mapped.CreatedDate;

            var concert = _context.Concerts.FirstOrDefault(x => x.Id == mapped.ConcertId);
            concert.SeatsNumber += viewModel.SeatsNumber;
            _context.Concerts.Update(concert);
            List<Ticket> ticketsToAdd = new List<Ticket>();

            for(int i = 0; i < viewModel.SeatsNumber; i++)
            {
                mapped.Id = new Guid();
                ticketsToAdd.Add(mapped);
            }
            _context.Tickets.AddRange(ticketsToAdd);
            _context.SaveChanges();
            return Redirect("/Events/Index/");
        }
    }
}
