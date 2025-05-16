

namespace ProgrammersBlog.Shared.Entities.Concrete
{
    public class MvcErrorModel
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public string ErrorCode { get; set; }
        public string RequestId { get; set; }
        public string StackTrace { get; set; }
    }
}
