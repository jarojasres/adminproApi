using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.ViewModels;

namespace AdminPro.Api.Interfaces
{
    public interface IUserViewModelService
    {
        Task<IEnumerable<UserViewModel>> GetAll();

        Task<UserViewModel> GetById(Guid id);

        Task Update(Guid id, UserForUpdateViewModel userViewModel);

        Task<bool> ExistsUser(Guid id);
    }
}
