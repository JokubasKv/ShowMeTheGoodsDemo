namespace ShowMeTheGoodsDemo.Auth.Model
{
    public class SiteRoles
    {
        public const string Admin = nameof(Admin);
        public const string Organizer = nameof(Organizer);
        public const string User = nameof(User);
        public static readonly IReadOnlyCollection<string> All = new[] { Admin, Organizer, User };
    }
}
