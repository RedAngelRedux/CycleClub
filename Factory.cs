using CycleClub.Data;
using CycleClub.FieldValidators;
using CycleClub.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub;

public class Factory
{
    public static IView GetMainViewObject()
    {
        ILogin login = new LoginUser();
        IRegister register = new RegisterUser();
        IFieldValidator userRegistrationValidator = new UserRegistrationValidator(register);
        userRegistrationValidator.InitializeValidatorDelegates();

        IView registerView = new UserRegistrationView(register, userRegistrationValidator);
        IView loginView = new UserLoginView(login);
        IView mainView = new MailView(registerView, loginView);

        return mainView;
    }
}
