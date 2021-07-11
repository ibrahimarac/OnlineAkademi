using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Entities
{
    public class Log:BaseEntity
    {
        public string Username { get; set; }
        public string EntityName { get; set; }
        public string Old { get; set; }
        public string New { get; set; }
        public DateTime LogDate { get; set; }
    }
}
