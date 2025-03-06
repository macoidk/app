using System;

namespace ComplexNumbersOperations.UI
{
    public abstract class MenuHandler
    {
        protected readonly ComplexNumberCalculator Calculator;
        protected readonly OperationInvoker Invoker;

        protected MenuHandler(ComplexNumberCalculator calculator, OperationInvoker invoker)
        {
            Calculator = calculator;
            Invoker = invoker;
        }

        public abstract void Handle();

       
        protected ComplexNumber GetComplexNumberFromUser(string message)
        {
            Console.WriteLine(message);

            Console.Write("Введіть дійсну частину: ");
            double real = double.Parse(Console.ReadLine());

            Console.Write("Введіть уявну частину: ");
            double imaginary = double.Parse(Console.ReadLine());

            return new ComplexNumber(real, imaginary);
        }

        protected void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Помилка: {message}");
            Console.ResetColor();
        }
    }
}