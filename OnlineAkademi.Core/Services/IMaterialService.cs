using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface IMaterialService
    {
        IEnumerable<CourseDto> GetCourseByTrainer(string userName);

        IEnumerable<MaterialDto> GetCourseMaterials(int? courseId);

        void DeleteMaterial(string id);

        string GetFileUrl(string id);

        void AddMaterial(MaterialDto materialDto);

    }
}
