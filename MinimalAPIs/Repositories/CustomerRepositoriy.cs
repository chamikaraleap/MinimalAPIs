using MinimalAPIs.Models;

namespace MinimalAPIs.Repositories
{
    public class CustomerRepositoriy: ICustomerRepositoriy
    {
        List<Customer> customers = new List<Customer>();
        public Customer CreateCustomer (string name)
        {
            var customer = new Customer(Guid.NewGuid(), name);
            customers.Add(customer);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
