using Data;
using Microsoft.EntityFrameworkCore;
using Model.DbEntities;
using Model.Dtos;
using Model.Pagination;
using System.Linq;

namespace Services
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
           _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var patient =await _context.Patients.FindAsync(Id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<(IEnumerable<Patient>, PaginationMetaData)> GetAllAsync(int pageNumber,
            int pageSize,
            PatientSearchFilters searchFilters)
        {

            var patientsQuery = _context.Patients as IQueryable<Patient>;

            if (!string.IsNullOrEmpty(searchFilters.Name))
            {
                var nameLower = searchFilters.Name.ToLower();
                patientsQuery = patientsQuery.Where(c => c.Name.ToLower().Contains(nameLower));
            }

            if (searchFilters.FileNo.HasValue)
            {
                patientsQuery = patientsQuery.Where(c => c.FileNo == searchFilters.FileNo);
            }


            if (!string.IsNullOrEmpty(searchFilters.PhoneNumber))
            {
                patientsQuery = patientsQuery.Where(c => c.PhoneNumber.Contains(searchFilters.PhoneNumber));
            }

            var result = await patientsQuery
                .OrderByDescending(c => c.RecordCreationDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Calculate the total count of patients after applying filters for pagination
            var totalCourses = await patientsQuery.CountAsync();

            var paginationMetaData = new PaginationMetaData(totalCourses, pageSize, pageNumber);
            return (result, paginationMetaData);
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            var result = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
