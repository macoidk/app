using System;
using ComplexNumbersOperations.Comparison;

namespace ComplexNumbersOperations.UI
{
    /// <summary>
    /// Обробник меню для порівняння комплексних чисел
    /// </summary>
    public class ComparisonMenuHandler : MenuHandler
    {
        private readonly ComplexFacade _facade;

        public ComparisonMenuHandler(ComplexFacade facade, OperationInvoker invoker)
            : base(null, invoker) // Calculator більше не потрібен напряму
        {
            _facade = facade;
        }

        public override void Handle()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n=== Порівняння комплексних чисел ===\n");

                Console.WriteLine("Виберіть стратегію порівняння:");
                Console.WriteLine("1. За модулем");
                Console.WriteLine("2. За дійсною частиною");
                Console.WriteLine("3. За уявною частиною");

                Console.Write("\nВаш вибір: ");
                string strategyChoice = Console.ReadLine();

                switch (strategyChoice)
                {
                    case "1":
                        _facade.SetComparisonStrategy(new MagnitudeComparisonStrategy());
                        break;
                    case "2":
                        _facade.SetComparisonStrategy(new RealPartComparisonStrategy());
                        break;
                    case "3":
                        _facade.SetComparisonStrategy(new ImaginaryPartComparisonStrategy());
                        break;
                    default:
                        ShowError("Невідома стратегія");
                        return;
                }

                Console.WriteLine($"\nВибрано стратегію: {_facade.GetComparisonDescription()}");

                var complex1 = GetComplexNumberFromUser("\nВведіть перше комплексне число:");
                var complex2 = GetComplexNumberFromUser("\nВведіть друге комплексне число:");

                bool result = _facade.Compare(complex1, complex2);

                Console.WriteLine($"\nРезультат порівняння {complex1} та {complex2}:");
                if (result)
                {
                    Console.WriteLine($"{complex1} > {complex2} за стратегією {_facade.GetComparisonDescription()}");
                }
                else
                {
                    Console.WriteLine($"{complex1} ≤ {complex2} за стратегією {_facade.GetComparisonDescription()}");
                }

                Console.WriteLine($"\nМодуль першого числа: {complex1.GetMagnitude():F2}");
                Console.WriteLine($"Модуль другого числа: {complex2.GetMagnitude():F2}");

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
    }
}