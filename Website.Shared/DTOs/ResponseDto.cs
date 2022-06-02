namespace Website.Shared.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccessfulOperation { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
