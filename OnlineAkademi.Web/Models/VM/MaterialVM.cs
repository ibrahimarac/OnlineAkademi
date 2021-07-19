using Microsoft.AspNetCore.Http;
using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Models.VM
{
    public class MaterialVM
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int CourseId { get; set; }

        [Display(Name ="Açıklama")]
        public string Description { get; set; }

        [Display(Name ="Materyal Türü")]
        public MaterialType MaterialType { get; set; }

        public IFormFile UploadedFile { get; set; }

        public string Url { get; set; }
    }
}
