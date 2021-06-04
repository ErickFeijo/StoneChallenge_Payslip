using Domain.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using StoneChallenge_Payslip.Domain.Entities;
using static Domain.Enums.PayslipEnums;

namespace StoneChallenge_Payslip.Domain.Entities
{
    public class Payslip
    {
        public Payslip(Employee employee, DateTime referenceDate)
        {
            referenceDate = new DateTime(referenceDate.Year, referenceDate.Month, 1);

            if (new DateTime(employee.Admission.Year, employee.Admission.Month, 1) > referenceDate)
                throw new ArgumentException("The employee was hired after the reference month.");

            this.Salary = PayslipCalculator.CalculateSalary(employee.Salary, employee.Admission, referenceDate);
            this.Entries = PayslipCalculator.GetEntries(this.Salary, employee.HealthPlan, employee.DentalPlan, employee.CommuterBenefits);

            this.NetSalary = Math.Round(this.Entries.Sum(x => x.Amount), 2);
            this.Deduction = Math.Round(this.NetSalary - this.Salary, 2);
            this.Month = referenceDate.ToString("MM/yyyy");
        }

        public string Month { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public double Salary { get; set; }
        public double Deduction { get; set; }
        public double NetSalary { get; set; }

        public class Entry
        {
            public Entry(EntryType type, double amount, string description)
            {
                this.Type = type;
                this.Description = description;

                amount = Math.Abs(amount);
                if (this.Type == EntryType.Discount)
                    amount *= -1;

                this.Amount = amount;
            }
            public EntryType Type { get; }
            public double Amount { get; }
            public string Description { get; }

        }

    }

}