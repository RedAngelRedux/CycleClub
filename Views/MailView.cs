using CycleClub.Data;
using CycleClub.FieldValidators;
using CycleClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        ConsoleKey key = ConsoleKey.Z;
        do
        {
            CommonOutputText.WriteMainHeading();

            Console.Write("Please enter 'l' to login, 'r' to register for the first time, or 'q' to exit the application: ");
            key = Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunLoginView();
            }
            else if (key == ConsoleKey.L)
            {
                RunLoginView();
            }
            else if (key == ConsoleKey.Q)
            {
                Console.Clear();
                Console.WriteLine("Good-bye.");
                CommonOutputText.WritePressKeyMessage();
            }
            else
            {
                Console.WriteLine();
                CommonOutputText.WriteInvalidKeyMessage(key);
                CommonOutputText.WritePressKeyMessage();
            }

        } while (key != ConsoleKey.Q);    
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
