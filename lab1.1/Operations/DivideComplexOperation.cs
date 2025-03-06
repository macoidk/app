namespace ComplexNumbersOperations.Operations
{
    public class DivideComplexOperation : IComplexOperation
    {
        private readonly ComplexNumber _left;
        private readonly ComplexNumber _right;

        public DivideComplexOperation(ComplexNumber left, ComplexNumber right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Execute()
        {
            // (a + bi) / (c + di) = [(a + bi)(c - di)] / [(c + di)(c - di)]
            // = [(ac + bd) + (bc - ad)i] / (c² + d²)
            double denominator = _right.Real * _right.Real + _right.Imaginary * _right.Imaginary;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero complex number");
            }

            double real = (_left.Real * _right.Real + _left.Imaginary * _right.Imaginary) / denominator;
            double imaginary = (_left.Imaginary * _right.Real - _left.Real * _right.Imaginary) / denominator;

            return new ComplexNumber(real, imaginary);
        }

        public string GetDescription()
        {
            return $"({_left}) / ({_right})";
        }
    }
}