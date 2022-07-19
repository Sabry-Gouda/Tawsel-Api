using System.Collections.Generic;

namespace tawsel.DTO
{
    public class ResponseDto
    {
        public bool IsSuccessfulOperation { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
