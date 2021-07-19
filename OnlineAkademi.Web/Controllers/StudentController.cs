using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Utils.Extensions;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService Students;
        private readonly ICourseService Courses;
        private readonly IMaterialService Materials;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper Mapper;

        public StudentController(IStudentService studentService,
            ICourseService courseService,
            IMaterialService materialService,
            IWebHostEnvironment environment,
            IMapper mapper)
        {
            Students = studentService;
            Courses = courseService;
            Materials = materialService;
            _environment = environment;
            Mapper = mapper;
        }


        [HttpGet]
        [Route("Student/Buy/{id:int?}")]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> BuyCourse(int? id)
        {
            //Öğrenciyi kursa bağla
            Students.BuyCourse(User.Identity.Name, id);

            //Kurs listesi sayfasına yönlendir.
            var courseDtos = await Courses.ListCourses();
            var courseVM = Mapper.Map<IEnumerable<ListCourseDto>, IEnumerable<ListCourseVM>>(courseDtos);
            return View("~/Views/Course/ListCourses.cshtml", courseVM);
        }

        [HttpGet]
        [Route("Student/ActiveCourses")]
        [Authorize(Roles = "student")]
        public IActionResult ActiveCourses()
        {
            var studentId = User.Identity.Name;
            var listCourseDtos = Students.GetActiveCoursesForStudent(studentId);
            var listCourseVM = Mapper.Map<IEnumerable<ListCourseDto>, IEnumerable<ListCourseVM>>(listCourseDtos);
            return View(listCourseVM);
        }

        [HttpGet]
        [Route("Student/FinishedCourses")]
        [Authorize(Roles = "student")]
        public IActionResult FinishedCourses()
        {
            var studentId = User.Identity.Name;
            var listCourseDtos = Students.GetFinishedCoursesForStudent(studentId);
            var listCourseVM = Mapper.Map<IEnumerable<ListCourseDto>, IEnumerable<ListCourseVM>>(listCourseDtos);
            return View(listCourseVM);
        }

        [HttpGet]
        [Route("Student/CourseMaterials/{id:int?}")]
        [Authorize(Roles = "student")]
        public IActionResult CourseMaterials(int? id)
        {
            var materialDtos = Materials.GetCourseMaterials(id);
            var materialsVM = Mapper.Map<IEnumerable<MaterialDto>, IEnumerable<MaterialVM>>(materialDtos);
            return View(materialsVM);
        }

        [HttpGet]
        [Route("Student/Download/{id:int?}")]
        [Authorize(Roles = "student")]
        public IActionResult Download(string url,MaterialType type)
        {
            //Materyal türü Url linki mi
            if (type == MaterialType.Link)
            {
                //Link doğru mu
                if (url.UrlIsWebAddress())
                {
                    return Redirect(url);
                }
                else
                {
                    return Content("Adres doğru bir formatta değildi.", "text/html");
                }
            }
            else
            {                
                var fileVirtualPath = Path.Combine("~/materials", url);
                return File(fileVirtualPath, type.GetContentTypeFromFileName());
            }

        }

    }
}
