using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub;

public enum Fonttheme
{
    Default,
    Danger,
    Success
}

public static class CommonOutputFormat
{
    public static void ChangeFontColor(Fonttheme fonttheme)
    {
        if (fonttheme == Fonttheme.Danger)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (fonttheme == Fonttheme.Success)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ResetColor();
        }
    }
}
