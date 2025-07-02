using System;

namespace CalculatorApp
{
    public class CalculatorApp
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int minus(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("0で割ることはできません！");
            return a / b;
        }
    }
    
}