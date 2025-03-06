using System;
using ComplexNumbersOperations.UI;

namespace ComplexNumbersOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var mainMenu = new MainMenuHandler();
            mainMenu.Start();
        }
    }
}