using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineAkademi.Web.Models.VM
{
    public class ListCourseVM
    {
        public int Id { get; set; }

        [Display(Name="Kategorisi")]
        public string CategoryName { get; set; }

        [Display(Name = "Eğitmen")]
        public string Trainer { get; set; }

        [Display(Name = "Kurs Adı")]
        public string Name { get; set; }

        [Display(Name = "Fiyatı")]
        public double Price { get; set; }

        [Display(Name = "Süresi")]
        public int Duration { get; set; }

        [Display(Name = "Kontenjan")]
        public int Quota { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Kayıtlı Öğrenci Sayısı")]
        public int StudentCount { get; set; }
    }
}
