using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    protected const string TEST_USERNAME = "user";
    
    [Fact]
    public void ShouldLogAUser()
    {
        var service = new UserLoginService();

        User user = new User(TEST_USERNAME);
        string result = service.ManualLogin(user);

        Assert.Equal(UserLoginService.SUCCESS_LOGIN, result);
    }
    
    [Fact]
    public void ShouldNotLogTwice()
    {
        var service = new UserLoginService();

        User user = new User(TEST_USERNAME);
        User repeatedUser = new User(TEST_USERNAME);
        service.ManualLogin(user);
        var result = service.ManualLogin(repeatedUser);
        
        Assert.Equal(UserLoginService.ERROR_ALREADY_LOGGED_IN, result);
    }
}