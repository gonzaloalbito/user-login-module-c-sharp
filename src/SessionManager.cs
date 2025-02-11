namespace UserLoginKata.Src;

public interface SessionManager
{
    int GetSessions();
    bool Login(string userName, string password);
    bool Logout(string userName);
}