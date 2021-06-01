using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public class LegalCalculator
    {
        public static double CalculateFGTS(double salary)
        {
            return Math.Round((salary * 0.08), 2);
        }

        public static double CalculateINSS(double salary)
        {
            double result;

            if (salary <= 1045)
            {
                result = salary * 0.075;
            }
            else if (salary >= 1045.01 && salary <= 2089.60)
            {
                result = salary * 0.09;
            }
            else if (salary >= 2089.61 && salary <= 3134.40)
            {
                result = salary * 0.12;
            }
            else if (salary >= 3134.41 && salary <= 6101.06)
            {
                result = salary * 0.14;
            }
            else
            {
                result = 6101.06 * 0.14;
            }
            
            return Math.Round(result, 2);
        }

        public static double CalculateIRRF(double salary)
        {

            double deduction;
            double aliquot;

            double baseCalc = salary - CalculateINSS(salary);

            if (baseCalc <= 1903.98)
            {
                return 0;
            }
            if (baseCalc >= 1903.99 && baseCalc <= 2826.65)
            {
                deduction = 142.80;
                aliquot = 0.075;
            }
            else if (baseCalc >= 2862.66 && baseCalc <= 3751.05)
            {
                deduction = 354.80;
                aliquot = 0.15;
            }
            else if (baseCalc >= 3751.06 && baseCalc <= 4664.68)
            {
                deduction = 636.13;
                aliquot = 0.225;
            }
            else
            {
                deduction = 869.36;
                aliquot = 0.275;
            }

            double result = baseCalc * aliquot;

            return Math.Round(result > deduction ? deduction : result, 2);

        }


    }

}
