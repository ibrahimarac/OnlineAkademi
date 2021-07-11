using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Entities
{
    public class Error:BaseEntity
    {
        public string Username { get; set; }
        public string Url { get; set; }
        public string QueryString { get; set; }
        public int StatusCode { get; set; }
        public string Exception { get; set; }
        public RequestType RequestType { get; set; }
        public bool IsAjaxRequest { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
