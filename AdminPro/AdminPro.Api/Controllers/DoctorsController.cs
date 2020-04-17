using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.Interfaces;
using AdminPro.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorViewModelService _doctorViewModelService;

        public DoctorsController(IDoctorViewModelService doctorViewModelService)
        {
            _doctorViewModelService = doctorViewModelService ?? throw new ArgumentNullException(nameof(doctorViewModelService));
        }
        // GET
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _doctorViewModelService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(Guid id)
        {
            var result = await _doctorViewModelService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorViewModel doctorViewModel)
        {
            var result = await _doctorViewModelService.Create(doctorViewModel);

            return CreatedAtRoute("GetDoctor", new {id = result}, doctorViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] DoctorViewModel doctorViewModel)
        {
            var existsDoctor = await _doctorViewModelService.ExistsDoctor(id);

            if (!existsDoctor)
            {
                return NotFound();
            }

            await _doctorViewModelService.Update(id, doctorViewModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var existsDoctor = await _doctorViewModelService.ExistsDoctor(id);

            if (!existsDoctor)
            {
                return NotFound();
            }

            await _doctorViewModelService.Delete(id);

            return NoContent();
        }
    }
}