using Microsoft.AspNetCore.Mvc;

namespace EventCalendar.Api.Controller
{
    [ApiController]
    [Route("events")]
    public class EventsController : ControllerBase
    {
        public EventsRepository _EventsRepository;

        public EventsController(EventsRepository eventsRepository)
        {
            _EventsRepository = eventsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            var events = _EventsRepository.GetEvent();

            return Ok(events);
        }
        [HttpPost]
        public async Task<ActionResult> AddEvent(EventModel eventModel)
        {
            _EventsRepository.AddEvent(eventModel);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEvent(EventModel eventModel)
        {
            _EventsRepository.UpdateEvent(eventModel);
            return Ok();
        }
    }
}
