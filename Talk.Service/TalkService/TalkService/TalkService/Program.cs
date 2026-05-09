using Scalar.AspNetCore;
using TalkService.Context;
using TalkService.Model;
using TalkService.Repository;
using TalkService.Services;

var builder = WebApplication.CreateBuilder(args);

var talkConfiguration = new TalkConfiguration();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(policies =>
{
    policies.AddPolicy("TalkAppServicePolicy", (policy) =>
    {
        policy.AllowAnyOrigin();
    });
});

var talkConfig = builder.Configuration.GetSection("TalkConfiguration").Get<TalkConfiguration>();
builder.Services.AddSingleton(talkConfig);

builder.Services.AddScoped<DbContext>();

//Repositories
builder.Services.AddScoped<AccountRepository>();
//Services
builder.Services.AddScoped<AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("TalkAppServicePolilcy");

app.UseAuthorization();

app.MapControllers();

app.Run();
