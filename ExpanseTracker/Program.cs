using ExpanseTracker.Controllers;
using ExpanseTracker.Entities;
using ExpanseTracker.Repository;
using System.CommandLine;

namespace ExpanseTracker;

class Program
{
    private static readonly string repositoryPath = Path.Combine(Directory.GetCurrentDirectory(), "expenses.csv");
    private static Command addCommand = new Command("add", "Add a new expense");
    private static Command updateCommand = new Command("update", "Add a new expense");
    private static Command listCommand = new Command("list", "Add a new expense");
    private static Command summaryCommand = new Command("summary", "Add a new expense");
    private static Command deleteCommand = new Command("delete", "Add a new expense");

    static async Task<int> Main(params string[] args)
    {
        var rootCommand = new RootCommand("Expense tracker application");


        if (!File.Exists(repositoryPath))
        {
            using (File.Create(repositoryPath)) { }
        }

        CommandListBuilder(rootCommand);
        CommandActions();

        return await rootCommand.InvokeAsync(args);
    }

    private static void CommandActions()
    {
        ExpenseRepository repository = new ExpenseRepository(repositoryPath);
        ExpensesController controller = new ExpensesController(repository);

        // SetHandler instead of CommandHandler
        addCommand.SetHandler((string description, decimal amount) =>
        {
            Console.WriteLine($"Received description: {description}");
            Console.WriteLine($"Received amount: {amount}");
            if (string.IsNullOrEmpty(description) || amount <= 0)
            {
                Console.WriteLine("Invalid input. Description and a positive amount are required.");
                return;
            }

            var expense = new Expense { Description = description, Amount = amount };
            repository.AddExpense(expense);

            Console.WriteLine($"Added expense: {description}, Amount: {amount}");
        },
        new Option<string>("--description"),
        new Option<decimal>("--amount"));
    }

    private static void CommandListBuilder(RootCommand rootCommand)
    {
        // Add options to the 'add' command
        var descriptionOption = new Option<string>(
            "--description",
            "Description of the expense"
        );
        var amountOption = new Option<decimal>(
            "--amount",
            "Amount of the expense"
        );
        var categoryOption = new Option<int>(
            "--category",
            "Expense category"
        );
        var idOption = new Option<int>(
            "--id",
            "id of expense"
        );
        var monthOption = new Option<int>(
            "--month",
            "month of expenses"
        );

        addCommand.AddOption(descriptionOption);
        addCommand.AddOption(amountOption);
        addCommand.AddOption(categoryOption);

        rootCommand.AddCommand(addCommand);
    }
}