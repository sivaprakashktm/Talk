namespace TalkService.Model.Response
{
    public class ResponseDetail<T>
    {
        public T? Data { get; set; }
        public int? TalkStatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? Eception { get; set; }
    }
}
