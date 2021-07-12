using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class TrainerMapper:Profile
    {
        public TrainerMapper()
        {
            //Entity To Dto
            CreateMap<Trainer, TrainerDto>();

            //Dto to Entity
            CreateMap<TrainerDto, Trainer>();
        }
    }
}
