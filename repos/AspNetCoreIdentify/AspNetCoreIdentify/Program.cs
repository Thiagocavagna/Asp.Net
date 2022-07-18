using AspNetCoreIdentity.Config;
using AspNetCoreIdentity.Extensions;
using KissLog.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

//Para funcionar vários arquivos Json para ambientes 
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Adicionando suporte ao secrets apenas em ambiente de produção, retire este IF se deseja aplicar os secrets para qualquer ambiente.
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddUserSecrets<Program>();
}


builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddAuthorizationConfig();
builder.Services.ResolveDependencies();
builder.Services.RegisterKissLogListeners();

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(AuditoriaFilter));
});

// Adicionando suporte a componentes Razor (ex. Telas do Identity)
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseKissLogMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Mapeando componentes Razor Pages (ex: Identity)
app.MapRazorPages();

app.RegisterKissLogListeners(builder.Configuration);

app.Run();
