using CycleClub.Data;
using CycleClub.FieldValidators;
using CycleClub.Models;

namespace CycleClub.Views;

public class UserLoginView(ILogin login) : IView
{
    readonly ILogin? _loginUser = login;

    public IFieldValidator? FieldValidator => null;  // because we are not going to validate login fields although we could iwwt

    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        CommonOutputText.WriteLoginHeading();

        Console.Write("Please enter your email address: ");
        string emailAddress = Console.ReadLine() ?? string.Empty;

        Console.Write("Please enter your password: ");
        string password = Console.ReadLine() ?? string.Empty;

        User? user = _loginUser?.Login(emailAddress, password);

        if (user is not null)
        {
            new WelcomeUserView(user).RunView();
        }
        else
        {
            CommonOutputText.WriteDangerMessage("Those credentials do not match our records");
            CommonOutputText.WritePressKeyMessage();
        }
    }
}
