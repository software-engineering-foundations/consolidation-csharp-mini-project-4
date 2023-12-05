using Library.Models;

namespace Library.Repositories;

public interface ICustomerRepo
{
    List<Customer> GetCustomers(string? search = "");
    Customer GetCustomerByLibraryCardNumber(string libraryCardNumber);
    Customer CreateCustomer(Customer customerModel);
    void UpdateCustomer(string libraryCardNumber, Customer customerModel);
    void DeleteCustomer(string libraryCardNumber);
}

public class CustomerRepo : ICustomerRepo
{
    public List<Customer> GetCustomers(string? search = "")
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomerByLibraryCardNumber(string libraryCardNumber)
    {
        throw new NotImplementedException();
    }

    public Customer CreateCustomer(Customer customerModel)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(string libraryCardNumber, Customer customerModel)
    {
        throw new NotImplementedException();
    }

    public void DeleteCustomer(string libraryCardNumber)
    {
        throw new NotImplementedException();
    }
}
