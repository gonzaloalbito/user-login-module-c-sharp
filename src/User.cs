namespace UserLoginKata.Src;

public class User(string name, string criticalInfo=null)
{
    public string UserName { get; } = name;
    
    public string CriticalInformation { get; } = criticalInfo;
}