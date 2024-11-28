using com.cake_lovers.www.Data;
using com.cake_lovers.www.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
var connectionString = builder.Configuration.GetConnectionString("CakeLoversDB");

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


builder.Services.AddDbContext<CakeLoversDbContext>(opt
    => opt.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ProdutoService, ProdutoService>();
builder.Services.AddScoped<ContatoService, ContatoService>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();



app.Run();
