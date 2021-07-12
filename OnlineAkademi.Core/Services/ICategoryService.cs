using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();

        void AddCategory(CategoryDto categoryDto);

        CategoryDto GetCategoryById(string categoryId,bool isTracking=true);

        void UpdateCategory(CategoryDto categoryDto);

        void DeleteCategory(string categoryId);
    }
}
