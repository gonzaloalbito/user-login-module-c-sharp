/*
using Moq;
using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class FacebookManagerTest
{
    protected const string TEST_FACEBOOK_USERNAME = "MyFacebookUsername";
    protected const string TEST_FACEBOOK_PASSWORD = "MyFacebookPassword";
    protected static readonly Dictionary<string, string> TEST_FACEBOOK_USERS = new() {
                                                                                    {TEST_FACEBOOK_USERNAME+"1", TEST_FACEBOOK_PASSWORD+"1"},
                                                                                    {TEST_FACEBOOK_USERNAME+"2", TEST_FACEBOOK_PASSWORD+"2"},
                                                                                    {TEST_FACEBOOK_USERNAME+"3", TEST_FACEBOOK_PASSWORD+"3"},
                                                                                };
    
    [Fact]
    public void FacebookUserShouldLogInIfNotLoggedIn()
    {
        UserLoginService service = new UserLoginService();
        
        FacebookSessionManager fbSessionManager = new FacebookSessionManager();
        bool result = fbSessionManager.Login(TEST_FACEBOOK_USERNAME, TEST_FACEBOOK_PASSWORD);

        Assert.Equal(true, result);
    }
    
    [Fact]
    public void ShouldReturnExternalSessionsForAService()
    {
        UserLoginService service = new UserLoginService();
        Mock<FacebookSessionManager> fbSessionManager = new Mock<FacebookSessionManager>();
        
        foreach(KeyValuePair<string, string> user in TEST_FACEBOOK_USERS)
        {
            fbSessionManager.Login(user.Key, user.Value);
        }
        
        fbSessionManager.Setup(x => x.GetSessions()).Returns(TEST_FACEBOOK_USERS.Count);
        
        Assert.Equal(TEST_FACEBOOK_USERS.Count, fbSessionManager.GetSessions());
    }
}*/