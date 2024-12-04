using BlogNew.Data.Abstract;
using BlogNew.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var con = config.GetConnectionString("mssql_connection");
    options.UseSqlServer(con);
});
builder.Services.AddScoped<IPostRepository,EfPostRepository>(); //her interface çaðýrdýgýmýzda gerçek nesne üretip çaðýrmamýz lazým
builder.Services.AddScoped<ITagRepository,EfTagRepository>();
var app = builder.Build();
SeedData.TestVerileriniDoldur(app);

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
