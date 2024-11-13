using CycleClub.FieldValidators;
using CycleClub.Models;

namespace CycleClub.Views;

public class WelcomeUserView(User user) : IView
{
    readonly User? _user = user;

    public IFieldValidator? FieldValidator => null;

    public void RunView()
    {
        CommonOutputFormat.ChangeFontColor(FontTheme.Success);
        Console.WriteLine($"Hi {_user?.FirstName??"<Invalid User>"}!! {Environment.NewLine}Welcome to the Cycle Club");
        CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}
