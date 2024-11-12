using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.FieldValidators;

public class FieldConstants
{
    public enum UserRegistrationField
    {
        EmailAddress,
        FirstName,
        LastName,
        Password,
        PasswordCompare,
        DateOfBirth,
        PhoneNumber,
        Address1,
        Address2,
        City,
        State,
        PostalCode
    }
}
