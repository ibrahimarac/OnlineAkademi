using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto
{
    public class BaseDto
    {
        public int Id { get; set; }
        public bool? IsActive { get; set; }
    }

    public class NonTrackableDto : BaseDto
    {

    }

    public class TrackableDto : BaseDto
    {
        public string LastupUser { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }

}
