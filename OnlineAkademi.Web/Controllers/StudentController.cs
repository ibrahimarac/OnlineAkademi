using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService Students;
        private readonly ICourseService Courses;
        private readonly IMapper Mapper;

        public StudentController(IStudentService studentService,
            ICourseService courseService,
            IMapper mapper)
        {
            Students = studentService;
            Courses = courseService;
            Mapper = mapper;
        }


        [HttpGet]
        [Route("Student/Buy/{id:int?}")]
        [Authorize(Roles ="student")]
        public async Task<IActionResult> BuyCourse(int? id)
        {
            //Öğrenciyi kursa bağla
            Students.BuyCourse(User.Identity.Name, id);

            //Kurs listesi sayfasına yönlendir.
            var courseDtos = await Courses.ListCourses();
            var courseVM = Mapper.Map<IEnumerable<ListCourseDto>, IEnumerable<ListCourseVM>>(courseDtos);
            return View("~/Views/Course/ListCourses.cshtml",courseVM);
        }

    }
}
