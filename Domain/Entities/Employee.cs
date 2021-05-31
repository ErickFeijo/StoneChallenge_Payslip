using System;
using System.Collections.Generic;

namespace WarzoneLobbyOrganizer.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime Admission { get; set; }
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool CommuterBenefits { get; set; }
            
    }
    
}