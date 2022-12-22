namespace ShowMeTheGoodsDemo.Data.Dtos.EventType
{
        public record EventTypeDto(int Id, string Name, string Description, string PictureLink, DateTime CreationDate);
        public record CreateEventTypeDto(string Name, string Description, string PictureLink);
        public record UpdateEventTypeDto(string Description, string PictureLink);
    
}
