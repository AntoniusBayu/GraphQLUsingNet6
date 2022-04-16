namespace GraphQLNet6
{
    public static class ServiceExtension
    {
        public static void SetupDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IConnection, RepoDBConnection>();
            services.AddTransient<IUnitofWork, RepoDBUoW>();
            services.AddTransient<IBookBusiness, BookBusiness>();
        }
    }
}
