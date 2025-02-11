namespace UserLoginKata.Src;

public class UserLoginService
{
    private List<User> _loggedUsers = new();

    public string ManualLogin()
    {
        return "user logged";
    }

    private bool IsUserAlreadyLogged(User user)
    {
        return _loggedUsers.Any(loggedUser => loggedUser.UserName == user.UserName);
    }
}
