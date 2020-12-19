using System.ComponentModel.DataAnnotations.Schema;

namespace StudyOn.Contracts.Models
{
    [Table("images")]
    public class Images
    {
        public decimal Id { get; set; }
        public decimal CourtId { get; set; }
        public string ImagePath { get; set; }

        public virtual Courts Court { get; set; }
    }
}
