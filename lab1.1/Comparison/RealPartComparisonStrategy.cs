namespace ComplexNumbersOperations.Comparison
{
    public class RealPartComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(ComplexNumber left, ComplexNumber right)
        {
            return left.Real > right.Real;
        }

        public string GetDescription()
        {
            return "Порівняння за дійсною частиною (Re(z1) > Re(z2))";
        }
    }
}