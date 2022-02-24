using Microsoft.Extensions.DependencyInjection;

namespace ClassLibrary
{
    public static class ClassLibraryDependencyConfigurator
    {
        public static void ClassLibraryDependencyConfigurate(this IServiceCollection services)
        {
            services.AddScoped<IStringService, StringService>();
        }
    }
}
