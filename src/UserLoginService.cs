namespace UserLoginKata.Src;

public class UserLoginService
{
    private List<User> _loggedUsers = new();

    public string ManualLogin(User user)
    {
        if (IsUserAlreadyLogged(user))
        {
            return "User already logged in";
        }

        _loggedUsers.Add(user);
        return "User successfully logged in";
    }

    private bool IsUserAlreadyLogged(User user)
    {
        return _loggedUsers.Any(loggedUser => loggedUser.UserName == user.UserName);
    }
}
