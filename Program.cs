using com.cake_lovers.www.Data;
using com.cake_lovers.www.Models;
using com.cake_lovers.www.Services;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
var connectionString = builder.Configuration.GetConnectionString("CakeLoversDB");

var defaultCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;



builder.Services.AddDbContext<CakeLoversDbContext>(opt
    => opt.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<ProdutoService, ProdutoService>();
builder.Services.AddScoped<AdminServices, AdminServices>();
builder.Services.AddScoped<IPedidoRepository, EFPedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, EFProdutoRepository>();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new[] { defaultCulture },
    SupportedUICultures = new[] { defaultCulture }
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "category",
    pattern: "{category}",
    defaults: new { Controller = "Carrinho", action = "GetAllProdutos", productPage = 1 });
app.MapRazorPages();
SeedData.EnsurePopulated(app);
app.Run();
