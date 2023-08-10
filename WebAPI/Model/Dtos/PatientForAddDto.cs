using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public class PatientForAddDto
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "File number must be greater than 0")]
        public int FileNo { get; set; }

        [StringLength(20)]
        public string CitizenId { get; set; } = null!;

        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime BirthDate { get; set; }

        [Range(0, 1, ErrorMessage = "Gender must be either 0 (Male) or 1 (Female)")]
        public int Gender { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; } = null!;

        [StringLength(15)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(50)]
        public string Country { get; set; } = null!;

        [StringLength(50)]
        public string City { get; set; } = null!;

        [StringLength(100)]
        public string Street { get; set; } = null!;

        [StringLength(100)]
        public string Address1 { get; set; } = null!;

        [StringLength(100)]
        public string? Address2 { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; } = null!;

        [StringLength(50)]
        public string ContactRelation { get; set; } = null!;

        [StringLength(15)]
        [Phone]
        public string ContactPhone { get; set; } = null!;

        [Required(ErrorMessage = "First visit date is required")]
        public DateTime FirstVisitDate { get; set; }

    }
}
