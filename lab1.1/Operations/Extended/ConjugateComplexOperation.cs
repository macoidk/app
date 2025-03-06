namespace ComplexNumbersOperations.Operations.Extended
{
   
    public class ConjugateComplexOperation : IComplexOperation
    {
        private readonly ComplexNumber _number;

        public ConjugateComplexOperation(ComplexNumber number, ComplexNumber _ = null)
        {
            _number = number;
        }

        public ComplexNumber Execute()
        {
            return new ComplexNumber(_number.Real, -_number.Imaginary);
        }

        public string GetDescription()
        {
            return $"Conjugate({_number})";
        }
    }
}