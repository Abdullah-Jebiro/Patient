using Model.DbEntities;
using Model.Pagination;
using System.Linq.Expressions;

namespace Services
{
    public interface IPatientRepo
    {
        Task<Patient?> GetByIdAsync(Guid id);
        Task<(IEnumerable<Patient>, PaginationMetaData)> GetAllAsync(
            int pageNumber,
            int pageSize,
            string? name,
            int? fileNo,
            string? phoneNumber);
        //TODO
        Task AddAsync(Patient entity);
        Task UpdateAsync(Patient entity);
        Task DeleteAsync(Guid id);



    }
}