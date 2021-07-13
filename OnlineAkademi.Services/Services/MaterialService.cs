using AutoMapper;
using OnlineAkademi.Core;
using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Services.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitWork Database;
        private readonly IMapper Mapper;

        public MaterialService(IUnitWork uWork, IMapper mapper)
        {
            Database = uWork;
            Mapper = mapper;
        }

        public void AddMaterial(MaterialDto materialDto)
        {
            var material = Mapper.Map<MaterialDto, CourseMaterial>(materialDto);
            Database.MaterialRepo.Insert(material);
            Database.Commit();
        }

        public void DeleteMaterial(string id)
        {
            if (id==null)
                throw new ParameterException("Id", "Material", "Silinecek materyal numarası gönderilmedi.");
            var material = Database.MaterialRepo.GetById(int.Parse(id));
            if (material == null)
                throw new ParameterException("Id", "Material", "Gönderilen materyal numarası geçerli değil.");

            Database.MaterialRepo.Delete(material);
            Database.Commit();
        }

        public IEnumerable<CourseDto> GetCourseByTrainer(string userName)
        {
            var courses = Database.CourseRepo.GetByFilter(c => c.TrainerId == userName);
            var courseDtos = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
            return courseDtos;
        }

        public IEnumerable<MaterialDto> GetCourseMaterials(int? courseId)
        {
            if (!courseId.HasValue)
                throw new ParameterException("Id", "Course", "Kurs numarası gönderilmedi.");
            var course = Database.CourseRepo.GetById(courseId.Value);
            if (course == null)
                throw new ParameterException("Id", "Course", "Böyle bir kurs kayıtlı değil.");

            var materials = Database.MaterialRepo.GetByFilter(m => m.CourseId == courseId,false);
            var materialDtos = Mapper.Map<IEnumerable<CourseMaterial>, IEnumerable<MaterialDto>>(materials);
            return materialDtos;
        }

        public string GetFileUrl(string id)
        {
            if (id == null)
                throw new ParameterException("Id", "Material", "Silinecek materyal numarası gönderilmedi.");
            var material = Database.MaterialRepo.GetById(int.Parse(id));
            if (material == null)
                throw new ParameterException("Id", "Material", "Gönderilen materyal numarası geçerli değil.");
            return material.Url;
        }
    }
}
