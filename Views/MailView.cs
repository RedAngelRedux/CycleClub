using CycleClub.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.Views;

public class MailView(IView registerView, IView loginView) : IView
{
    readonly IView _registerView = registerView;
    readonly IView _loginView = loginView;
    public IFieldValidator? FieldValidator => null;

    public void RunView()
    {
        CommonOutputText.WriteMainHeading();

        Console.WriteLine("Please enter 'l' to login or 'r' to register if you don't yet have an account");
        ConsoleKey key = Console.ReadKey().Key;

        if (key == ConsoleKey.R)
        {
            RunUserRegistrationView();
            RunLoginView();
        }
        else if (key == ConsoleKey.L)
        {
            RunLoginView();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Good-bye");
            Console.ReadKey();
        }
    }

    private void RunUserRegistrationView()
    {
        _registerView.RunView();
    }

    private void RunLoginView()
    {
        _loginView.RunView();
    }
}
