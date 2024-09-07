using CsvHelper.Configuration;

namespace ExpanseTracker.Entities
{
    public class CsvFileMap : ClassMap<Expense>
    {
        public CsvFileMap() 
        {
            Map(m => m.Id).Name("ExpenseId");
            Map(m => m.Description).Name("Description");
            Map(m => m.Amount).Name("Amount");
        }
    }
}
