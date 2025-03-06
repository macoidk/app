using ComplexNumbersOperations.Comparison;

namespace ComplexNumbersOperations
{
    
    /// Strategy
    public class ComplexNumberCalculator
    {
        private IComparisonStrategy _comparisonStrategy;

        public ComplexNumberCalculator()
        {
            _comparisonStrategy = new MagnitudeComparisonStrategy();
        }

        public void SetComparisonStrategy(IComparisonStrategy strategy)
        {
            _comparisonStrategy = strategy;
        }

        public bool Compare(ComplexNumber left, ComplexNumber right)
        {
            return _comparisonStrategy.Compare(left, right);
        }

        public string GetComparisonDescription()
        {
            return _comparisonStrategy.GetDescription();
        }
    }
}