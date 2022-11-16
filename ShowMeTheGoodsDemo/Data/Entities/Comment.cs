using ShowMeTheGoodsDemo.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace ShowMeTheGoodsDemo.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int EventID { get; set; }
        public Event Eevent { get; set; }

        //public string UserId { get; set; }
        //public SiteRestUser User { get; set; }
    }
}
