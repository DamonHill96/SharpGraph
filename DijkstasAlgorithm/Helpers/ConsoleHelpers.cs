using System;

namespace DijkstasAlgorithm.Helpers
{
    public static class ConsoleHelpers
    {
        public static string ReadLineAfterDisplayingMessage(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static ConsoleKeyInfo PressAnyKeyToContinue()
        {
            Console.WriteLine("Press Any Key To Continue...");
            return Console.ReadKey();
        }
    }
}