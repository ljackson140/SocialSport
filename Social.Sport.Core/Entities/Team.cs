namespace Social.Sport.Core.Entities
{
    public class Team : BaseEntity
    {
        public string TeamName { get; set; }
        public int TeamCaptain { get; set; } // get user from user table, logic should be found in service later on 
        public string TeamDescription { get; set; }
        public int TeamMax {  get; set; }
        public ICollection<User> Users { get; set; }
    }
}
