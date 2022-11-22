using Courses.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Identity;
using Courses;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=courses;Trusted_Connection=True;");
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();


var app = builder.Build();



// Configure the HTTP request pipeline.



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}
else
{
    using (var scope = app.Services.CreateScope())
    {

        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        context.Database.EnsureCreated();

        string[] roles = { "Admin", "User", "Manager" };
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in roles)
        {
            var roleExists = await roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var admin = context.Users.FirstOrDefault(x => x.Id == "33505884-4a6a-47cb-88ad-afdee4e47cbc");
        var manager = context.Users.FirstOrDefault(x => x.Id == "0ea6d8de-d7f2-4c54-b4a0-54b13db0e068");
        await userManager.AddToRoleAsync(manager,"Manager");
        await userManager.AddToRoleAsync(admin,"Admin");

    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name : "events",
    pattern: "{controller=Events}/{action=Index}/{param?}");

app.MapRazorPages();

app.Run();
