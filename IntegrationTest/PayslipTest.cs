using Domain.Shared;
using System;
using Xunit;

namespace AspNetCoreTests.IntegrationTests
{
    [Collection("Sequential")]
    public class PayslipTest
    {

        [Theory]
        [InlineData(1500, "2021-05-10", 1064.52)]
        public void Shared_PayslipCalculator_CalculateProportionalSalary(double salary, DateTime admission, double proportionalSalary)
        {
            var result = PayslipCalculator.CalculateProportionalSalary(salary, admission);

            Assert.Equal(result, proportionalSalary);                    
        }

    }
}