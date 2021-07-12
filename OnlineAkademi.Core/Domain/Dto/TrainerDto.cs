using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto
{
    public class TrainerDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Experience { get; set; }

        public TrainerType TrainerType { get; set; }

        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
