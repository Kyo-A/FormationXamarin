using System;
using System.Collections.Generic;
using System.Text;

namespace FormationXamForms.Models
{
    class CalculModel
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public class Result
        {
            public double Value { get; set; }

            public override string ToString()
            {
                return $"{this.Value}";
            }
        }
    }
}
