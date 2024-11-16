using CycleClub.FieldValidators;
using CycleClub.Models;

namespace CycleClub.Views;

public class WelcomeUserView(User user) : IView
{
    readonly User? _user = user;

    public IFieldValidator? FieldValidator => null;

    public void RunView()
    {
        Console.Clear();
        CommonOutputText.WriteMainHeading();

        CommonOutputText.WriteSuccessMessage($"Hi {_user?.FirstName??"<Invalid User>"}!! {Environment.NewLine}Welcome to the Cycle Club");
        CommonOutputText.WritePressKeyMessage();
    }
}
