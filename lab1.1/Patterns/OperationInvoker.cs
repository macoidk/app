using System.Collections.Generic;
using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations
{
   
    public class OperationInvoker
    {
        private readonly List<IComplexOperation> _operations = new List<IComplexOperation>();

        public void AddOperation(IComplexOperation operation)
        {
            _operations.Add(operation);
        }

        public List<(string Description, ComplexNumber Result)> ExecuteOperations()
        {
            var results = new List<(string Description, ComplexNumber Result)>();

            foreach (var operation in _operations)
            {
                results.Add((operation.GetDescription(), operation.Execute()));
            }

            return results;
        }

        public void ClearOperations()
        {
            _operations.Clear();
        }

        public int OperationsCount => _operations.Count;
    }
}