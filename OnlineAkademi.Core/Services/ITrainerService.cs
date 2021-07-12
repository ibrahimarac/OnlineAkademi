using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface ITrainerService
    {
        //trainerId olarak kullanıcı adı kullanılıyor

        Task<IEnumerable<TrainerDto>> GetAllTrainers();

        void AddTrainer(TrainerDto trainerDto);

        TrainerDto GetTrainerById(string trainerId,bool isTracking=true);

        void UpdateTrainer(TrainerDto trainerDto);

        void DeleteTrainer(string trainerId);

        Task<IEnumerable<CourseDto>> GetCoursesNoTrainer(string trainerId);

        bool AddTrainerToCourse(string trainerId, int courseId);

        bool RemoveTrainerFromCourse(string trainerId, int courseId);


    }
}
