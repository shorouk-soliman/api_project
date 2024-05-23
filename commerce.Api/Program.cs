using commerce.DAL;
using commerce.BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using commerce.DAL.Data.Model;
using commerce.Api;
using commerce.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext and other services using your extension method
builder.Services.AddDALServices(builder.Configuration);

// Adding BL services 
builder.Services.AddBLServices();

// Adding identity services 
builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<EcommerceContext>();

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "MyDefault";
    options.DefaultChallengeScheme = "MyDefault"; 
})
.AddJwtBearer("MyDefault", options =>
{
    var keyFromConfig = builder.Configuration.GetValue<string>("SecretKey");
    var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
    var key = new SymmetricSecurityKey(keyInBytes);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = key
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Ensure authentication is used before authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
