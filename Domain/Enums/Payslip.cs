using System.Collections.Generic;

namespace Domain.Enums
{
    public class PayslipEnums
    {
        public enum EntryType
        {
            Discount,
            Remuneration
        }

        public enum EntryName
        {
            Salary,
            INSS,
            IRRF,
            FGTS,
            HealthPlan,
            DentalPlan,
            CommuterBenefits,
        }

        public static Dictionary<EntryName, string> EntryDescriptions = new Dictionary<EntryName, string>()
        {
            {    EntryName.Salary, "Salário Bruto" },
            {    EntryName.INSS, "INSS" },
            {    EntryName.IRRF, "Imposto Retido na Fonte" },
            {    EntryName.FGTS, "FGTS" },
            {    EntryName.HealthPlan, "Plano de Saúde" },
            {    EntryName.DentalPlan, "Plano Dental" },
            {    EntryName.CommuterBenefits, "Vale Transporte" }
        };

    }
}
