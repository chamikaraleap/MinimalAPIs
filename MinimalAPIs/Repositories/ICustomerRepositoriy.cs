using MinimalAPIs.Models;

namespace MinimalAPIs.Repositories
{
    public interface ICustomerRepositoriy
    {
        Customer CreateCustomer(string name);
        IEnumerable<Customer> GetCustomers();
    }
}
