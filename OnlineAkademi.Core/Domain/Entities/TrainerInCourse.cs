using OnlineAkademi.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Entities
{
    public class TrainerInCourse : ITrackable, IPermanent
    {
        public int TrainerId { get; set; }

        public int CourseId { get; set; }

        public Trainer Trainer { get; set; }

        public Course Course { get; set; }


        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
