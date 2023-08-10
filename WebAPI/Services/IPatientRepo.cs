using Model.DbEntities;
using Model.Pagination;
using System.Linq.Expressions;

namespace Services
{
    public interface IPatientRepo
    {
        /// <summary>
        /// Retrieves a specific patient by their ID.
        /// </summary>
        /// <param name="id">The ID of the patient to retrieve.</param>
        /// <returns>The requested patient.</returns>
        Task<Patient?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves a list of patients with optional filters and pagination.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="name">Optional: Filter by patient name.</param>
        /// <param name="fileNo">Optional: Filter by file number.</param>
        /// <param name="phoneNumber">Optional: Filter by phone number.</param>
        /// <returns>A paginated list of patients.</returns>
        Task<(IEnumerable<Patient>, PaginationMetaData)> GetAllAsync(
            int pageNumber,
            int pageSize,
            string? name,
            int? fileNo,
            string? phoneNumber);

        /// <summary>
        /// Adds a new patient to the repository.
        /// </summary>
        /// <param name="entity">The patient entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(Patient entity);

        /// <summary>
        /// Updates an existing patient in the repository.
        /// </summary>
        /// <param name="entity">The patient entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Patient entity);

        /// <summary>
        /// Deletes a patient from the repository.
        /// </summary>
        /// <param name="id">The ID of the patient to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);
    }
}