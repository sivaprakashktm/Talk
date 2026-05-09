namespace TalkService.Model.Response
{
    public class ResponseDetailList<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int? TalkStatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? Eception { get; set; }
    }
}
