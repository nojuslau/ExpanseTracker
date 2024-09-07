using CsvHelper;
using CsvHelper.Configuration;
using ExpanseTracker.Entities;
using System.Globalization;

namespace ExpanseTracker.Repository
{
    public class ExpenseRepository
    {
        private string repositoryPath = "";
        private CsvConfiguration configuration;

        public ExpenseRepository(string repoPath) 
        {
            repositoryPath = repoPath; 
            configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
        }

        public void AddExpense(Expense newExpense)
        {
            using (var writer = new StreamWriter(repositoryPath))
            {
                using (var csv = new CsvWriter(writer, configuration))
                {
                    csv.Context.RegisterClassMap<CsvFileMap>();

                    csv.WriteHeader<Expense>();
                    csv.NextRecord();
                    csv.WriteRecord(newExpense);
                }
            }
        }

        public List<Expense> GetAllExpenses()
        {
            using (var reader = new StreamReader(repositoryPath))
            {
                using (var csv = new CsvReader(reader, configuration))
                {
                    var expenses = csv.GetRecords<Expense>().ToList();

                    return expenses;
                }
            }
        }
    }
}
