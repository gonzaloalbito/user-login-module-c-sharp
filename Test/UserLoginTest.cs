using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    [Fact]
    public void ShouldLogAUser()
    {
        var service = new UserLoginService();

        var result = service.ManualLogin();

        Assert.Equal("user logged", result);
    }
}