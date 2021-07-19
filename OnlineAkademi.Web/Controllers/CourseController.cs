using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Utils.Extensions;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService Courses;
        private readonly ICategoryService Categories;
        private readonly IMapper Mapper;

        public CourseController(ICourseService courseService,
            ICategoryService categoryService, 
            IMapper mapper)
        {
            Courses = courseService;
            Categories = categoryService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("Course/List")]
        public async Task<IActionResult> List()
        {
            //Dto to VM
            var courseDtos = await Courses.GetCourseWithCourseName();
            var categoryVM = Mapper.Map<IEnumerable<CourseDto>, IEnumerable<CourseVM>>(courseDtos);
            return View(categoryVM);
        }

        async Task PopulateCategories()
        {
            var categoryDtos = await Categories.GetAllCategories();
            //categoryDtos.Insert(0, new CategoryDto { Id = 0, Name = "Seçiniz" });
            ViewBag.Categories = categoryDtos.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        [HttpGet]
        [Route("Course/Create")]
        public async Task<IActionResult> Create()
        {
            await PopulateCategories();
            return View();
        }

        [HttpPost]
        [Route("Course/Create")]
        public async Task<IActionResult> Create(CourseVM courseVM)
        {
            //Validation kontrolünü yapalım
            if (!ModelState.IsValid)
            {
                await PopulateCategories();
                return View(courseVM);
            }

            //VM to Dto
            var courseDto = Mapper.Map<CourseVM, CourseDto>(courseVM);

            Courses.AddCourse(courseDto);

            return RedirectToAction("List")
                .ShowMessage(JConfirmMessageType.Success, "Başarılı", "<b>Kurs</b> başarıyla eklendi.");
        }

        [HttpGet]
        [Route("Course/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            await PopulateCategories();
            var courseDto = Courses.GetCourseById(id);
            var courseVM = Mapper.Map<CourseDto, CourseVM>(courseDto);
            return View(courseVM);
        }

        [HttpPost]
        [Route("Course/Edit")]
        public async Task<IActionResult> Edit(CourseVM courseVM)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategories();
                return View(courseVM)
                    .ShowMessage(JConfirmMessageType.Warning, "Uyarı", "Bazı hatalar var");
            }

            var courseDto = Courses.GetCourseById(courseVM.Id, isTracking: false);
            courseDto.Name = courseVM.Name;
            courseDto.CategoryId = courseVM.CategoryId.Value;
            courseDto.Duration = courseVM.Duration;
            courseDto.Price = courseVM.Price;
            courseDto.Quota = courseVM.Quota;
            courseDto.StartDate = courseVM.StartDate;
            courseDto.EndDate = courseVM.EndDate;
            courseDto.IsActive = courseVM.IsActive;

            Courses.UpdateCourse(courseDto);

            return RedirectToAction("List")
                .ShowMessage(JConfirmMessageType.Success, "İşlem başarılı", "Kurs başarıyla güncellendi");
        }

        [HttpGet]
        [Route("Course/ListCourses")]
        [AllowAnonymous]
        public async Task<IActionResult> ListCourses()
        {
            //Oturum açan bir öğrenci için kurs listesi hazırlanıyorsa
            //öğrencinin kayıtlı olduğu kursları ona göstermeyelim.
            IEnumerable<ListCourseDto> courseDtos = null;
            if (User.IsInRole("student"))
            {
                courseDtos=await Courses.ListCourses(User.Identity.Name);
            }
            else
            {
                courseDtos = await Courses.ListCourses();
            }

            var courseVM= Mapper.Map<IEnumerable<ListCourseDto>, IEnumerable<ListCourseVM>>(courseDtos);
            return View(courseVM);
        }

        [HttpGet]
        [Route("Course/{name}/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> CourseDetail(int id,string name)
        {
            var courseDto = await Courses.GetCourseDetail(id);
            var courseVM = Mapper.Map<ListCourseDto, ListCourseVM>(courseDto);
            return View(courseVM);
        }

        [HttpPost]
        [Route("Course/Delete")]
        public IActionResult Delete([Bind("Id")] JQueryDeleteObject model)
        {
            Courses.DeleteCourse(model.Id);

            return Json(new JsonResponse
            {
                Status = JsonResponseStatus.Ok,
                Message = "Kurs başarıyla silindi"
            });
        }

    }
}
