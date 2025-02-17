using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    protected const string TEST_USERNAME = "MyAwesomeUsername";
    protected static readonly string[] TEST_USERNAMES = { "MyAwesomeUsername0", "MyAwesomeUsername1", "MyAwesomeUsername2" };
    
    [Fact]
    public void UserShouldLogInIfNotLoggedIn()
    {
        UserLoginService service = new UserLoginService();
        User user = new User(TEST_USERNAME);
        string result = service.ManualLogin(user);

        Assert.Equal(UserLoginService.SUCCESS_LOGIN, result);
    }
    
    [Fact]
    public void UserShouldNotLogInIfAlreadyLoggedIn()
    {
        UserLoginService service = new UserLoginService();
        User user = new User(TEST_USERNAME);
        User repeatedUser = new User(TEST_USERNAME);
        
        service.ManualLogin(user);
        string result = service.ManualLogin(repeatedUser);
        
        Assert.Equal(UserLoginService.ERROR_ALREADY_LOGGED_IN, result);
    }
    
    [Fact]
    public void ShouldReturnTheLoggedInUsers()
    {
        UserLoginService service = new UserLoginService();
        foreach(string username in TEST_USERNAMES)
        {
            User user = new User(username);
            service.ManualLogin(user);
        }

        Assert.Equal(TEST_USERNAMES.Length, service.LoggedInUsers.Count());
        Assert.Collection(service.LoggedInUsers, x=>TEST_USERNAMES.Contains(x));
    }
}