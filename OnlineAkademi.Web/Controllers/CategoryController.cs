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
using Microsoft.AspNetCore.Authorization;

namespace OnlineAkademi.Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService Categories;
        private readonly IMapper Mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            Categories = categoryService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("Category/List")]
        public async Task<IActionResult> List()
        {
            //Dto to VM
            var categoryDtos = await Categories.GetAllCategories();
            var categoryVM = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryVM>>(categoryDtos);
            return View(categoryVM);
        }

        [HttpGet]
        [Route("Category/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Category/Create")]
        public IActionResult Create(CategoryVM categoryVM)
        {
            //Validation kontrolünü yapalım
            if (!ModelState.IsValid)
                return View(categoryVM);

            //VM to Dto
            var categoryDto = Mapper.Map<CategoryVM, CategoryDto>(categoryVM);

            Categories.AddCategory(categoryDto);
                       
            return RedirectToAction("List")
                .ShowMessage(JConfirmMessageType.Success,"Başarılı", "<b>Kategori</b> başarıyla eklendi.");
        }

        [HttpGet]
        [Route("Category/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var categoryDto = Categories.GetCategoryById(id);
            var categoryVM = Mapper.Map<CategoryDto, CategoryVM>(categoryDto);
            return View(categoryVM);
        }

        [HttpPost]
        [Route("Category/Edit")]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVM)
                    .ShowMessage(JConfirmMessageType.Warning,"Uyarı","Bazı hatalar var");                
            }
                

            var categoryDto = Categories.GetCategoryById(categoryVM.Id,isTracking:false);
            categoryDto.Name = categoryVM.Name;
            categoryDto.IsActive = categoryVM.IsActive;
           
            Categories.UpdateCategory(categoryDto);

            return RedirectToAction("List")
                .ShowMessage(JConfirmMessageType.Success,"İşlem başarılı","Kategori başarıyla güncellendi");
        }

        [HttpPost]
        [Route("Category/Delete")]
        public IActionResult Delete([FromBody]JQueryDeleteObject category)
        {
            Categories.DeleteCategory(category.Id);

            return Json(new JsonResponse { 
                Status=JsonResponseStatus.Ok,
                Message="Kategori başarıyla silindi"
            });
        }

        

    }
}
