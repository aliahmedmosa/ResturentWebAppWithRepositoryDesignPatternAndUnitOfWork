using Microsoft.EntityFrameworkCore;
using Resturent.Core;
using Resturent.Core.Repositories;
using Resturent.EF;
using Resturent.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(option =>
                    option.UseSqlServer(builder.Configuration.GetConnectionString("cs"),
                        b=>b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

//When use UnitOfWork just make service for it.
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

//When you use repository design pattern without unit of work you have to make service for evry IRepository and its Repository.
//builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
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

app.Run();
