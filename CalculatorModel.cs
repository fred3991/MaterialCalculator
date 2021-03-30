using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialCalculator
{
    public class CalculatorModel
    {
        public double result { get; set; }
        public CalculatorModel()
        {

        }
        public object Calculate(double operand1, double operand2, char operation)
        {
            if (operation == '+')
            {
                result = Sum(operand1, operand2);
            }

            if (operation == '-')
            {
                result = Minus(operand1, operand2);
            }

            if (operation == '*')
            {
                result = Multiplication(operand1, operand2);
            }
            if (operation == '/')
            {
                result = Divide(operand1, operand2);
            }
            return result;
        }

        public double Sum(double operand1, double operand2)
        {
            return operand1 + operand2;
        }

        public double Minus(double operand1, double operand2)
        {
            return operand1 - operand2;
        }

        public double Multiplication(double operand1, double operand2)
        {
            return operand1 * operand2;
        }

        public double Divide(double operand1, double operand2)
        {
            return operand1 / operand2; ;
        }


    }
}
