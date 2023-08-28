using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public class PatientSearchFilters
    {
        [StringLength(100)]
        public string? Name { get; set; }
        public int? FileNo { get; set; }
        [Phone (ErrorMessage = "Not Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}
