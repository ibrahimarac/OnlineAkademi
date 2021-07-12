using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto
{
    public class CourseDto:TrackableDto
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string TrainerId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }

        public int Quota { get; set; }
    }
}
