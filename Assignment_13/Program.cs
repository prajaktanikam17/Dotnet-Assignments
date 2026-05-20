using Assignment_13.Filters;

var builder = WebApplication.CreateBuilder(args);

// register mvc services and filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomAuthorizationFilter>();
    options.Filters.Add<CustomResourceFilter>();
    options.Filters.Add<CustomActionFilter>();
    options.Filters.Add<CustomExceptionFilter>();
    options.Filters.Add<CustomResultFilter>();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();