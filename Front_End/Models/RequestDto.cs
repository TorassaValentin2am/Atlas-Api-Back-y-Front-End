using Front_End.Utility;
using static Front_End.Utility.SD;

namespace Front_End.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object? Data { get; set; }
    }
}
