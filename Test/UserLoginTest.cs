using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    [Fact]
    public void ShouldLogAUser()
    {
        UserLoginService service = new UserLoginService();
        User user = new User("User");

        var result = service.ManualLogin(user);

        Assert.Equal("User successfully logged in", result);
    }

    [Fact]
    public void ShouldCheckIfUserIsAlreadyLogged()
    {
        UserLoginService service = new UserLoginService();
        User user = new User("User");
        service.ManualLogin(user);

        var result = service.ManualLogin(user);

        Assert.Equal("User already logged in", result);
    }
}