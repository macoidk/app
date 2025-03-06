using System;

namespace ComplexNumbersOperations.UI
{
    /// <summary>
    /// Обробник меню для очищення історії операцій
    /// </summary>
    public class ClearHistoryMenuHandler : MenuHandler
    {
        private readonly ComplexFacade _facade;

        public ClearHistoryMenuHandler(ComplexFacade facade, OperationInvoker invoker)
            : base(null, invoker) // Calculator більше не потрібен напряму
        {
            _facade = facade;
        }

        public override void Handle()
        {
            Console.Clear();
            Console.WriteLine("\n=== Очищення історії операцій ===\n");

            if (_facade.OperationsCount == 0)
            {
                Console.WriteLine("Історія операцій вже порожня.");
            }
            else
            {
                Console.Write("Ви впевнені, що хочете очистити історію операцій? (y/n): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm == "y" || confirm == "так" || confirm == "yes")
                {
                    _facade.ClearOperations();
                    Console.WriteLine("Історію операцій очищено.");
                }
                else
                {
                    Console.WriteLine("Очищення скасовано.");
                }
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до головного меню...");
            Console.ReadKey();
        }
    }
}