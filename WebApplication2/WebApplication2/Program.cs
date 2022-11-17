using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApplication2ContextConnection") ?? throw new InvalidOperationException("Connection string 'WebApplication2ContextConnection' not found.");

AddIdentityConfig(builder);
ConfigurationIdentity(builder);
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void ConfigurationDependenciInjection(WebApplicationBuilder builder)
{

}
void ConfigurationIdentity(WebApplicationBuilder builder)
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));
    });
}
void AddIdentityConfig(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<WebApplication2Context>(options =>
    options.UseSqlServer(connectionString));

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<WebApplication2Context>();
}
