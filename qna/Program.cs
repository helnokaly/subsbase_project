using qna;
using qna.DbContexts;
using Microsoft.EntityFrameworkCore;
using qna.Services;
using qna.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => {
    options.ReturnHttpNotAcceptable = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add QuestionsDataStore singleton service
// builder.Services.AddSingleton<QuestionsDataStore>();

builder.Services.AddDbContext<QnaContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:QnaDbConnectionString"]
    )
);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.Use(async (ctx, next) =>
// {
//     var authService = ctx.RequestServices.GetService<AuthService>();
//     IGreeter greeter = ctx.RequestServices.GetService<IGreeter>();
//     await ctx.Response.WriteAsync(greeter.Greet());
//     await next();
// });

app.UseAuthMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
