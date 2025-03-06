using System.Collections.Generic;
using ComplexNumbersOperations.Comparison;
using ComplexNumbersOperations.Factories;
using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations
{

    public class ComplexFacade
    {
        private readonly ComplexNumberCalculator _calculator;
        private readonly OperationInvoker _invoker;
        private readonly Dictionary<string, OperationFactory> _operationFactories;

        public ComplexFacade()
        {
            _calculator = new ComplexNumberCalculator();
            _invoker = new OperationInvoker();
            _operationFactories = new Dictionary<string, OperationFactory>
            {
                { "add", new AddOperationFactory() },
                { "subtract", new SubtractOperationFactory() },
                { "multiply", new MultiplyOperationFactory() },
                { "divide", new DivideOperationFactory() }
            };
        }

        public OperationInvoker Invoker => _invoker;

        public void AddAndExecuteOperation(string operationType, ComplexNumber left, ComplexNumber right)
        {
            if (_operationFactories.TryGetValue(operationType, out var factory))
            {
                var operation = factory.CreateOperation(left, right);
                _invoker.AddOperation(operation);
            }
            else
            {
                throw new System.ArgumentException($"Unknown operation type: {operationType}");
            }
        }

        public List<(string Description, ComplexNumber Result)> ExecuteOperations()
        {
            return _invoker.ExecuteOperations();
        }

        public void ClearOperations()
        {
            _invoker.ClearOperations();
        }

        public int OperationsCount => _invoker.OperationsCount;

        public void SetComparisonStrategy(IComparisonStrategy strategy)
        {
            _calculator.SetComparisonStrategy(strategy);
        }

        public bool Compare(ComplexNumber left, ComplexNumber right)
        {
            return _calculator.Compare(left, right);
        }

        public string GetComparisonDescription()
        {
            return _calculator.GetComparisonDescription();
        }
    }
}