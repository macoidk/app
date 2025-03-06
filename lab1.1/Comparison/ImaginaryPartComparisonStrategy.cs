namespace ComplexNumbersOperations.Comparison
{
  
    public class ImaginaryPartComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(ComplexNumber left, ComplexNumber right)
        {
            return left.Imaginary > right.Imaginary;
        }

        public string GetDescription()
        {
            return "Порівняння за уявною частиною (Im(z1) > Im(z2))";
        }
    }
}