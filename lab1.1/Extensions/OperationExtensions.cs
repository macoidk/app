using System;
using System.Collections.Generic;
using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.Extensions
{
    
    public static class OperationExtensions
    {
        private static readonly Dictionary<string, Func<ComplexNumber, ComplexNumber, IComplexOperation>> _operationFactories =
            new Dictionary<string, Func<ComplexNumber, ComplexNumber, IComplexOperation>>();

        public static void RegisterOperation(string operationName,
            Func<ComplexNumber, ComplexNumber, IComplexOperation> factory)
        {
            if (_operationFactories.ContainsKey(operationName))
            {
                throw new ArgumentException($"Operation '{operationName}' is already registered");
            }

            _operationFactories[operationName] = factory;
        }

        public static IComplexOperation CreateExtendedOperation(string operationName,
            ComplexNumber left, ComplexNumber right)
        {
            if (_operationFactories.TryGetValue(operationName, out var factory))
            {
                return factory(left, right);
            }

            throw new ArgumentException($"Unknown operation: {operationName}");
        }

        public static bool IsOperationRegistered(string operationName)
        {
            return _operationFactories.ContainsKey(operationName);
        }

        public static List<string> GetRegisteredOperations()
        {
            return new List<string>(_operationFactories.Keys);
        }
    }
}