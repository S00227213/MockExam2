using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rad301_Mock_Exam_2023_DataModel_S00227213
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string TicketType { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TicketPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal BaggageCharge { get; set; }

        // Foreign key to associate with Flight
        public int FlightId { get; set; }
        public Flight Flight { get; set; } // Navigation property
    }
}
