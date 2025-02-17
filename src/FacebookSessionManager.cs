namespace UserLoginKata.Src;

public class FacebookSessionManager : SessionManager
{
    public virtual int GetSessions()
    {
        //Imaginad que esto en realidad realiza una llamada al API de Facebook
        return (int)(new Random().NextDouble() * 100);
    }

    public bool Login(string userName, string password)
    {
        //Imaginad que esto en realidad realiza una llamada al API de Facebook
        return new Random().NextDouble() < 0.5;
    }

    public bool Logout(string userName)
    {
        //Imaginad que esto en realidad realiza una llamada al API de Facebook
        return new Random().NextDouble() < 0.5;
    }
}