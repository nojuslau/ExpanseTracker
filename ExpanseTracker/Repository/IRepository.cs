using ExpanseTracker.Entities;

namespace ExpanseTracker.Repository
{
    public interface IRepository
    {
        List<Expense> GetAllExpenses();
        List<Expense> GetAllExpensesByCategory(int status);
        void AddExpense(Expense expense);
        void UpdateExpenses(List<Expense> expensesToUpdate);
        void DeleteExpenses(string id);
    }
}
