namespace TalkService.Model.Account
{
    public class User
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public int? UserRoleId { get; set; }
        public string? UserRole { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }

    }
}
