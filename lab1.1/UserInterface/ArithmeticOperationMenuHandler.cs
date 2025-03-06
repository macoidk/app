using System;
using System.Collections.Generic;
using ComplexNumbersOperations.Extensions;
using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.UI
{
    /// <summary>
    /// Обробник меню для арифметичних операцій
    /// </summary>
    public class ArithmeticOperationMenuHandler : MenuHandler
    {
        private readonly ComplexFacade _facade;

        public ArithmeticOperationMenuHandler(ComplexFacade facade, OperationInvoker invoker)
            : base(null, invoker) // Calculator більше не потрібен напряму
        {
            _facade = facade;
        }

        public override void Handle()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n=== Виконання арифметичної операції ===\n");

                // Отримуємо перше комплексне число
                var complex1 = GetComplexNumberFromUser("Введіть перше комплексне число:");
                Console.WriteLine($"Перше комплексне число: {complex1}");

                // Показуємо доступні операції
                Console.WriteLine("\nДоступні операції:");
                Console.WriteLine("1. Додавання (+)");
                Console.WriteLine("2. Віднімання (-)");
                Console.WriteLine("3. Множення (*)");
                Console.WriteLine("4. Ділення (/)");

                // Показуємо також розширені операції
                var extendedOps = OperationExtensions.GetRegisteredOperations();
                for (int i = 0; i < extendedOps.Count; i++)
                {
                    Console.WriteLine($"{i + 5}. {extendedOps[i]}");
                }

                Console.Write("\nВиберіть операцію: ");
                string opChoice = Console.ReadLine();

                string operationType;
                ComplexNumber complex2 = null;
                IComplexOperation operation = null;

                switch (opChoice)
                {
                    case "1":
                        operationType = "add";
                        complex2 = GetSecondNumber();
                        _facade.AddAndExecuteOperation(operationType, complex1, complex2);
                        break;

                    case "2":
                        operationType = "subtract";
                        complex2 = GetSecondNumber();
                        _facade.AddAndExecuteOperation(operationType, complex1, complex2);
                        break;

                    case "3":
                        operationType = "multiply";
                        complex2 = GetSecondNumber();
                        _facade.AddAndExecuteOperation(operationType, complex1, complex2);
                        break;

                    case "4":
                        operationType = "divide";
                        complex2 = GetSecondNumber();
                        _facade.AddAndExecuteOperation(operationType, complex1, complex2);
                        break;

                    default:
                        int index = int.Parse(opChoice) - 5;
                        if (index >= 0 && index < extendedOps.Count)
                        {
                            operationType = extendedOps[index];
                            if (operationType == "conjugate")
                            {
                                operation = OperationExtensions.CreateExtendedOperation(operationType, complex1, null);
                            }
                            else
                            {
                                complex2 = GetSecondNumber();
                                operation = OperationExtensions.CreateExtendedOperation(operationType, complex1, complex2);
                            }
                            Invoker.AddOperation(operation);
                        }
                        else
                        {
                            ShowError("Невідома операція");
                            return;
                        }
                        break;
                }

                // Виводимо результат
                var results = _facade.ExecuteOperations();
                var lastResult = results[results.Count - 1];

                Console.WriteLine($"\nРезультат: {lastResult.Description} = {lastResult.Result}");
                Console.WriteLine($"Модуль результату: {lastResult.Result.GetMagnitude():F2}");

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до головного меню...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до головного меню...");
                Console.ReadKey();
            }
        }

        private ComplexNumber GetSecondNumber()
        {
            return GetComplexNumberFromUser("\nВведіть друге комплексне число:");
        }
    }
}