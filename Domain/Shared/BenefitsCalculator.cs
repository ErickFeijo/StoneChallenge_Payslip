using System;
using System.Collections.Generic;
using static Domain.Enums.PayslipEnums;
using static WarzoneLobbyOrganizer.Domain.Payslip;

namespace Domain.Shared
{
    public static class BenefitsCalculator
    {
        public static double CalculateCommuterBenefitsDeduction(double salary)
        {
            return (salary * (double)0.06);
        }
        public static double CalculateDentalPlanDeduction()
        {
            return 5;
        }
        public static double CalculateHealthPlanDeduction()
        {
            return 10;
        }
    }
}
