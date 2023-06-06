var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
