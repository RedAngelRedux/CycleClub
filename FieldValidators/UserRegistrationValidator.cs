using CycleClub.Data;
using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.FieldValidators;

public class UserRegistrationValidator : IFieldValidator
{
    const int FIRST_NAME_MIN_LENGTH = 2;
    const int FIRST_NAME_MAX_LENGTH = 100;
    const int LAST_NAME_MIN_LENGTH = 2;
    const int LAST_NAME_MAX_LENGTH = 100;

    delegate bool EmailExistsDlgt(string emailAddress);

    FieldValidatorDlgt? _fieldValidatorDlgt = null;

    RequiredDlgt? _requiredDlgt = null;
    StringLengthDlgt? _validStringLengthDlgt = null;
    DateTimeDlgt? _validDateTimeDlgt = null;
    PatternMatchDlgt? _validPatternMatchDlgt = null;
    CompareFieldsDlgt? _validFieldComparisonDlgt = null;

    EmailExistsDlgt? _emailExistsDlgt = null;

    private string[]? _fieldArray = null;
    IRegister? _register = null;

    public string[] FieldArray
    {
        get
        {
            _fieldArray ??= new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
            return _fieldArray;
        }
    }

    public FieldValidatorDlgt ValidatorDlgt => _fieldValidatorDlgt!;

    public void InitializeValidatorDelegates()
    {
        _fieldValidatorDlgt = ValidateField;
        _emailExistsDlgt = (_register is not null) ? _register.EmailExists : null;

        _requiredDlgt = CommonFieldValidatorFunctions.ValidateRequiredField;
        _validStringLengthDlgt = CommonFieldValidatorFunctions.ValiddateStringLength;
        _validDateTimeDlgt = CommonFieldValidatorFunctions.ValidateDateTime;
        _validPatternMatchDlgt = CommonFieldValidatorFunctions.ValidatePattern;
        _validFieldComparisonDlgt = CommonFieldValidatorFunctions.ValidateFieldComparison;
    }

    private bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
    {
        fieldInvalidMessage = string.Empty;

        FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

        var eName = Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField);
        var newLine = Environment.NewLine;

        // TO-DO:  I would add a max lenght validator to all based on any database maximums
        // TO-DO:  For State, only allow valid US State and territory abbreviations

        switch (userRegistrationField)
        {
            case FieldConstants.UserRegistrationField.DateOfBirth:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validDateTimeDlgt is null || !_validDateTimeDlgt(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date" : fieldInvalidMessage);
                break;
            case FieldConstants.UserRegistrationField.EmailAddress:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validPatternMatchDlgt is null || !_validPatternMatchDlgt(fieldValue, CommonRegularExpressionValidation.EMAIL_REGEX))) ? $"Invalid {eName} Format{newLine}" : fieldInvalidMessage;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_emailExistsDlgt is null || _emailExistsDlgt(fieldValue)) ? $"{eName} Already exists.  Please try again.{newLine}" : fieldInvalidMessage);
                break;
            case FieldConstants.UserRegistrationField.FirstName:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validStringLengthDlgt is null || !_validStringLengthDlgt(fieldValue, FIRST_NAME_MIN_LENGTH, FIRST_NAME_MAX_LENGTH))) ? $"The length of {eName} must be at least {FIRST_NAME_MIN_LENGTH} and mo more than {FIRST_NAME_MAX_LENGTH}{newLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.LastName:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validStringLengthDlgt is null || !_validStringLengthDlgt(fieldValue, LAST_NAME_MIN_LENGTH, LAST_NAME_MAX_LENGTH))) ? $"The length of {eName} must be at least {FIRST_NAME_MIN_LENGTH} and mo more than {FIRST_NAME_MAX_LENGTH}{newLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.Password:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validPatternMatchDlgt is null || !_validPatternMatchDlgt(fieldValue, CommonRegularExpressionValidation.STRONG_PASSWORD_REGEX))) ? $"Invalid {eName} Format {newLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.PasswordCompare:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validFieldComparisonDlgt is null || !(_validFieldComparisonDlgt(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password]))) ? $"Must Match {eName}{newLine}" : fieldInvalidMessage);
                break;
            case FieldConstants.UserRegistrationField.PhoneNumber:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validPatternMatchDlgt is null || !_validPatternMatchDlgt(fieldValue, CommonRegularExpressionValidation.US_PHONE_REGEX)) ? $"You did not enter a valid phone number" : fieldInvalidMessage);
                break;
            case FieldConstants.UserRegistrationField.Address1:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                break;
            case FieldConstants.UserRegistrationField.Address2:
                // This is an optional field
                break;
            case FieldConstants.UserRegistrationField.City:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                break;
            case FieldConstants.UserRegistrationField.State:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validStringLengthDlgt is null || !_validStringLengthDlgt(fieldValue, FIRST_NAME_MIN_LENGTH, FIRST_NAME_MIN_LENGTH))) ? $"Only valid {FIRST_NAME_MIN_LENGTH} character state abbrieviations allowed." : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.PostalCode:
                fieldInvalidMessage = (_requiredDlgt is null || !_requiredDlgt(fieldValue)) ? $"You must enter a value for field {eName}{newLine}" : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && (_validPatternMatchDlgt is null || !_validPatternMatchDlgt(fieldValue, CommonRegularExpressionValidation.US_POSTAL_CODE_REGEX)) ? $"You did not enter a valid zip code" : fieldInvalidMessage);
                break;
            default:
                throw new ArgumentException("This field does not exist");
        }

        return (fieldInvalidMessage == string.Empty);
    }
    public UserRegistrationValidator(IRegister register)
    {
        _register = register;
    }
}
