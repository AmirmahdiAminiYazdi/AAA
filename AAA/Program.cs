using AAA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AAADbContext>(x=>x.UseNpgsql(connectionString));
builder.Services.AddIdentity<IdentityUser,IdentityRole>(x=>
{
    //example 1
    x.Password.RequiredLength = 4;
    x.Password.RequiredUniqueChars = 2;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AAADbContext>();
builder.Services.AddRazorPages();
builder.Services.AddMvc();

//example 2
//builder.Services.Configure<IdentityOptions>(c =>
//{

//});

var app = builder.Build();


app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
