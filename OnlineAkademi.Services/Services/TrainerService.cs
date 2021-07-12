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
    public class TrainerService : ITrainerService
    {
        private readonly IUnitWork Database;
        private readonly IMapper Mapper;

        public TrainerService(IUnitWork uWork, IMapper mapper)
        {
            Database = uWork;
            Mapper = mapper;
        }

        public void AddTrainer(TrainerDto trainerDto)
        {
            var trainer = Mapper.Map<TrainerDto, Trainer>(trainerDto);
            Database.TrainerRepo.Insert(trainer);
            Database.Commit();
        }

        public void DeleteTrainer(string trainerId)
        {
            if (trainerId==null)
                throw new ParameterException("UserName", "Trainer", "Eğitmen numarası geçerli değil.");
            var trainer = Database.TrainerRepo.GetSingle(t => t.UserName == trainerId);
            if (trainer == null)
                throw new ParameterException("UserName", "Trainer", "Belirtilen kullanıcı adına sahip bir eğitmen bulunamadı.");

            Database.TrainerRepo.Delete(trainer);
            Database.Commit();
        }

        public async Task<IEnumerable<TrainerDto>> GetAllTrainers()
        {
            var trainers = await Database.TrainerRepo.GetAllAsync(false);
            var trainerDtos = Mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerDto>>(trainers);
            return trainerDtos;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByTrainer(string trainerId)
        {
            var courses=await Database.TrainerRepo.GetCoursesByTrainer(trainerId);
            var courseDtos = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
            return courseDtos;
        }

        public TrainerDto GetTrainerById(string trainerId, bool isTracking = true)
        {
            if (trainerId==null)
                throw new ParameterException("UserName", "Trainer", "Eğitmen kullanıcı adı gönderilmedi.");
            var trainer = Database.TrainerRepo.GetSingle(t=>t.UserName==trainerId,isTracking);
            if (trainer == null)
                throw new ParameterException("UserName", "Trainer", "Gönderilen kullanıcı adına sahip bir eğitmen bulunamadı.");
            var trainerDto = Mapper.Map<Trainer, TrainerDto>(trainer);
            return trainerDto;
        }

        public void UpdateTrainer(TrainerDto trainerDto)
        {
            if (trainerDto.UserName==null)
                throw new ParameterException("UserName", "Trainer", "Güncellenecek eğitmen kullanıcı adı gönderilmedi.");
            var trainer = Mapper.Map<TrainerDto, Trainer>(trainerDto);
            Database.TrainerRepo.Update(trainer);
            Database.Commit();
        }

    }
}
