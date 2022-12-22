using ShowMeTheGoodsDemo.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace ShowMeTheGoodsDemo.Data.Entities
{
    public class Event : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Place { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        public string? PictureLink { get; set; }
        public DateTime CreationDate { get; set; }
        public EventType EventType { get; set; }

        [Required]
        public string UserId { get; set; }
        public SiteRestUser User { get; set; }

        public int EventTypeID { get; set; }

    }
}
