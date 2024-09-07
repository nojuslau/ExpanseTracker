namespace ExpanseTracker.Entities
{
    public class Expense
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public Expense() { }

        public Expense(string description, decimal amount) 
        {
            Description = description;
            Amount = amount;
        }
    }
}
