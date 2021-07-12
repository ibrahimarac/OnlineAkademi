using OnlineAkademi.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Entities
{
    public class Course : BaseEntity, IPermanent, ITrackable
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Duration { get; set; }

        public int Quota { get; set; }

        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<TrainerInCourse> TrainerInCourses { get; set; }

        public ICollection<StudentInCourse> CourseStudents { get; set; }

        public ICollection<CourseMaterial> Materials { get; set; }
    }
}
