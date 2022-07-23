using System.Globalization;
using System.Runtime.CompilerServices;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;

[assembly:InternalsVisibleTo("HazonApi")]
namespace Infrastructure.Extensions;

internal static class ApplicationBuilderExtension
{
    public static WebApplication UseInfrastructure(this WebApplication? builder,IConfiguration configuration)
    {
        var options = new RequestLocalizationOptions()
        {
            DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"))
        };
        //var builder = app.Build();
        builder.UseRequestLocalization(options);
        builder.UseStaticFiles();
        // builder.UseMiddlewares(configuration);
        builder.UseRouting();
        builder.UseCors();
        builder.UseAuthentication();
        builder.UseAuthorization();
        builder.UseHangfireDashboard("/jobs", new DashboardOptions()
        {
            DashboardTitle = "Jobs"
        });
        builder.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers().RequireAuthorization();
        });
        builder.Run();
        
        return builder;
    }
}