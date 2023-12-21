using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pinkshop.Areas.Identity.Data;
using pinkshop.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebDB") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

builder.Services.AddDbContext<IdentityContext>(options => 
options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppDBContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add sesion
builder.Services.AddDistributedMemoryCache();           // ??ng ký d?ch v? l?u cache trong b? nh? (Session s? s? d?ng nó)
builder.Services.AddSession(options => {                    // ??ng ký d?ch v? Session
    options.Cookie.Name = "quocbaolab";             // ??t tên Session - tên này s? d?ng ? Browser (Cookie)
    options.IdleTimeout = new TimeSpan(0, 30, 0);    // Th?i gian t?n t?i c?a Session
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
