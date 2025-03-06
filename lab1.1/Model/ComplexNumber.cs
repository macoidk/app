using System;

namespace ComplexNumbersOperations
{
   
    public class ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double GetMagnitude()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        public override string ToString()
        {
            string sign = Imaginary < 0 ? "-" : "+";
            return $"{Real} {sign} {Math.Abs(Imaginary)}i";
        }
    }
}