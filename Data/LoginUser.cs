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
				u => (u.Password!.Equals(password) && 
				u.EmailAddress!.ToLower().Trim().Equals(emailAddress.ToLower().Trim())));
            return user;

		}
		catch (Exception)
		{

			return null;
		}    
	}
}
