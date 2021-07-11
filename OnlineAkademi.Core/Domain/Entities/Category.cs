using OnlineAkademi.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Domain.Entities
{
    public class Category:BaseEntity,IPermanent,ITrackable
    {   
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public string CreateUser { get; set; }

        public string LastupUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastupDate { get; set; }

        public Category()
        {

        }
    }
}
