using SignalR_Service.Controller;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
app.MapHub<ClientHub>("/document");

app.Run();
