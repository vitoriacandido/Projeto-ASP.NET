using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Registrar o contexto do banco com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();






//  var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddRazorPages();
//var app = builder.Build();
// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
// { 
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production ////scenarios, see https://aka.ms/aspnetcore-hsts.
// app.UseHsts();
//}
// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseAuthorization();
// app.MapRazorPages();
// app.Run();
