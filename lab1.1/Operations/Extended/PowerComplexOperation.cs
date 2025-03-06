using System;

namespace ComplexNumbersOperations.Operations.Extended
{
    public class PowerComplexOperation : IComplexOperation
    {
        private readonly ComplexNumber _number;
        private readonly int _power;

        public PowerComplexOperation(ComplexNumber number, ComplexNumber powerAsComplex)
        {
            _number = number;
            _power = (int)powerAsComplex.Real;
        }

        public ComplexNumber Execute()
        {
            if (_power == 0)
            {
                return new ComplexNumber(1, 0);
            }

            double r = _number.GetMagnitude();
            double theta = Math.Atan2(_number.Imaginary, _number.Real);

            double newR = Math.Pow(r, _power);
            double newTheta = theta * _power;

            double newReal = newR * Math.Cos(newTheta);
            double newImaginary = newR * Math.Sin(newTheta);

            return new ComplexNumber(newReal, newImaginary);
        }

        public string GetDescription()
        {
            return $"({_number})^{_power}";
        }
    }
}