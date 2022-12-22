namespace ShowMeTheGoodsDemo.Data.Dtos.Event
{
    public record EventDto(int Id, string Name, string Description, string Place, float Price, DateTime EventDate, string PictureLink, DateTime CreationDate, int eventTypeId);
    public record CreateEventDto(string Name, string Description, string Place, float Price, DateTime EventDate, string PictureLink);
    public record UpdateEventDto(string Name, string Description, string Place, float Price, DateTime EventDate, string PictureLink);

}
