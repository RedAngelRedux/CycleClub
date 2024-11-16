using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub;

internal class CommonOutputText
{
    private static string MainHeading
    {
        get
        {
            string heading = "Cycling Club";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }

    private static string RegistrationHeading
    {
        get
        {
            string heading = "Register";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }
    private static string LoginHeading
    {
        get
        {
            string heading = "Login";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }

    public static void WriteMainHeading()
    {
        Console.Clear();
        Console.WriteLine(MainHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
    public static void WriteLoginHeading()
    {
        Console.WriteLine(LoginHeading);
        Console.WriteLine();
        Console.WriteLine();
    }
    public static void WriteRegistrationHeading()
    {
        Console.WriteLine(RegistrationHeading);
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void WriteInvalidKeyMessage(ConsoleKey key)
    {
        WriteDangerMessage($"{key} is an invalid option.");
    }

    public static void WritePressKeyMessage(string message = "Press any key to continue...")
    {
        Console.Write(message);
        Console.ReadKey();
    }

    public static void WriteDangerMessage(string message)
    {
        CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
        Console.WriteLine(message);
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
    }

    public static void WriteSuccessMessage(string message)
    {
        CommonOutputFormat.ChangeFontColor(FontTheme.Success);
        Console.WriteLine(message);
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
    }
}
