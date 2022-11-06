using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using Courses.ViewModels;

namespace Courses.Controllers
{
    public class EventsController: Controller
    {
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //TODO: add main page with concerts 
            throw new NotImplementedException("");
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertViewModel viewModel)
        {

            //TODO: add logic to create new Concert in DB and viewModel.SeatsNumber Tickets
            throw new NotImplementedException("");

            return Redirect("/Events/Index/");
        }

    }
}
