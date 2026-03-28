namespace perla_metro_users_service.Util;

public class Roles
{
    
    private Roles() {}

    public static string GetNameRol(int type)
    {
        if (type == 1)
        {
            return "Admin";
        }

        return "User";
    }
    

}