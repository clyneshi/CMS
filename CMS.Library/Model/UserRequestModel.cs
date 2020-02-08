namespace CMSLibrary.Model
{
    public class UserRequestModel
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string RoleType { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ConfId { get; set; }
        public string ConfTitle { get; set; }
    }
}
