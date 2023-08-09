
using System.ComponentModel.DataAnnotations;

namespace Model.DbEntities
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public int FileNo { get; set; }
        [StringLength(20)]
        public string CitizenId { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; } = null!;
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;
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
        public string ContactPhone { get; set; } = null!;
        public DateTime FirstVisitDate { get; set; }
        public DateTime RecordCreationDate { get; set; } = DateTime.UtcNow;
    }
}