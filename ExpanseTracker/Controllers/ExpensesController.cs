using ExpanseTracker.Entities;
using ExpanseTracker.Repository;

namespace ExpanseTracker.Controllers
{
    public class ExpensesController
    {
        private readonly ExpenseRepository _repository;
        public ExpensesController(ExpenseRepository repository)
        {
            _repository = repository;
        }

        public Expense AddExpense(Expense expense)
        {
            _repository.AddExpense(expense);

            return expense;
        }

        public List<Expense> GetExpenses()
        {
            return _repository.GetAllExpenses();
        }

        public void UpdateExpense(Expense expense)
        {

        }
    }
}
