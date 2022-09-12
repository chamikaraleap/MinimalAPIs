using System.Runtime.CompilerServices;

namespace MinimalAPIs.Source
{
    public static class EndpointDefinitionExtensions
    {
        public static void AddEndPointDefinitions(this IServiceCollection services, params Type[] scanMarers)
        {
            var endPointDefinitions = new List<IEndpointDefinition>();

            foreach (var scanMarersType in scanMarers)
            {
                var definitions = scanMarersType.Assembly.GetExportedTypes()
                    .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && x.IsClass)
                    .Select(Activator.CreateInstance).Cast<IEndpointDefinition>();

                endPointDefinitions.AddRange(definitions);
            }

            foreach (var endpointDefinition in endPointDefinitions)
            {
                endpointDefinition.DefineServices(services);
            }

            services.AddSingleton(endPointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
        }

        public static void UseEndpointDefinitions (this WebApplication app)
        {
            var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
            foreach ( var endpointDefinition in definitions)
            {
                endpointDefinition.DefineEndpoints(app);
            }
        }
    }
}
