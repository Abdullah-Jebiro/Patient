using Data;
using Microsoft.EntityFrameworkCore;
using Model.DbEntities;
using Model.Pagination;

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

        public async Task<(IEnumerable<Patient>, PaginationMetaData)> GetAllAsync(
            int pageNumber,
            int pageSize,
            string? name,
            int? fileNo,
            string? phoneNumber
        )
        {

            var patientsQuery = _context.Patients as IQueryable<Patient>;

            if (!string.IsNullOrEmpty(name))
            {
                var nameLower = name.ToLower();
                patientsQuery = patientsQuery.Where(c => c.Name.ToLower().Contains(nameLower));
            }

            if (fileNo.HasValue)
            {
                patientsQuery = patientsQuery.Where(c => c.FileNo==fileNo);
            }

            
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                patientsQuery = patientsQuery.Where(c => c.PhoneNumber.Contains(phoneNumber));
            }

            var result = await patientsQuery
                .OrderBy(c => c.RecordCreationDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalCourses = await _context.Patients.CountAsync();
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
