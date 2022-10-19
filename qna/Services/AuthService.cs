using qna.Entities;
using qna.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace qna.Services;

public class AuthService : IAuthService
{
    private readonly QnaContext _context;

    public AuthService(QnaContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<string?> GetAuthtoken(string username, string password)
    {
        var user = await _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        if (user == null)
        {
            return null;
        }

        return user.AuthId;
    }

    public async Task<int> GetUserIdForToken(string token)
    {
        var user = await _context.Users.Where(u => u.AuthId == token).FirstOrDefaultAsync();
        if (user == null)
        {
            return -1;
        }

        return user.Id;
    }
}
