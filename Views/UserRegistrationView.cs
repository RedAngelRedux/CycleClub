using CycleClub.Data;
using CycleClub.FieldValidators;

namespace CycleClub.Views;

public class UserRegistrationView : IView
{
    IFieldValidator? _fieldValidator = null;
    IRegister? _register = null;

    public IFieldValidator? FieldValidator { get => _fieldValidator; }


    public void RunView()
    {
        if ((_fieldValidator == null)) throw new NullReferenceException("Error in RunView; Null Field Validator.");

        CommonOutputText.WriteMainHeading();
        CommonOutputText.WriteRegistrationHeading();

        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please Enter Your Email Address: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please Enter Your First Name: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please Enter Your Last Name: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please Enter Your Date Of Birth: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.Password, $"Please Enter Your Password{Environment.NewLine}" +
            $"Your password must contain at least 1 small-case letter, 1 Capital letter, 1 numeric digit, 1 special character{Environment.NewLine}" +
            $"and the length should be between 6-10 characters.: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please Enter Your Password Again: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Address1] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.Address1, "Please Enter Your Address Line One: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Address2] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.Address2, "Please Enter Your Address Line Two (optional): ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.City] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.City, "Please Enter Your City: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.State] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.State, "Please Enter Your State Code: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostalCode] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.PostalCode, "Please Enter Your Zip Code: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PhoneNumber] = 
            GetInputFromUser(FieldConstants.UserRegistrationField.PhoneNumber, "Please Enter Your PhoneNumber: ");

        RegisterUser();
    }

    private void RegisterUser()
    {
        if(_register is null || _fieldValidator is null)
        {
            CommonOutputText.WriteDangerMessage("Your registration attempt was not successfull");
            CommonOutputText.WritePressKeyMessage();
        }
        else
        {
            _register.Register(_fieldValidator.FieldArray);

            CommonOutputText.WriteSuccessMessage("You have successfully registered");
            CommonOutputText.WritePressKeyMessage("Press any key to login");
        }
        
    }

    public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
    {
        _register = register;   
        _fieldValidator = fieldValidator;
    }

    private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
    {
        string? fieldValue = string.Empty;

        do
        {
            Console.Write(promptText);
            fieldValue = Console.ReadLine();
        } while (!FieldValid(field,fieldValue??string.Empty));

        return fieldValue??string.Empty;
    }

    private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue) 
    {
        bool isValid = true;
        if (_fieldValidator != null && !_fieldValidator.ValidatorDlgt((int)field, fieldValue, _fieldValidator.FieldArray, out string? invalidMessage))
        {
            CommonOutputText.WriteDangerMessage(invalidMessage);
            isValid = false;
        }
        return isValid;
    }
}
