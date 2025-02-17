using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    protected const string TEST_LOCAL_USERNAME = "MyAwesomeUsername";
    protected static readonly List<string> TEST_LOCAL_USERNAMES = new(){ TEST_LOCAL_USERNAME+"1", TEST_LOCAL_USERNAME+"2", TEST_LOCAL_USERNAME+"3" };
    
    [Fact]
    public void UserShouldLogInIfNotLoggedIn()
    {
        UserLoginService service = new UserLoginService();
        User user = new User(TEST_LOCAL_USERNAME);
        string result = service.ManualLogin(user);

        Assert.Equal(UserLoginService.SUCCESS_LOGIN, result);
    }
    
    [Fact]
    public void UserShouldNotLogInIfAlreadyLoggedIn()
    {
        UserLoginService service = new UserLoginService();
        User user = new User(TEST_LOCAL_USERNAME);
        User repeatedUser = new User(TEST_LOCAL_USERNAME);
        
        service.ManualLogin(user);
        string result = service.ManualLogin(repeatedUser);
        
        Assert.Equal(UserLoginService.ERROR_ALREADY_LOGGED_IN, result);
    }
    
    [Fact]
    public void ShouldReturnTheLoggedInUsers()
    {
        UserLoginService service = new UserLoginService();
        foreach(string username in TEST_LOCAL_USERNAMES)
        {
            User user = new User(username);
            service.ManualLogin(user);
        }

        Assert.Equal(TEST_LOCAL_USERNAMES, service.GetLoggedInUsers());
    }
}