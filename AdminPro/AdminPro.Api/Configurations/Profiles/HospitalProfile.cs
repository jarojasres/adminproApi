using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.ViewModels;
using AdminPro.Core.Entities;
using AutoMapper;

namespace AdminPro.Api.Configurations.Profiles
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<Hospital, HospitalViewModel>().ReverseMap();
            
            CreateMap<Hospital, HospitalInformationViewModel>();
            CreateMap<Hospital, AssociatedHospitalViewModel>();

        }
    }
}
