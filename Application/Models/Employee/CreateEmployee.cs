using System;
using System.Collections.Generic;

namespace StoneChallenge_Payslip.Application.Models
{
    public class CreateEmployee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime Admission { get; set; }
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool CommuterBenefits { get; set; }

    }

}
