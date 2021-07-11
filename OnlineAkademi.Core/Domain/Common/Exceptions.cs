using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Common
{
    public class ParameterException:Exception
    {
        public ParameterException(string property,string entity,string message):base(message)
        {
            Property = property;
            Entity = entity;
        }

        public ParameterException()
        {

        }

        [JsonIgnore]
        public override string HelpLink
        {
            get
            {
                return base.HelpLink;
            }

            set
            {
                base.HelpLink = value;
            }
        }

        [JsonProperty]
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

        [JsonProperty]
        public override string StackTrace
        {
            get
            {
                return base.StackTrace;
            }
        }

        [JsonProperty]
        public string Property { get; set; }

        [JsonProperty]
        public string Entity { get; set; }
    }
}
