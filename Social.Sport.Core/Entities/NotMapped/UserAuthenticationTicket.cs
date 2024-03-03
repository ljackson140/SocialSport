namespace Social.Sport.Core.Entities.NotMapped
{
    public class UserAuthenticationTicket
    {
        public string AccessToken { get; set; }
        public User User { get; set; }
    }
}
