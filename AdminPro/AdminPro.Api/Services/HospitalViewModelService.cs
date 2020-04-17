﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.Interfaces;
using AdminPro.Api.ViewModels;
using AdminPro.Core.Entities;
using AdminPro.Core.Interfaces;
using AutoMapper;

namespace AdminPro.Api.Services
{
    public class HospitalViewModelService : IHospitalViewModelService
    {
        private readonly IAsyncRepository<Hospital> _hospitalRepository;
        private readonly IMapper _mapper;

        public HospitalViewModelService(IAsyncRepository<Hospital> hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        public async Task Delete(Guid id)
        {
            var hospital = new Hospital()
            {
                Id = id
            };
            await _hospitalRepository.DeleteAsync(hospital);
        }

        public async Task<IEnumerable<HospitalViewModel>> GetAll()
        {
            var hospitals = await _hospitalRepository.ListAllAsync();
            var hospitalViewModels = _mapper.Map<IEnumerable<Hospital>, IEnumerable<HospitalViewModel>>(hospitals);

            return hospitalViewModels;
        }

        public async Task<HospitalViewModel> GetById(Guid id)
        {
            var hospital = await _hospitalRepository.GetByIdAsync(id);
            var hospitalViewModel = _mapper.Map<Hospital, HospitalViewModel>(hospital);

            return hospitalViewModel;
        }

        public async Task Update(Guid id, HospitalViewModel hospitalViewModel)
        {
            var hospital = _mapper.Map<HospitalViewModel, Hospital>(hospitalViewModel);
            hospital.Id = id;

            await _hospitalRepository.UpdateAsync(hospital);
        }

        public async Task<bool> ExistsHospital(Guid id)
        {
            var exists = await _hospitalRepository.ExistsAsync(id);
            return exists;
        }
    }
}