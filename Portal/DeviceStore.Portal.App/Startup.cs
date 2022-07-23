using DeviceStore.Services.Users;
using DeviceStore.Services.Warehouse;

namespace DeviceStore.Portal.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddUsers(Configuration);
        services.AddWarehouse(Configuration);

        //services.AddDbContext<UsersDbContext>(options =>
        //    options.UseNpgsql(Configuration.GetConnectionString("UsersDb")));

        //services.AddIdentity<User, IdentityRole>()
        //    .AddEntityFrameworkStores<UsersDbContext>();

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}");
        });
    }
}
