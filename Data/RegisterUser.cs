using CycleClub.FieldValidators;
using CycleClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.Data;

internal class RegisterUser : IRegister
{
    public bool EmailExists(string emailAddress)
    {
        return new CycleClubDbContext().Users
            .Any(u => u.EmailAddress != null && u.EmailAddress.ToLower().Trim() == emailAddress.ToLower().Trim());
    }

    /// <summary>
    /// Accepts a validted array of registration form field data and inserts into the Users table.
    /// </summary>
    /// <param name="fields"></param>
    /// <returns>true if the insert was successful, false otherwise</returns>
    public bool Register(string[] fields)
    {
        User user = new()
        {
            EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
            FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
            LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
            Password = fields[(int)FieldConstants.UserRegistrationField.Password],
            DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
            PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
            Address1 = fields[(int)FieldConstants.UserRegistrationField.Address1],
            Address2 = fields[(int)FieldConstants.UserRegistrationField.Address2],
            City = fields[(int)FieldConstants.UserRegistrationField.City],
            State = fields[(int)FieldConstants.UserRegistrationField.State],
            PostalCode = fields[(int)FieldConstants.UserRegistrationField.PostalCode],
        };

        CycleClubDbContext db = new();
        db.Users.Add(user);
        db.SaveChanges();

        return true;
    }
}
