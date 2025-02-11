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

    [Fact]
    public void ShouldGetLoggedUsers()
    {
        UserLoginService service = new UserLoginService();
        User user1 = new User("User1");
        User user2 = new User("User2");
        var expectedUsers = new List<User> { user1, user2 };
        service.ManualLogin(user1);
        service.ManualLogin(user2);

        var loggedUsers = service.GetLoggedUsers();

        Assert.Equal(2, loggedUsers.Count);
        Assert.Equal(expectedUsers, loggedUsers);
    }

    [Fact]
    public void ShouldGetSessionsFromExternalService()
    {
        UserLoginService service = new UserLoginService();

        var externalSessions = service.GetExternalSessions();

        Assert.Equal(7, externalSessions);
    }
}