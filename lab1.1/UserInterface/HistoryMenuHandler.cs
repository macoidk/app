using System;

namespace ComplexNumbersOperations.UI
{
    /// <summary>
    /// Обробник меню для перегляду історії операцій
    /// </summary>
    public class HistoryMenuHandler : MenuHandler
    {
        private readonly ComplexFacade _facade;

        public HistoryMenuHandler(ComplexFacade facade, OperationInvoker invoker)
            : base(null, invoker) // Calculator більше не потрібен напряму
        {
            _facade = facade;
        }

        public override void Handle()
        {
            Console.Clear();
            Console.WriteLine("\n=== Історія операцій ===\n");

            var results = _facade.ExecuteOperations();

            if (results.Count == 0)
            {
                Console.WriteLine("Історія операцій порожня.");
            }
            else
            {
                Console.WriteLine("Виконані операції:");
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {results[i].Description} = {results[i].Result}");
                }
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до головного меню...");
            Console.ReadKey();
        }
    }
}