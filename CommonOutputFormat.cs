using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub;

public enum FontTheme
{
    Default,
    Danger,
    Success
}

public static class CommonOutputFormat
{
    public static void ChangeFontColor(FontTheme fonttheme)
    {
        if (fonttheme == FontTheme.Danger)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (fonttheme == FontTheme.Success)
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
