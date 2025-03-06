using System;
using System.Collections.Generic;
using ComplexNumbersOperations.Operations.Extended;
using ComplexNumbersOperations.Extensions;

namespace ComplexNumbersOperations.UI
{
    
    public class MainMenuHandler
    {
        private readonly ComplexFacade _facade;
        private readonly Dictionary<string, MenuHandler> _menuHandlers;

        public MainMenuHandler()
        {
            _facade = new ComplexFacade();

            // Реєструємо розширені операції
            OperationExtensions.RegisterOperation("conjugate",
                (left, right) => new ConjugateComplexOperation(left));

            OperationExtensions.RegisterOperation("power",
                (left, right) => new PowerComplexOperation(left, right));

            // Ініціалізуємо обробники підменю, передаючи Invoker через властивість фасаду
            _menuHandlers = new Dictionary<string, MenuHandler>
            {
                { "1", new ArithmeticOperationMenuHandler(_facade, _facade.Invoker) },
                { "2", new ComparisonMenuHandler(_facade, _facade.Invoker) },
                { "3", new HistoryMenuHandler(_facade, _facade.Invoker) },
                { "4", new ClearHistoryMenuHandler(_facade, _facade.Invoker) }
            };
        }

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMainMenu();

                Console.Write("\nВаш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    exit = true;
                }
                else if (_menuHandlers.ContainsKey(choice))
                {
                    _menuHandlers[choice].Handle();
                }
                else
                {
                    Console.WriteLine("Невідомий вибір. Спробуйте ще раз.");
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Дякуємо за використання програми!");
        }

        private void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("==== Програма для роботи з комплексними числами ====");
            Console.WriteLine("\nВиберіть дію:");
            Console.WriteLine("1. Виконати арифметичну операцію");
            Console.WriteLine("2. Порівняти комплексні числа");
            Console.WriteLine("3. Показати історію операцій");
            Console.WriteLine("4. Очистити історію операцій");
            Console.WriteLine("5. Вихід");
        }
    }
}