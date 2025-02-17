namespace UserLoginKata.Src;

public class UserLoginService
{
    public const string SUCCESS_LOGIN = "User successfully logged in";
    public const string ERROR_ALREADY_LOGGED_IN = "User successfully logged in";
    
    
    private List<User> _loggedUsers = new();

    public string ManualLogin(User user)
    {
        if (IsUserAlreadyLogged(user))
        {
            return SUCCESS_LOGIN;
        }
        _loggedUsers.Add(user);
        return ERROR_ALREADY_LOGGED_IN;
    }

    private bool IsUserAlreadyLogged(User user)
    {
        return _loggedUsers.Any(loggedUser => loggedUser.UserName == user.UserName);
    }
}
