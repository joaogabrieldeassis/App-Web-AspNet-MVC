using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();

app.UseMvc(routes =>
{
    routes.MapRoute("default","{controller = Home}/{action=Index}/{id?}");
});

app.Run();


