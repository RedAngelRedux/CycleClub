using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.Data;

public interface IRegister
{
    /// <summary>
    /// Implementation should take a validated array of fields and insert them into the database
    /// </summary>
    /// <param name="fields"></param>
    /// <returns>true of insert successfull, false otherwise</returns>
    bool Register(string[] fields);
    /// <summary>
    /// Checks to see if the email address already exists in the database
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <returns>true if it does, false otherwise</returns>
    bool EmailExists(string emailAddress);
}
