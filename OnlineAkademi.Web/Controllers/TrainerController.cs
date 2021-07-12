using AutoMapper;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Services;
using OnlineAkademi.Utils.Extensions;
using OnlineAkademi.Web.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineAkademi.Core.Domain.Dto.Identity;
using Microsoft.AspNetCore.Http;

namespace OnlineAkademi.Web.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService Trainers;
        private readonly IAccountService Accounts;
        private readonly IMapper Mapper;

        public TrainerController(ITrainerService trainerService,
            IAccountService accounService, IMapper mapper)
        {
            Trainers = trainerService;
            Accounts = accounService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("Trainer/List")]
        public async Task<IActionResult> List()
        {
            //Dto to VM
            var trainerDtos = await Trainers.GetAllTrainers();
            var trainerVM = Mapper.Map<IEnumerable<TrainerDto>, IEnumerable<TrainerVM>>(trainerDtos);
            return View(trainerVM);
        }


        [HttpGet]
        [Route("Trainer/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Trainer/Create")]
        public async Task<IActionResult> Create(TrainerVM trainerVM)
        {
            //Validation kontrolünü yapalım
            if (!ModelState.IsValid)
                return View(trainerVM);

            //Önce eğitmeni Identity tablolarına eklemeye çalışalım
            var userExists = await Accounts.UserExists(trainerVM.UserName);
            if (userExists)
                return View(trainerVM).ShowMessage(JConfirmMessageType.Error, "Hata", "Bu kullanıcı adına sahip bir eğitmen zaten tanımlı.");

            var createTrainerResult = await Accounts.Register(new RegisterDto
            {
                Email = trainerVM.Email,
                Firstname = trainerVM.FirstName,
                Lastname = trainerVM.LastName,
                Password = trainerVM.Password,
                UserName = trainerVM.UserName,
                Gender = trainerVM.Gender
            });
            //IDentity tablosuna ekleme başarılı ise
            //kendi tabloma kullanıcıyı ekliyorum.
            if (createTrainerResult)
            {
                //VM to Dto
                var trainerDto = Mapper.Map<TrainerVM, TrainerDto>(trainerVM);

                Trainers.AddTrainer(trainerDto);
            }
            return RedirectToAction("List")
                    .ShowMessage(JConfirmMessageType.Success, "Başarılı", "<b>Eğitmen</b> başarıyla eklendi.");
        }

        [HttpGet]
        [Route("Trainer/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if(id==null)
                return RedirectToAction("List").ShowMessage(JConfirmMessageType.Error, "Uyarı", "Silinecek eğitmen belirlenemedi");
            var trainerDto = Trainers.GetTrainerById(id);
            var trainerVM = Mapper.Map<TrainerDto, TrainerEditVM>(trainerDto);
            return View(trainerVM);
        }

        [HttpPost]
        [Route("Trainer/Edit")]
        public async Task<IActionResult> Edit(TrainerEditVM trainerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(trainerVM)
                    .ShowMessage(JConfirmMessageType.Warning, "Uyarı", "Bazı hatalar var");
            }

            //identity tarafında gerekli güncellemeyi yapalım
            var result = await Accounts.UpdateUser(new RegisterDto
            {
                Age = trainerVM.Age,
                Email = trainerVM.Email,
                Firstname = trainerVM.FirstName,
                Lastname = trainerVM.LastName,
                UserName = trainerVM.UserName,
                Gender = trainerVM.Gender
            });

            if (result)
            {
                //Güncelleme yapılıyor
                var trainerDto = Trainers.GetTrainerById(trainerVM.UserName, isTracking: false);
                trainerDto.Email = trainerVM.Email;
                trainerDto.FirstName = trainerVM.FirstName;
                trainerDto.LastName = trainerVM.LastName;
                trainerDto.TrainerType = trainerVM.TrainerType.Value;
                trainerDto.Experience = trainerVM.Experience;
                trainerDto.IsActive = trainerVM.IsActive;
                trainerDto.Age = trainerVM.Age;
                trainerDto.Gender = trainerVM.Gender;

                Trainers.UpdateTrainer(trainerDto);
            }

            return RedirectToAction("List")
                    .ShowMessage(JConfirmMessageType.Success, "İşlem başarılı", "Eğitmen başarıyla güncellendi");
        }

        [HttpPost]
        [Route("Trainer/Delete")]
        public async Task<IActionResult> Delete([FromBody] JQueryDeleteObject trainer)
        {
            //Önce Identity'den kullanıcıyı kaldıralım
            var result = await Accounts.DeleteUser(trainer.Id);
            if (!result)
                return Json(new JsonResponse
                {
                    Status = JsonResponseStatus.Error,
                    Message = "Silinecek eğitmene ait kimlik bilgisi geçerli değil."
                });

            Trainers.DeleteTrainer(trainer.Id);

            return Json(new JsonResponse
            {
                Status = JsonResponseStatus.Ok,
                Message = "Kategori başarıyla silindi"
            });
        }


        [HttpGet]
        [Route("Trainer/TrainerCourse/{id}")]
        public async Task<IActionResult> TrainerCourseList(string id)
        {
            if (id == null)
                return RedirectToAction("List").ShowMessage(JConfirmMessageType.Error, "Uyarı", "Eğitmen kmlik no gönderilmedi.");

            //Şu an üzerinde kurs işlemleri yapılan kullanıcıyı Session'da saklayalım.
            HttpContext.Session.SetString("trainer", id);

            var courseDtos= await Trainers.GetCoursesNoTrainer(id);
            var coursesVM = Mapper.Map<IEnumerable<CourseDto>, IEnumerable<CourseTrainerVM>>(courseDtos);
            return View(coursesVM);
        }

        [HttpGet]
        [Route("Trainer/AddCourse/{id}")]
        public IActionResult AddCourse(string id)
        {
            if (id == null)
                return RedirectToAction("List").ShowMessage(JConfirmMessageType.Error, "Uyarı", "Eklenecek kurs numarası bulunamadı.");
            //Kursu eğitmene bağlayalım.
            var trainerId = HttpContext.Session.GetString("trainer");
            Trainers.AddTrainerToCourse(trainerId,int.Parse(id));

            return RedirectToAction("TrainerCourseList", "Trainer",new { id=trainerId});
        }

        [HttpGet]
        [Route("Trainer/RemoveCourse/{id}")]
        public IActionResult RemoveCourse(string id)
        {
            if (id == null)
                return RedirectToAction("List").ShowMessage(JConfirmMessageType.Error, "Uyarı", "Kaldırılacak kurs numarası bulunamadı.");
            //Kursu eğitmenden koparalım.
            var trainerId = HttpContext.Session.GetString("trainer");
            Trainers.RemoveTrainerFromCourse(trainerId, int.Parse(id));

            return RedirectToAction("TrainerCourseList", "Trainer", new { id = trainerId });
        }

    }
}
