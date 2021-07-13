using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto
{
    public class TrainerDto:TrackableDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Experience { get; set; }

        public TrainerType TrainerType { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }
    }
}
