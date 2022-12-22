using Microsoft.AspNetCore.Mvc;
using ShowMeTheGoodsDemo.Data.Dtos.EventType;
using ShowMeTheGoodsDemo.Data.Dtos.Event;
using ShowMeTheGoodsDemo.Data.Dtos.Comments;
using ShowMeTheGoodsDemo.Data.Entities;
using ShowMeTheGoodsDemo.Data.Repositories;
using ShowMeTheGoodsDemo.Data.Reposotories;

namespace ShowMeTheGoodsDemo.Controllers
{

    /*
        api/eventType/{eventTypeId}/event/{eventId}/comments GET List 200
        api/eventType/{eventTypeId}/event/{eventId}/comments/{commentId} GET One 200
        api/eventType/{eventTypeId}/event/{eventId}/comments POST Create 201
        api/eventType/{eventTypeId}/event/{eventId}/comments{commentId} PUT/PATCH Modify 200
        api/eventType/{eventTypeId}/event/{eventId}/comments{commentId} DELETE Remove 200/204
    */

    [ApiController]
    [Route("api/eventType/{eventTypeId}/event/{eventId}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly IEventsTypeRepository _eventTypeRepository;
        private readonly IEventsRepository _eventRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController(IEventsTypeRepository eventsRepository, IEventsRepository usersRepository, ICommentsRepository commentsRepository)
        {
            _eventTypeRepository = eventsRepository;
            _eventRepository = usersRepository;
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CommentDto>> GetMany(int eventId)
        {
            var comments = await _commentsRepository.GetAsync(eventId);
            return comments.Select(x => new CommentDto(x.Id, x.Content, x.CreationDate, x.EventID));
        }

        // api/eventType/{eventTypeId}/event/{eventId}/comments{commentId}
        [HttpGet]
        [Route("{commentId}")]
        public async Task<ActionResult<CommentDto>> Get(int eventTypeId, int eventId, int commentId)
        {
            var eevent = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eevent == null) return NotFound($"Couldn't find a event type with id of {eventTypeId}"); //404

            var user = await _eventRepository.GetAsync(eventTypeId, eventId);
            if (user == null) return NotFound($"Couldn't find a event with id of {eventId}"); //404

            var comment = await _commentsRepository.GetAsync(eventId, commentId);
            if (comment == null) return NotFound($"Couldn't find a comment with id of {commentId}"); //404

            return new CommentDto(comment.Id, comment.Content, comment.CreationDate, comment.EventID);
        }

        // api/eventType/{eventTypeId}/event/{eventId}/comments
        [HttpPost]
        public async Task<ActionResult<CommentDto>> Create(int eventTypeId, int eventId, CreateCommentDto createCommentDto)
        {
            var eeventType = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eeventType == null)
            {
                return NotFound($"Couldn't find a event with id of {eventTypeId}"); //404
            }

            var eevent = await _eventRepository.GetAsync(eventId);
            if (eevent == null)
            {
                return NotFound($"Couldn't find a user with id of {eventId}"); //404
            }

            var comment = new Comment
            {
                Content = createCommentDto.Content,
                CreationDate = DateTime.Now
            };
            comment.EventID = eventId;
            await _commentsRepository.CreateAsync(comment);

            //201
            return Created($"api/eventType/{eventTypeId}/event/{eventTypeId}/comments/{comment.Id}", new CommentDto(comment.Id, comment.Content, comment.CreationDate, comment.EventID));
        }

        // api/eventType/{eventTypeId}/event/{eventId}/comments{commentId}
        [HttpPut]
        [Route("{commentId}")]
        public async Task<ActionResult<CommentDto>> Update(int eventTypeId, int eventId, int commentId, UpdateCommentDto commentDto)
        {
            var eeventType = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eeventType == null)
            {
                return NotFound($"Couldn't find a event typr with id of {eventTypeId}"); //404
            }

            var eevent = await _eventRepository.GetAsync(eventTypeId, eventId);
            if (eevent == null)
            {
                return NotFound($"Couldn't find a type with id of {eventId}"); //404
            }

            var comment = await _commentsRepository.GetAsync(eventId, commentId);
            if (comment == null)
            {
                return NotFound($"Couldn't find a comment with id of {commentId}"); //404
            }

            comment.Content = commentDto.Content;
            await _commentsRepository.UpdateAsync(comment);

            return Ok(new CommentDto(comment.Id, comment.Content, comment.CreationDate, comment.EventID)); //200
        }

        // api/eventType/{eventTypeId}/event/{eventId}/comments{commentId}
        [HttpDelete]
        [Route("{commentId}")]
        public async Task<ActionResult> Remove(int eventTypeId,int eventId, int commentId)
        {
            var eevent = await _eventTypeRepository.GetAsync(eventTypeId);
            if (eevent == null)
            {
                return NotFound($"Couldn't find a event type with id of {eventTypeId}"); //404
            }

            var user = await _eventRepository.GetAsync(eventTypeId, eventId);
            if (user == null)
            {
                return NotFound($"Couldn't find a event with id of {eventId}"); //404
            }

            var comment = await _commentsRepository.GetAsync( eventId, commentId);
            if (comment == null)
            {
                return NotFound($"Couldn't find a comment with id of {commentId}"); //404
            }
            await _commentsRepository.DeleteAsync(comment);

            return NoContent();// 204
        }
    }
}
