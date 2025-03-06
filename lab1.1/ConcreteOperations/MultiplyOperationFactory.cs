using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.Factories
{
    public class MultiplyOperationFactory : OperationFactory
    {
        public override IComplexOperation CreateOperation(ComplexNumber left, ComplexNumber right)
        {
            return new MultiplyComplexOperation(left, right);
        }
    }
}