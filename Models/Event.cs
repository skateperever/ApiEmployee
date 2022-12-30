using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEmployee.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [MaxLength(6)]
        public string EventCode { get; set; } = string.Empty;
        [MaxLength(100)]
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName = "Deciaml(18,2)")]
        public decimal Fees { get; set; }
        public int SeatsFi11ed { get; set; }
        [MaxLength(200)]
        public string Logo { get; set; } = string.Empty;
    }
}
