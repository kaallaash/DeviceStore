using NJsonSchema.Generation;
using System.Text.Json.Serialization;

namespace DeviceStore.Services.Users.Api;

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

        services
            .AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.AllowTrailingCommas = true;
                });

        services.AddOpenApiDocument(
            settings =>
            {
                settings.DocumentName = "openapi";
                settings.SchemaGenerator.Settings.DefaultReferenceTypeNullHandling =
                ReferenceTypeNullHandling.NotNull;
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.UseOpenApi(settings => settings.Path = "/swagger/{documentName}/swagger.json");
        app.UseSwaggerUi3(
            settings =>
            {
                settings.Path = "/swagger";
                settings.DocumentPath = "/swagger/{documentName}/swagger.json";
            });
        app.UseReDoc(
            settings =>
            {
                settings.Path = "/redoc";
                settings.DocumentPath = "/swagger/{documentName}/swagger.json";
            });
    }
}
