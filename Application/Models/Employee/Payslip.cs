using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneChallenge_Payslip.Application.Models
{
    public class Payslip
    {
        public string Month { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public double Salary { get; set; }
        public double Deduction { get; set; }
        public double NetSalary { get; set; }

        public class Entry
        {
            public string Type { get; set; }
            public double Amount { get; set; }
            public string Description { get; set; }
        }

    }
}
