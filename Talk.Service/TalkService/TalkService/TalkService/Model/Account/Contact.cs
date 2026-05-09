namespace TalkService.Model.Account
{
    public class Contact
    {
        public int? UserId { get; set; }
        public int? ProfileId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public byte[]? Picture { get; set; }
    }
}
