using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
        //inject MovieService Class that implement IMovieService Interface
        //easy to inject new implementation: lbuilder.Services.AddScoped<IMovieService, NewClass>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

//
builder.Services.AddHttpContextAccessor();



//inject the connection string to our Dbcontext by reading from appsetting.json file
builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});


//inject the authentiacation cookie information
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie( options =>
    {
        options.Cookie.Name = "MovieShopAuthCookie";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.LoginPath = "/Account/Login";
    });



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

// before the authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(

    // default
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
