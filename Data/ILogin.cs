using CycleClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub.Data;

public interface ILogin
{
    /// <summary>
    /// Implementation should attempt to authenticate the user
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="password"></param>
    /// <returns>The User object if login was successful or null</returns>
    User? Login(string emailAddress, string password);
}
