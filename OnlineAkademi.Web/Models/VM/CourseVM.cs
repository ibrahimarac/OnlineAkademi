using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Models.VM
{
    public class CourseVM
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Display(Name="Kategorisi")]
        public int? CategoryId { get; set; }

        [Display(Name = "Kategori adı")]
        public string CategoryName { get; set; }

        [Display(Name="Eğitimin Adı")]
        public string Name { get; set; }

        [Display(Name="Fiyatı (saatlik)")]
        public double Price { get; set; }

        [Display(Name="Süresi")]
        public int Duration { get; set; }

        [Display(Name = "Maksimum kişi sayısı")]
        public int Quota { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
    }
}
