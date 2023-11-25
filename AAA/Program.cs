using AAA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AAADbContext>(x=>x.UseNpgsql(connectionString));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AAADbContext>();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
