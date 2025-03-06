namespace ComplexNumbersOperations.Operations
{
    public class MultiplyComplexOperation : IComplexOperation
    {
        private readonly ComplexNumber _left;
        private readonly ComplexNumber _right;

        public MultiplyComplexOperation(ComplexNumber left, ComplexNumber right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Execute()
        {
            // (a + bi) * (c + di) = (ac - bd) + (ad + bc)i
            double real = _left.Real * _right.Real - _left.Imaginary * _right.Imaginary;
            double imaginary = _left.Real * _right.Imaginary + _left.Imaginary * _right.Real;

            return new ComplexNumber(real, imaginary);
        }

        public string GetDescription()
        {
            return $"({_left}) * ({_right})";
        }
    }
}
