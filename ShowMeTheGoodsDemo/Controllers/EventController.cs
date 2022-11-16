using Microsoft.AspNetCore.Mvc;
using ShowMeTheGoodsDemo.Data.Repositories;
using ShowMeTheGoodsDemo.Data.Dtos.EventType;
using ShowMeTheGoodsDemo.Data.Dtos.Event;
using ShowMeTheGoodsDemo.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using ShowMeTheGoodsDemo.Auth.Model;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ShowMeTheGoodsDemo.Controllers
{
    /*
    api/eventType/{eventTypeId}/event GET List 200
    api/eventType/{eventTypeId}/event/{eventId} GET One 200
    api/eventType/{eventTypeId}/event POST Create 201
    api/eventType/{eventTypeId}/event/{eventId} PUT/PATCH Modify 200
    api/eventType/{eventTypeId}/event/{eventId} DELETE Remove 200/204
    */

    [ApiController]
    [Route("api/eventType/{eventTypeId}/event")]
    public class EventController : ControllerBase
    {

        private readonly IEventsTypeRepository _eventTypeRepository;
        private readonly IEventsRepository _eventRepository;
        private readonly IAuthorizationService _authorizationService;
        public EventController(IEventsRepository usersRepository, IEventsTypeRepository eventsRepository, IAuthorizationService authorizationService)
        {
            _eventRepository = usersRepository;
            _eventTypeRepository = eventsRepository;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IEnumerable<EventDto>> GetMany()
        {
            var events = await _eventRepository.GetManyAsync();
            return events.Select(x => new EventDto(x.Id, x.Name,x.Description, x.Place, x.Price, x.CreationDate, x.EventTypeID));
        }

        // api/eventType/{eventTypetId}/event/{userId}
        [HttpGet]
        [Route("{eventId}")]
        public async Task<ActionResult<EventDto>> Get(int eventTypeId, int eventId)
        {
            var eeventType = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eeventType == null)
            {
                //404
                return NotFound($"Couldn't find a event type with id of {eventTypeId}");
            }

            var eevent = await _eventRepository.GetAsync(eventTypeId, eventId);
            if (eevent == null) return NotFound($"Couldn't find a event with id of {eventId}"); //404

            return new EventDto(eevent.Id, eevent.Name, eevent.Description, eevent.Place, eevent.Price, eevent.CreationDate, eevent.EventTypeID);
        }

        // api/eventType/{eventTypetId}/event
        [HttpPost]
        [Authorize(Roles = SiteRoles.User)]
        public async Task<ActionResult<EventDto>> Create(int eventTypeId, CreateEventDto createEventDto)
        {
            var eeventType = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eeventType == null)
            {
                //404
                return NotFound($"Couldn't find a event type with id of {eventTypeId}");
            }

            var eevent = new Event
            {
                Name = createEventDto.Name,
                Description = createEventDto.Description,
                Place = createEventDto.Place,
                Price = createEventDto.Price,
                CreationDate = DateTime.Now,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };
            eevent.EventTypeID = eventTypeId;
            await _eventRepository.CreateAsync(eevent);

            //201
            return Created($"api/eventType/{eventTypeId}/event/{eevent.Id}", new EventDto(eevent.Id, eevent.Name, eevent.Description, eevent.Place, eevent.Price, eevent.CreationDate, eevent.EventTypeID));
        }

        // api/eventType/{evenTypeId}/event
        [HttpPut]
        [Route("{eventId}")]
        [Authorize(Roles = SiteRoles.User)]
        public async Task<ActionResult<EventDto>> Update(int eventTypeId, int eventId, UpdateEventDto updateEventDto)
        {
            var eeventType = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eeventType == null)
            {
                return NotFound($"Couldn't find a event type with id of {eventTypeId}");
            }
            var eevent = await _eventRepository.GetAsync(eventTypeId, eventId);

            if (eevent == null)
            {
                return NotFound($"Couldn't find a event with id of {eventId}");
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, eevent, PolicyNames.ResourceOwner);

            if (!authorizationResult.Succeeded)
            {
                //404
                return Forbid();
            }

            eevent.Name = updateEventDto.Name;
            eevent.Description = updateEventDto.Description;
            eevent.Place = updateEventDto.Place;
            eevent.Price = updateEventDto.Price;
            await _eventRepository.UpdateAsync(eevent);

            return Ok(new EventDto(eevent.Id, eevent.Name, eevent.Description, eevent.Place, eevent.Price, eevent.CreationDate, eevent.EventTypeID));

        }

        // api/eventType/{eventTypeId}/event
        [HttpDelete]
        [Route("{eventId}")]
        public async Task<ActionResult> Remove(int eventTypeId, int eventId)
        {
            var eeventType = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eeventType == null)
            {
                return NotFound($"Couldn't find a event with id of {eventTypeId}");
            }

            var eevent = await _eventRepository.GetAsync(eventTypeId, eventId);
            if (eevent == null)
            {
                return NotFound($"Couldn't find a user with id of {eventId}");
            }
            await _eventRepository.DeleteAsync(eevent);

            //204
            return NoContent();
        }
    }

}

