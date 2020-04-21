using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.ViewModels;

namespace AdminPro.Api.Interfaces
{
    public interface IHospitalViewModelService
    {
        Task<Guid> Create(HospitalViewModel hospitalViewModel);
        Task Delete(Guid id);
        Task<IEnumerable<HospitalInformationViewModel>> GetAll();

        Task<HospitalInformationViewModel> GetById(Guid id);

        Task Update(Guid id, HospitalViewModel hospitalViewModel);

        Task<bool> ExistsHospital(Guid id);
    }
}
