using CycleClub.Models;

namespace CycleClub.Data;

public class LoginUser : ILogin
{
    public User? Login(string emailAddress, string password)
    {
		try
		{
			CycleClubDbContext db = new();
			User? user = db.Users.FirstOrDefault(
				u => u.EmailAddress!.Trim().Equals(emailAddress.Trim(), StringComparison.CurrentCultureIgnoreCase)
				&& u.Password!.Equals(password));
			return user;

		}
		catch (Exception)
		{

			return null;
		}    
	}
}
