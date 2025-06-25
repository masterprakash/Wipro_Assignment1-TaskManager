using TaskManager.Repositories;
using TaskManager.DAL; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with SQL Server and connection string
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Urls.Add("https://localhost:7023");
app.Run();
