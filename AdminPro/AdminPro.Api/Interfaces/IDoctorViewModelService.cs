using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.ViewModels;

namespace AdminPro.Api.Interfaces
{
    public interface IDoctorViewModelService
    {
        Task<Guid> Create(DoctorViewModel doctorViewModel);
        Task Delete(Guid id);
        Task<IEnumerable<DoctorInformationViewModel>> GetAll();

        Task<DoctorInformationViewModel> GetById(Guid id);

        Task Update(Guid id, DoctorViewModel doctorViewModel);

        Task<bool> ExistsDoctor(Guid id);

    }
}
