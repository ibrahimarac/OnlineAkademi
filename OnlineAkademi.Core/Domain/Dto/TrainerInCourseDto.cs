using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto
{
    public class TrainerInCourseDto
    {
        public string TrainerId { get; set; }

        public int CourseId { get; set; }

        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
