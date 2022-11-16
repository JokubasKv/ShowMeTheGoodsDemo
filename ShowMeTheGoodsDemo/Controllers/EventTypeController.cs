using Microsoft.AspNetCore.Mvc;
using ShowMeTheGoodsDemo.Data.Dtos.EventType;
using ShowMeTheGoodsDemo.Data.Entities;
using ShowMeTheGoodsDemo.Data.Repositories;

namespace ShowMeTheGoodsDemo.Controllers
{
    /* 
/api/eventType GET List 200
/api/eventType/{id} GET One 200
/api/eventType/ POST Create 201
/api/eventType/{id} PUT/PATCH Modify 200
/api/eventType/{id} DELETE Remove 200/204
 */
    [ApiController]
    [Route("api/eventType")]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventsTypeRepository _eventTypeRepository;
        public EventTypeController(IEventsTypeRepository eventsRepository)
        {
            _eventTypeRepository = eventsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EventTypeDto>> GetMany()
        {
            var events = await _eventTypeRepository.GetManyAsync();

            return events.Select(x => new EventTypeDto(x.Id, x.Name, x.Description, x.CreationDate));
        }

        // api/events/{eventId}
        [HttpGet]
        [Route("{eventTypeId}", Name = "GetEventType")]
        public async Task<ActionResult<EventTypeDto>> Get(int eventId)
        {
            var eevent = await _eventTypeRepository.GetAsync(eventId);

            if (eevent == null)
            {
                return NotFound($"Cant find a event with id {eventId}");// 404
            }

            return new EventTypeDto(eevent.Id, eevent.Name, eevent.Description,  eevent.CreationDate);
        }

        // api/events
        [HttpPost]
        public async Task<ActionResult<EventTypeDto>> Create(CreateEventTypeDto createEventTypeDto)
        {
            var eevent = new EventType
            { Name = createEventTypeDto.Name,
                Description = createEventTypeDto.Description,
                CreationDate = DateTime.UtcNow
            };

            await _eventTypeRepository.CreateAsync(eevent);

            // 201
            return Created("", new EventTypeDto(eevent.Id, eevent.Name, eevent.Description, eevent.CreationDate));
        }

        // api/events
        [HttpPut]
        [Route("{eventTypeId}")]
        public async Task<ActionResult<EventTypeDto>> Update(int eventId, UpdateEventTypeDto updateEventsDto)
        {
            var eevent = await _eventTypeRepository.GetAsync(eventId);

            if (eevent == null)
            {
                return NotFound($"Cant find a event with id {eventId}"); // 404
            }
            eevent.Description = updateEventsDto.Description;
            await _eventTypeRepository.UpdateAsync(eevent);

            return Ok(new EventTypeDto(eevent.Id, eevent.Name, eevent.Description, eevent.CreationDate));
        }

        // api/events/{eventId}
        [HttpDelete]
        [Route("{eventTypeId}")]
        public async Task<ActionResult> Remove(int eventId)
        {
            var eevent = await _eventTypeRepository.GetAsync(eventId);

            if (eevent == null)
            {
                return NotFound($"Cant find a event with id {eventId}"); // 404
            }
            await _eventTypeRepository.DeleteAsync(eevent);

            //204
            return NoContent();
        }
    }
}
