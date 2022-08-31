using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TpDojo.Business;
using TpDojo.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TpDojoWEBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TpDojoWEBContext") ?? throw new InvalidOperationException("Connection string 'TpDojoWEBContext' not found.")));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<SamouraiService>();
builder.Services.AddTransient<SamouraiAccessLayer>();
builder.Services.AddTransient<ArmeService>();
builder.Services.AddTransient<ArmeAccessLayer>();

// Add services to the container.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
