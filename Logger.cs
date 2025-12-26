namespace arthurengine;
using System;

public class Logger
{
    public static void Info(string message)
    {
        Console.Write("[");
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("INFO");
        Console.ForegroundColor = color;
        Console.Write($"]: {message}\n");
    }

    public static void Warn(string message)
    {
        Console.Write("[");
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("WARN");
        Console.ForegroundColor = color;
        Console.Write($"]: {message}\n");
    }

    public static void Error(string message)
    {
        Console.Write("[");
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ERROR");
        Console.ForegroundColor = color;
        Console.Write($"]: {message}\n");
        throw new Exception();
    }

}
