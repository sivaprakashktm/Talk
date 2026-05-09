namespace TalkService.Model.Request
{
    public class AccountData
    {
        public int? UserId { get; set; }
        public int? UserRoleId { get; set; }
        public int? ProfileId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? bio { get; set; }
        public int? PictureId { get; set; }
        public byte[]? Image { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
