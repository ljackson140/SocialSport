namespace Social.Sport.Core.Entities
{
    public  class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Password { get; set; }
        public string? salt { get; set; }
        public string? Role { get; set; }
        public DateTime DOB {  get; set; }
        public string phoneNumber { get; set; }
        public int? TeamId { get; set; } 
        public UserStatus? isActive { get; set; }
    }
}
