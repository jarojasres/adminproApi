using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.ViewModels;
using AdminPro.Core.Entities;
using AutoMapper;

namespace AdminPro.Api.Configurations.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();
        }
    }
}
