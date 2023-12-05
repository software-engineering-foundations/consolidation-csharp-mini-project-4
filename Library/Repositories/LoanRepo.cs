using Library.Models;

namespace Library.Repositories;

public interface ILoanRepo
{
    List<Loan> GetLoans();
    List<Loan> GetLoansByCustomer(string libraryCardNumber);
    List<Loan> GetLoansByBook(int bookId);
    Loan GetLoanById(int id);
    Loan CreateLoan(Loan loanModel);
    void UpdateLoan(int id, Loan loanModel);
    void DeleteLoan(int id);
}

public class LoanRepo : ILoanRepo
{
    public List<Loan> GetLoans()
    {
        throw new NotImplementedException();
    }

    public List<Loan> GetLoansByCustomer(string libraryCardNumber)
    {
        throw new NotImplementedException();
    }

    public List<Loan> GetLoansByBook(int bookId)
    {
        throw new NotImplementedException();
    }

    public Loan GetLoanById(int id)
    {
        throw new NotImplementedException();
    }

    public Loan CreateLoan(Loan loanModel)
    {
        throw new NotImplementedException();
    }

    public void UpdateLoan(int id, Loan loanModel)
    {
        throw new NotImplementedException();
    }

    public void DeleteLoan(int id)
    {
        throw new NotImplementedException();
    }
}
