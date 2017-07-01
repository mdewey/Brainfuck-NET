using System;

namespace Brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Registry();
            Console.WriteLine(interpreter.ToString());
            interpreter.IncrementValue();
            interpreter.IncrementValue();
            interpreter.IncrementValue();
            interpreter.IncrementValue();
            interpreter.IncrementValue();

            Console.WriteLine(interpreter.ToString());
            interpreter.DecrementValue();
            Console.WriteLine(interpreter.ToString());
            interpreter.DecrementValue();

            Console.WriteLine(interpreter.ToString());
        }
    }
}