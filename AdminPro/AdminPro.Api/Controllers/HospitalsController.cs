using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPro.Api.Interfaces;
using AdminPro.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalViewModelService _hospitalViewModelService;

        public HospitalsController(IHospitalViewModelService hospitalViewModelService)
        {
            _hospitalViewModelService = hospitalViewModelService ?? throw new ArgumentNullException(nameof(hospitalViewModelService));
        }
        // GET
        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            var result = await _hospitalViewModelService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospital(Guid id)
        {
            var result = await _hospitalViewModelService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHospital(Guid id, [FromBody] HospitalViewModel hospitalViewModel)
        {
            var existsHospital = await _hospitalViewModelService.ExistsHospital(id);

            if (existsHospital)
            {
                return NotFound();
            }

            await _hospitalViewModelService.Update(id, hospitalViewModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var existsHospital = await _hospitalViewModelService.ExistsHospital(id);

            if (existsHospital)
            {
                return NotFound();
            }

            await _hospitalViewModelService.Delete(id);

            return NoContent();
        }
    }
}
