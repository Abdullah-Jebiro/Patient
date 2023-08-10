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



        /// <summary>
        /// Retrieves a list of patients with optional filters and pagination.
        /// </summary>
        /// <param name="name">Optional: Filter by patient name.</param>
        /// <param name="fileNo">Optional: Filter by file number.</param>
        /// <param name="phoneNumber">Optional: Filter by phone number.</param>
        /// <param name="pageNumber">The page number for pagination. Default is 1.</param>
        /// <param name="pageSize">The number of items per page. Default is 10.</param>
        /// <returns>A paginated list of patients.</returns>
        [HttpGet]
        public async Task<ActionResult> GetPatients(
            string? name,
            int? fileNo,
            string? phoneNumber,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var (patients, paginationData) = await _patientRepo.GetAllAsync(pageNumber, pageSize, name, fileNo, phoneNumber);

            if (!patients.Any())
            {
                return NotFound();
            }

            Response.Headers.Add("x-pagination", paginationData.ToString());

            return Ok(patients);
        }



        /// <summary>
        /// Retrieves a specific patient by their ID.
        /// </summary>
        /// <param name="patientId">The ID of the patient to retrieve.</param>
        /// <returns>The requested patient.</returns>
        [HttpGet("{patientId}")]
        public async Task<ActionResult> GetPatient(Guid patientId)
        {
            var patient = await _patientRepo.GetByIdAsync(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="dto">The data for creating the patient.</param>
        /// <returns>The created patient.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(PatientForAddDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _patientRepo.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.Id }, patient);
        }

        /// <summary>
        /// Updates an existing patient.
        /// </summary>
        /// <param name="dto">The data for updating the patient.</param>
        /// <returns>The updated patient.</returns>
        [HttpPut]
        public async Task<ActionResult> Update(PatientForUpdateDto dto)
        {
            var patient = await _patientRepo.GetByIdAsync(dto.Id);
            if (patient == null)
            {
                return NotFound();
            }
            _mapper.Map(dto,patient);
            await _patientRepo.UpdateAsync(patient);
            return Ok(patient);
        }

        /// <summary>
        /// Deletes a patient.
        /// </summary>
        /// <param name="patientId">The ID of the patient to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{patientId}")]
        public async Task<ActionResult> Delete(Guid patientId)
        {
            await _patientRepo.DeleteAsync(patientId);
            return NoContent();
        }
    }
}
