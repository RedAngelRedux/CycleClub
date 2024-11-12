using CycleClub.Data;
using CycleClub.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.Views;

public class UserRegistrationView : IView
{
    IFieldValidator? _fieldValidator = null;
    IRegister? _register = null;

    public IFieldValidator? FieldValidator { get => _fieldValidator; }


    public void RunView()
    {
        throw new NotImplementedException();
    }

    public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
    {
        _register = register;   
        _fieldValidator = fieldValidator;
    }

    private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
    {
        string fieldValue = string.Empty;

        do
        {
            Console.WriteLine(promptText);
            fieldValue = Console.ReadLine();
        } while (!FieldValid(field,fieldValue??string.Empty));

        return fieldValue??string.Empty;
    }

    private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue) 
    {
        return true;
    }
}
