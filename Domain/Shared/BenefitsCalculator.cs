using System;

namespace Domain.Shared
{
    public static class BenefitsCalculator
    {
        public static double CalculateCommuterBenefitsDeduction(double salary)
        {
            return Math.Round((salary * (double)0.06), 2);
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
