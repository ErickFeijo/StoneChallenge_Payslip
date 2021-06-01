using Domain.Shared;
using System;
using System.Linq;
using System.Collections;
using Xunit;
using static StoneChallenge_Payslip.Domain.Payslip;
using System.Collections.Generic;
using StoneChallenge_Payslip.Domain.Entities;
using StoneChallenge_Payslip.Domain;

namespace UnitTest
{
    public class PayslipTest
    {
        [Theory]
        [InlineData(1500, "2021-05-01", 1500)]
        [InlineData(1500, "2021-05-10", 1064.52)]
        [InlineData(1500, "2021-05-31", 48.39)]
        [InlineData(1500, "2021-02-10", 1017.86)]
        [InlineData(1500, "2021-02-01", 1500)]
        public void Shared_PayslipCalculator_CalculateProportionalSalary(double salary, DateTime admission, double proportionalSalary)
        {
            var result = PayslipCalculator.CalculateProportionalSalary(salary, admission);

            Assert.Equal(result, proportionalSalary);
        }

        #region CalculateLegalDiscounts

        [Theory]
        [InlineData(1500, 120)]
        public void Shared_LegalCalculator_CalculateFGTS(double salary, double expectedFGTS)
        {
            var result = LegalCalculator.CalculateFGTS(salary);

            Assert.Equal(result, expectedFGTS);
        }

        [Theory]
        [InlineData(1045, 78.375)] //7,5%
        [InlineData(2089.60, 188.064)] //9%
        [InlineData(3134.40, 376.128)] //12%
        [InlineData(6101.06, 854.1484000000002)] //14%
        [InlineData(10000, 854.1484000000002)] //Teto
        public void Shared_LegalCalculator_CalculateINSS(double salary, double expectedINSS)
        {
            var result = LegalCalculator.CalculateINSS(salary);

            Assert.Equal(result, expectedINSS);
        }

        [Theory]
        [InlineData(1900, 0)] 
        [InlineData(2826.65, 142.80)]
        [InlineData(3751.05, 354.80)]
        [InlineData(4664.68, 636.13)]
        [InlineData(10000, 869.36)] 
        public void Shared_LegalCalculator_CalculateIRRF(double salary, double expectedIRRF)
        {
            var result = LegalCalculator.CalculateIRRF(salary);

            Assert.Equal(result, expectedIRRF);
        }

        #endregion

        #region CheckEntries

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Shared_PayslipCalculator_CheckHealthPlanEntries(bool hasHealthPlan)
        {
            IEnumerable<Entry> result = PayslipCalculator.Entries(1500, hasHealthPlan, false, false);

            if (hasHealthPlan)
            {
                Assert.Contains(result, x => x.Description == "Plano de Saúde");
            }
            else
            {
                Assert.DoesNotContain(result, x => x.Description == "Plano de Saúde");
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Shared_PayslipCalculator_CheckDentalPlanEntries(bool hasDentalPlan)
        {
            IEnumerable<Entry> result = PayslipCalculator.Entries(1500, false, hasDentalPlan, false);

            if (hasDentalPlan)
            {
                Assert.Contains(result, x => x.Description == "Plano Dental");
            }
            else
            {
                Assert.DoesNotContain(result, x => x.Description == "Plano Dental");
            }
        }

        [Theory]
        [InlineData(1600, true)]
        [InlineData(1600, false)]
        [InlineData(1400, true)]
        [InlineData(1400, false)]
        public void Shared_Paysr_CheckCommuterBenefitsEntries(double salary, bool hasCommuterBenefits)
        {
            IEnumerable<Entry> result = PayslipCalculator.Entries(salary, false, false, hasCommuterBenefits);

            if (hasCommuterBenefits && salary > 1500)
            {
                Assert.Contains(result, x => x.Description == "Vale Transporte");
            }
            else
            {
                Assert.DoesNotContain(result, x => x.Description == "Vale Transporte");
            }                
        }

        #endregion

    }
}
