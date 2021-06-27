namespace CMS.Service.Models
{
    public class UserRequestModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ConferenceId { get; set; }
        public string Title { get; set; }
    }
}
