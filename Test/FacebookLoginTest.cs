using UserLoginKata.Src;
using Xunit;

namespace UserLoginKata.Test;

public class FacebookLoginTest
{
    protected const string TEST_FACEBOOK_USERNAME = "MyFacebookUsername";
    protected const string TEST_FACEBOOK_PASSWORD = "MyFacebookPassword";
    protected static readonly Dictionary<string, string> TEST_FACEBOOK_USERS = new() {
                                                                                    {TEST_FACEBOOK_USERNAME+"1", TEST_FACEBOOK_PASSWORD+"1"},
                                                                                    {TEST_FACEBOOK_USERNAME+"2", TEST_FACEBOOK_PASSWORD+"2"},
                                                                                    {TEST_FACEBOOK_USERNAME+"3", TEST_FACEBOOK_PASSWORD+"3"},
                                                                                };
    
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