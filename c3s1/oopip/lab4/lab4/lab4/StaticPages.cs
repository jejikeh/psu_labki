using System.Text;

namespace lab4;

public static class StaticPages
{
    public static byte[] SubscribeToUpdateMovies(string userId)
    {
        return Encoding.UTF8.GetBytes($"User {userId} subscribed to update movies");
    }
    
    public static byte[] UnSubscribeToUpdateMovies(string userId)
    {
        return Encoding.UTF8.GetBytes($"User {userId} unsubscribed to update movies");
    }
    
    public static byte[] SeeUpdateMovies(string userId)
    {
        return Encoding.UTF8.GetBytes($"For user {userId} see update movies");
    }
}