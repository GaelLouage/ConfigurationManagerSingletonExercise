using Microsoft.AspNetCore.Mvc.Infrastructure;
using SingletonPatternExercise.Singletons;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var configManager = ConfigurationManagerSingleton.Instance;
app.MapGet("/addy", () => 
{
    (bool IsAdded, string Message) = configManager.AddSettings("AppName", "MyApplication");
    if (IsAdded)
    {
        return Results.Ok(Message);
    }
    return Results.Ok(Message);
});

app.MapGet("/get", () =>
{
    try
    {
        var config = configManager.Get<string>("AppName");
        return Results.Ok(config);
    }
    catch (Exception ex) 
    {
        return Results.NotFound(ex.Message);
    }

});

app.MapGet("/remove", () =>
{
    (bool IsAdded, string Message) = configManager.RemoveSettings("AppName");
    if (IsAdded)
    {
        return Results.Ok(Message);
    }
    return Results.Ok(Message);
});
app.Run();
