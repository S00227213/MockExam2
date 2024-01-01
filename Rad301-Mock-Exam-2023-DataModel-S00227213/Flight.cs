using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rad301_Mock_Exam_2023_DataModel_S00227213
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        // Initialize non-nullable string properties with empty strings
        public string FlightNumber { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Set MaxSeats to a default value, if there's one that makes sense for your context
        public int MaxSeats { get; set; } = 0;

        // Use the DateTime.MinValue to initialize a non-nullable DateTime
        public DateTime DepartureDate { get; set; } = DateTime.MinValue;

        // Initialize the collection to prevent null reference exceptions
        public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}
