using System;
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
    public class DoctorViewModelService : IDoctorViewModelService
    {
        private readonly IAsyncRepository<Doctor> _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorViewModelService(IAsyncRepository<Doctor> doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorInformationViewModel>> GetAll()
        {
            var doctors = await _doctorRepository.ListAllAsync(x => x.Hospital,  x => x.User);
            var doctorsViewModel = _mapper.Map<IEnumerable<DoctorInformationViewModel>>(doctors);

            return doctorsViewModel;
        }

        public async Task<DoctorInformationViewModel> GetById(Guid id)
        {
            var doctors = await _doctorRepository.GetAsync(x => x.Id == id, null, x=> x.User, x => x.Hospital);
            var doctorViewModel = _mapper.Map<DoctorInformationViewModel>(doctors.FirstOrDefault());
            return doctorViewModel;
        }

        public async Task Update(Guid id, DoctorViewModel doctorViewModel)
        {
            var doctor = _mapper.Map<DoctorViewModel, Doctor>(doctorViewModel);
            doctor.Id = id;


            await _doctorRepository.UpdateAsync(doctor);

        }

        public async Task<bool> ExistsDoctor(Guid id)
        {
            var exists = await _doctorRepository.ExistsAsync(id);
            return exists;
        }

        public async Task Delete(Guid id)
        {
            var doctor = new Doctor
            {
                Id = id
            };

            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task<Guid> Create(DoctorViewModel doctorViewModel)
        {
            var doctor = _mapper.Map<DoctorViewModel, Doctor>(doctorViewModel);
            var doctorDb = await _doctorRepository.AddAsync(doctor);
            return doctorDb.Id;
        }
    }
}
