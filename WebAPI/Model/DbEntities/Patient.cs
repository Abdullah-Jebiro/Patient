
using System.ComponentModel.DataAnnotations;

namespace Model.DbEntities
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int FileNo { get; set; }
        [StringLength(20)]
        public string CitizenId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(100)]
        public string Street { get; set; }
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string Address2 { get; set; } = string.Empty;
        [StringLength(100)]
        public string ContactPerson { get; set; }
        [StringLength(50)]
        public string ContactRelation { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        public DateTime FirstVisitDate { get; set; }
        public DateTime RecordCreationDate { get; set; } = DateTime.UtcNow;
    }
}