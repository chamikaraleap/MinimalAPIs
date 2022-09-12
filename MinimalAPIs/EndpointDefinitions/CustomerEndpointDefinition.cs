using MinimalAPIs.Models;
using MinimalAPIs.Repositories;
using MinimalAPIs.Source;

namespace MinimalAPIs.EndpointDefinitions
{
    public class CustomerEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/create-customer/{name}", CreateCustomer);
            app.MapGet("customers", GetCustomers);
        }

        internal IResult CreateCustomer(ICustomerRepositoriy repo, string name)
        {
            var cusomer = repo.CreateCustomer(name);
            return Results.Ok(cusomer);
        }

        internal IEnumerable<Customer> GetCustomers (ICustomerRepositoriy repo)
        {
            return repo.GetCustomers();
        }


        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepositoriy, CustomerRepositoriy>();
        }
    }
}
