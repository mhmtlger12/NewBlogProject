using ProgrammersBlog.Shared.Entities.Abstract;
using System;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Log : IEntity
    {
        public Guid Id { get; set; }
        public string MachineName { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }

        // Yeni eklenen alanlar
        public string Controller { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RequestPath { get; set; }
        public string RequestMethod { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string RequestId { get; set; }
        public string ExceptionType { get; set; }
        public int? StatusCode { get; set; }
        public string RequestQueryString { get; set; }
        public string RequestBody { get; set; }
        public string Browser { get; set; }
    }
}