using System;
using System.Collections.Generic;

namespace Quest.IO
{
    class Selection
    {
        string message;
        string[] options;

        public Selection(string message, string[] options)
        {
            this.message = message;
            this.options = options ?? new string[0];
        }

        public static int Run(string message, string[] options) => new Selection(message, options).GetOption();

        public int GetOption()
        {
            if (message != null)
                Console.WriteLine(message);
            
            for (int i = 0; i < options.Length; ++i)
                Console.WriteLine($"{i + 1}: {options[i]}");

            Console.Write("\nEingabe: ");

            int input;

            while (!int.TryParse(Console.ReadLine(), out input) || !IsValidOption(input))
                Console.Write("Ungültige Eingabe: ");
            
            Console.Clear();
            
            return input;
        }

        bool IsValidOption(int option) => options.Length >= option && option > 0;
    }
}