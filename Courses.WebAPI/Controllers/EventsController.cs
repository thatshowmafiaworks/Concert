using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Models;
using Courses.Data;
using AutoMapper;
using Courses.ViewModels;
using System.Security.Claims;

namespace Courses.WebAPI.Controllers
{

    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public EventsController(ApplicationContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);


        //get exact page
        [HttpGet("{page}/{items}")]
        public ActionResult<IEnumerable<Concert>> GetPage(int page, int items)
        {
            IEnumerable<Concert> events = _context.Concerts.OrderByDescending(x => x.CreatedDate).Skip(page * items).Take(items).ToList();

            return Ok(events);
        }


        //get exact Concert
        [HttpGet("{id}")]
        public ActionResult<Concert> Get(Guid id)
        {
            var concert = _context.Concerts.FirstOrDefault(x => x.Id == id);
            if (concert == null) return NotFound();
            return Ok(concert);
        }


        //create Concert
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateConcertViewModel viewModel)
        {
            var concert = _mapper.Map<Concert>(viewModel);
            concert.CreatedBy = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            concert.UpdatedBy = concert.CreatedBy;
            concert.CreatedDate = DateTime.Now;
            concert.UpdatedDate = concert.CreatedDate;

            await _context.Concerts.AddAsync(concert);
            await _context.SaveChangesAsync();
            return Ok(concert.Id);
        }

        //update
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateConcertViewModel viewModel)
        {
            var concert = _context.Concerts.FirstOrDefault(x => x.Id == viewModel.Id);
            var update = _mapper.Map<Concert>(viewModel);
            concert.Title = update.Title;
            concert.Description = update.Description;
            concert.Artist = update.Artist;
            concert.Place = update.Place;
            concert.EventType = update.EventType;
            concert.UpdatedDate = DateTime.UtcNow;
            concert.UpdatedBy = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _context.SaveChangesAsync();

            return Ok(concert.Id);
        }


        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var concert = _context.Concerts.FirstOrDefault(x => x.Id == id);

            _context.Concerts.Remove(concert);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
