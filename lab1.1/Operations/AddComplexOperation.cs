namespace ComplexNumbersOperations.Operations
{
    public class AddComplexOperation : IComplexOperation
    {
        private readonly ComplexNumber _left;
        private readonly ComplexNumber _right;

        public AddComplexOperation(ComplexNumber left, ComplexNumber right)
        {
            _left = left;
            _right = right;
        }

        public ComplexNumber Execute()
        {
            return new ComplexNumber(
                _left.Real + _right.Real,
                _left.Imaginary + _right.Imaginary
            );
        }

        public string GetDescription()
        {
            return $"({_left}) + ({_right})";
        }
    }
}