using AutoMapper;
using InnofoltDataAccess.Abstract;
using InnoloftWebAPI.Entities;
using InnoloftWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnoloftWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventDal _eventDal;
        private readonly IMapper _mapper;
        public EventsController(IEventDal eventDal, IMapper mapper)
        {
            _eventDal = eventDal;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEvents([FromQuery] QueryParams queryParams)
        {
            var events = _eventDal.GetAll(queryParams.Page, queryParams.ItemsPerPage);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var events = _eventDal.GetById(id);
            return Ok(events);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventModel @event)
        {
            try
            {
                var addedEvent = _mapper.Map<Event>(@event);
                if (addedEvent.UserId == 0) throw new Exception("UserID cannot be null");
                var newEvent = _eventDal.Add(addedEvent);

                return Ok(newEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult UpdateEvent(UpdateEventModel @event)
        {
            var updatedEvent = _mapper.Map<Event>(@event);
            var newEvent = _eventDal.Update(updatedEvent);
            return Ok(newEvent);
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {
            var newEvent = _eventDal.Delete(id);
            return Ok(newEvent);
        }
    }
}
