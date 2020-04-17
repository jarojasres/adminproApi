using System;
using System.Threading.Tasks;
using AdminPro.Api.Interfaces;
using AdminPro.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdminPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserViewModelService _userViewModelService;

        public UsersController(IUserViewModelService userViewModelService)
        {
            _userViewModelService = userViewModelService ?? throw new ArgumentNullException(nameof(userViewModelService));
        }
        // GET
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userViewModelService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _userViewModelService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Updating all user properties is not allowed    
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateViewModel userViewModel)
        {
            var user = _userViewModelService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userViewModelService.Update(id, userViewModel);

            return NoContent();
        }
    }
}