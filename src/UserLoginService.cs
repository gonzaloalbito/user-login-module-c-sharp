namespace UserLoginKata.Src;

public class UserLoginService
{
    public const string SUCCESS_LOGIN = "User successfully logged in";
    public const string ERROR_ALREADY_LOGGED_IN = "User successfully logged in";

    private List<User> _loggedUsers = new();

    public IEnumerable<string> LoggedInUsers() => this._loggedUsers.Select(x => x.UserName);

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

    public int GetExternalSessions()
    {
        FacebookSessionManager facebookSessionManager = new FacebookSessionManager();
        return facebookSessionManager.GetSessions();
    }
}