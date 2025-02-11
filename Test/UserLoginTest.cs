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

    [Fact]
    public void ShouldLoginUserWithCorrectCredentials()
    {
        _sessionManager.Setup(sm => sm.Login("user1Name", "user1Password")).Returns(true);

        var result = _service.Login("user1Name", "user1Password");

        Assert.Equal("Login correcto", result);
    }

    [Fact]
    public void ShouldNotLoginUserWithIncorrectCredentials()
    {
        _sessionManager.Setup(sm => sm.Login("user1Name", "user1Password")).Returns(false);

        var result = _service.Login("user1Name", "user1Password");

        Assert.Equal("Login incorrecto", result);
    }

    [Fact]
    public void ShouldLogoutUserIfUserIsAlreadyLoggedIn()
    {
        User user = new User("user1");
        _service.ManualLogin(user);
        _sessionManager.Setup(sm => sm.Logout(user.UserName)).Returns(true);

        var result = _service.Logout(user);

        _sessionManager.Verify(sm => sm.Logout(user.UserName), Times.Once);
        Assert.Equal("User logged out", result);
    }

    [Fact]
    public void ShouldNotLogoutUserIfUserIsNotFound()
    {
        User user = new User("user1");

        var result = _service.Logout(user);

        _sessionManager.Verify(sm => sm.Logout(It.IsAny<string>()), Times.Never);
        Assert.Equal("User not found", result);
    }
}