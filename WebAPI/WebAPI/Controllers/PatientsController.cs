using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DbEntities;
using Model.Dtos;
using Services;
using System.Net;
using System.Reflection.Emit;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepo patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult> GetPatients(
            string? name,
            int? fileNo,
            string? phoneNumber,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var (patients, paginationData) = await _patientRepo.GetAllAsync(pageNumber, pageSize, name, fileNo, phoneNumber);

            //TODO
            if (patients.Count() == 0)
            {
               return NotFound();
            }

            Response.Headers.Add("x-pagination", paginationData.ToString());

            return Ok(patients);
        }


        [HttpGet("{patientId}")]
        public async Task<ActionResult> GetPatient(Guid patientId)
        {
            var patient = await _patientRepo.GetByIdAsync(patientId);
            if(patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


        [HttpPost]
        public async Task<ActionResult> Create(PatientForAddDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _patientRepo.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.Id }, patient.Id);

        }


        [HttpPut]
        public async Task<ActionResult> Update(PatientForUpdateDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _patientRepo.UpdateAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.Id }, patient);
        }

        [HttpDelete("{patientId}")]
        public async Task<ActionResult> Delete(Guid patientId)
        {
            await _patientRepo.DeleteAsync(patientId);
            return NoContent();
        }
    }
}
