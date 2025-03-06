namespace ComplexNumbersOperations.Comparison
{
   
    public class MagnitudeComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(ComplexNumber left, ComplexNumber right)
        {
            return left.GetMagnitude() > right.GetMagnitude();
        }

        public string GetDescription()
        {
            return "Порівняння за модулем (|z1| > |z2|)";
        }
    }
}