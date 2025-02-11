namespace UserLoginKata.Src;

public class UserLoginService(SessionManager sessionManager)
{
    private readonly List<User> _loggedUsers = new();
    private readonly SessionManager _sessionManager = sessionManager;

    public string ManualLogin(User user)
    {
        if (IsUserAlreadyLogged(user))
        {
            return "User already logged in";
        }

        _loggedUsers.Add(user);
        return "User successfully logged in";
    }

    public string Login(string userName, string password)
    {
        bool isUserLogged = _sessionManager.Login(userName, password);

        if (!isUserLogged)
        {
            return "Login incorrecto";
        }

        return "Login correcto";
    }

    public string Logout(User user)
    {
        if (!IsUserAlreadyLogged(user))
        {
            return "User not found";
        }

        try
        {
            bool logoutSuccess = _sessionManager.Logout(user.UserName);
            _loggedUsers.RemoveAll(u => u.UserName == user.UserName);

            return "User logged out";
        }
        catch (ServiceNotAvailableException)
        {
            return "Service not available";
        }
        catch (UserNotLoggedInException)
        {
            return "User not logged in Facebook";
        }
    }


    public List<User> GetLoggedUsers()
    {
        return _loggedUsers;
    }

    public int GetExternalSessions()
    {
        return _sessionManager.GetSessions();
    }

    private bool IsUserAlreadyLogged(User user)
    {
        return _loggedUsers.Any(loggedUser => loggedUser.UserName == user.UserName);
    }
}
