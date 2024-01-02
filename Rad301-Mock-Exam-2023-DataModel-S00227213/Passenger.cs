using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_Mock_Exam_2023_DataModel_S00227213
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string TicketType { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal BaggageCharge { get; set; }
        public int FlightId { get; set; }

        // Navigation property for related Flight
        public Flight Flight { get; set; }
    }

}
