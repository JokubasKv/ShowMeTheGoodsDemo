namespace ShowMeTheGoodsDemo.Data.Dtos.EventType
{
        public record EventTypeDto(int Id, string Name, string Description, DateTime CreationDate);
        public record CreateEventTypeDto(string Name, string Description);
        public record UpdateEventTypeDto(string Description);
    
}
