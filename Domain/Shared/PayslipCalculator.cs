using System;
using System.Collections.Generic;
using static Domain.Enums.PayslipEnums;
using static StoneChallenge_Payslip.Domain.Entities.Payslip;

namespace Domain.Shared
{
    public static class PayslipCalculator
    {
        public static ICollection<Entry> GetEntries(double salary, bool hasHealthPlan, bool hasDentalPlan, bool hasCommuterBenefits)
        {
            ICollection<Entry> entries = new List<Entry>();
            entries.Add(new Entry(EntryType.Remuneration, salary, EntryDescriptions[EntryName.Salary]));

            DiscountOptionalBenefits(entries, salary, hasHealthPlan, hasDentalPlan, hasCommuterBenefits);

            DiscountLegalBenefits(entries, salary);

            DiscountLegalTaxes(entries, salary);

            return entries;
        }

        private static void DiscountLegalTaxes(ICollection<Entry> entries, double salary)
        {
            entries.Add(new Entry(EntryType.Discount, LegalCalculator.CalculateINSS(salary), EntryDescriptions[EntryName.INSS]));
            entries.Add(new Entry(EntryType.Discount, LegalCalculator.CalculateIRRF(salary), EntryDescriptions[EntryName.IRRF]));
        }

        private static void DiscountLegalBenefits(ICollection<Entry> entries, double salary)
        {
            entries.Add(new Entry(EntryType.Discount, LegalCalculator.CalculateFGTS(salary), EntryDescriptions[EntryName.FGTS]));
        }

        private static void DiscountOptionalBenefits(ICollection<Entry> entries, double salary, bool hasHealthPlan, bool hasDentalPlan, bool hasCommuterBenefits)
        {
            if (hasHealthPlan)
                entries.Add(new Entry(EntryType.Discount, BenefitsCalculator.CalculateHealthPlanDeduction(), EntryDescriptions[EntryName.HealthPlan]));

            if (hasDentalPlan)
                entries.Add(new Entry(EntryType.Discount, BenefitsCalculator.CalculateDentalPlanDeduction(), EntryDescriptions[EntryName.DentalPlan]));

            if (hasCommuterBenefits && salary >= 1500)
                entries.Add(new Entry(EntryType.Discount, BenefitsCalculator.CalculateCommuterBenefitsDeduction(salary), EntryDescriptions[EntryName.CommuterBenefits]));
        }

        public static double CalculateProportionalSalary(double salary, DateTime admission)
        {
            int daysInMonth = DateTime.DaysInMonth(admission.Year, admission.Month);
            double salaryDay = salary / daysInMonth;

            return Math.Round(salaryDay * (daysInMonth - admission.Day + 1), 2);
        }

        public static double CalculateSalary(double salary, DateTime admission, DateTime referenceDate)
        {
            if (new DateTime(admission.Year, admission.Month, 1) == new DateTime(referenceDate.Year, referenceDate.Month, 1) && admission.Day != 1)
                return CalculateProportionalSalary(salary, admission);
            else
                return salary;
        }

    }
}
