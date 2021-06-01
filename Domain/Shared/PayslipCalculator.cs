using System;
using System.Collections.Generic;
using static Domain.Enums.PayslipEnums;
using static StoneChallenge_Payslip.Domain.Payslip;

namespace Domain.Shared
{
    public static class PayslipCalculator
    {
        public static ICollection<Entry> Entries(double salary, bool hasHealthPlan, bool hasDentalPlan, bool hasCommuterBenefits)
        {
            ICollection<Entry> entries = new List<Entry>();

            entries.Add(new Entry(EntryType.Remuneration, salary, "Salário Bruto"));

            DiscountOptionalBenefits(entries, salary, hasHealthPlan, hasDentalPlan, hasCommuterBenefits);

            DiscountLegalBenefits(entries, salary);

            DiscountLegalTaxes(entries, salary);

            return entries;
        }

        private static void DiscountLegalTaxes(ICollection<Entry> entries, double salary)
        {
            entries.Add(new Entry(EntryType.Discount, LegalCalculator.CalculateINSS(salary), "INSS"));
            entries.Add(new Entry(EntryType.Discount, LegalCalculator.CalculateIRRF(salary), "Imposto Retido na Fonte"));
        }

        private static void DiscountLegalBenefits(ICollection<Entry> entries, double salary)
        {
            entries.Add(new Entry(EntryType.Discount, LegalCalculator.CalculateFGTS(salary), "FGTS"));
        }

        private static void DiscountOptionalBenefits(ICollection<Entry> entries, double salary, bool hasHealthPlan, bool hasDentalPlan, bool hasCommuterBenefits)
        {
            if (hasHealthPlan)
                entries.Add(new Entry(EntryType.Discount, BenefitsCalculator.CalculateHealthPlanDeduction(), "Plano de Saúde"));

            if (hasDentalPlan)
                entries.Add(new Entry(EntryType.Discount, BenefitsCalculator.CalculateDentalPlanDeduction(), "Plano Dental"));

            if (hasCommuterBenefits && salary >= 1500)
                entries.Add(new Entry(EntryType.Discount, BenefitsCalculator.CalculateCommuterBenefitsDeduction(salary), "Vale Transporte"));
        }

        public static double CalculateProportionalSalary(double salary, DateTime admission)
        {
            int daysInMonth = DateTime.DaysInMonth(admission.Year, admission.Month);
            double salaryDay = salary / daysInMonth;

            return Math.Round(salaryDay * (daysInMonth - admission.Day + 1), 2);
        }
    }
}
