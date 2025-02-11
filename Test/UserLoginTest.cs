using UserLoginKata.Src;
using Xunit;
using Moq;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    private readonly Mock<SessionManager> _sessionManager;
    private readonly UserLoginService _service;

    public UserLoginTest()
    {
        _sessionManager = new Mock<SessionManager>();
        _service = new UserLoginService(_sessionManager.Object);
    }

    [Fact]
    public void ShouldLogAUser()
    {
        User user = new User("User");

        var result = _service.ManualLogin(user);

        Assert.Equal("User successfully logged in", result);
    }

    [Fact]
    public void ShouldCheckIfUserIsAlreadyLogged()
    {
        User user = new User("User");
        _service.ManualLogin(user);

        var result = _service.ManualLogin(user);

        Assert.Equal("User already logged in", result);
    }

    [Fact]
    public void ShouldGetLoggedUsers()
    {
        User user1 = new User("User1");
        User user2 = new User("User2");
        var expectedUsers = new List<User> { user1, user2 };
        _service.ManualLogin(user1);
        _service.ManualLogin(user2);

        var loggedUsers = _service.GetLoggedUsers();

        Assert.Equal(2, loggedUsers.Count);
        Assert.Equal(expectedUsers, loggedUsers);
    }

    [Fact]
    public void ShouldGetSessionsFromExternalService()
    {
        int expectedSessions = 7;
        _sessionManager.Setup(sm => sm.GetSessions()).Returns(expectedSessions);

        var externalSessions = _service.GetExternalSessions();

        Assert.Equal(expectedSessions, externalSessions);
    }
}