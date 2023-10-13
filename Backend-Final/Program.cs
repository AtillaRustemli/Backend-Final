using Backend_Final;
using Backend_Final.Otions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.Register(config);
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<EmailConfigureOptions>(builder.Configuration.GetSection(nameof(EmailConfigureOptions)));
builder.Configuration
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddEnvironmentVariables();


var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
         );
app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"
    );

app.Run();
