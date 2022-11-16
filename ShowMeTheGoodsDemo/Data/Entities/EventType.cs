using ShowMeTheGoodsDemo.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace ShowMeTheGoodsDemo.Data.Entities
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        //[Required]
        //public string UserId { get; set; }
       // public SiteRestUser User { get; set; }
    }
}
