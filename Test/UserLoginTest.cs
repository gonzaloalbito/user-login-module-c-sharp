using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class UserLoginTest
{
    protected const string TEST_LOCAL_USERNAME = "MyAwesomeUsername";
    protected static readonly List<string> TEST_LOCAL_USERNAMES = new(){ TEST_LOCAL_USERNAME+"1", TEST_LOCAL_USERNAME+"2", TEST_LOCAL_USERNAME+"3" };
    
    protected const string TEST_FACEBOOK_USERNAME = "MyFacebookUsername";
    protected const string TEST_FACEBOOK_PASSWORD = "MyFacebookPassword";
    protected static readonly Dictionary<string, string> TEST_FACEBOOK_USERS = new() {
                                                                                    {TEST_FACEBOOK_USERNAME+"1", TEST_FACEBOOK_PASSWORD+"1"},
                                                                                    {TEST_FACEBOOK_USERNAME+"2", TEST_FACEBOOK_PASSWORD+"2"},
                                                                                    {TEST_FACEBOOK_USERNAME+"3", TEST_FACEBOOK_PASSWORD+"3"},
                                                                                };
    
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

        Assert.Equal(TEST_LOCAL_USERNAMES.Length, service.LoggedInUsers().Count());
       //Assert.Collection(service.LoggedInUsers, x=>TEST_USERNAMES.Contains(x));
    }
    
    [Fact]
    public void ShouldReturnExternalSessionsForAService()
    {
        UserLoginService service = new UserLoginService();
        FacebookSessionManager fbService = new FacebookSessionManager();
        
        foreach(KeyValuePair<string, string> user in TEST_FACEBOOK_USERS)
        {
            fbService.Login(user.Key, user.Value);
        }
        
        Assert.Equal(TEST_FACEBOOK_USERS.Count, service.GetExternalSessions());
    }
}