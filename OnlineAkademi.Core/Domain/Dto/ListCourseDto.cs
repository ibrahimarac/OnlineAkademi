using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto
{
    public class ListCourseDto
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Trainer { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Duration { get; set; }

        public int Quota { get; set; }

        public int StudentCount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
