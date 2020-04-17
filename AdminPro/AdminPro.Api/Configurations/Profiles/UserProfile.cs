using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.ViewModels;
using AdminPro.Core.Entities;
using AutoMapper;

namespace AdminPro.Api.Configurations.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
