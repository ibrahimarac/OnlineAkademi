using OnlineAkademi.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Entities
{
    public class Student:IPermanent,ITrackable
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }


        public bool? IsActive { get; set; }

        public ICollection<StudentInCourse> StudentCourses { get; set; }
    }
}
