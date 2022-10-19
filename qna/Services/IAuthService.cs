using qna.Entities;

namespace qna.Services;

public interface IAuthService
{
    Task<string?> GetAuthtoken(string username, string password);

    Task<int> GetUserIdForToken(string token);
}
