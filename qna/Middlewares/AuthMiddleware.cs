using qna.Services;
using System.Text.RegularExpressions;

namespace qna.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private string[] _ignoredPaths = { "/login" };

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (_ignoredPaths.Contains<string>(context.Request.Path))
        {
            await _next(context);
            return;
        }
        var authHeader = context.Request.Headers["Authorization"];
        if (authHeader.Count == 0)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        Regex rx = new Regex("^Bearer (.+)$");
        MatchCollection matches = rx.Matches(authHeader);
        if (matches.Count == 0)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        var token = matches[0].Groups[1].Value;
        var authService = context.RequestServices.GetService<IAuthService>() ?? throw new Exception("Auth service not registered");
        var userId = await authService.GetUserIdForToken(token);
        if  (userId == -1)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        context.Items["USER_ID"] = userId;
        await _next(context);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class AuthMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthMiddleware>();
    }
}
