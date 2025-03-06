namespace ComplexNumbersOperations.Comparison
{
    public interface IComparisonStrategy
    {
        bool Compare(ComplexNumber left, ComplexNumber right);
        string GetDescription();
    }
}