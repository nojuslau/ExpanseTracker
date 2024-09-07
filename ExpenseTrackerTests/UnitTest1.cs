using ExpanseTracker.Entities;
using ExpanseTracker.Repository;
using Moq;

namespace ExpenseTrackerTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddExpense_InputIsExpense_ReturnList()
        {
            // Arrange
            var expense = new Expense { Description = "Lunch", Amount = 15.50m };
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AddExpense(It.IsAny<Expense>())).Verifiable();

            // Act
            mockRepository.Object.AddExpense(expense);
            var result = mockRepository.Object.GetAllExpenses();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(expense, result);
            mockRepository.Verify(r => r.AddExpense(It.IsAny<Expense>()), Times.Once);
        }

        [Fact]
        public void UpdateExpense_InputIsAmount_ReturnTrue()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void DeleteExpense_InputIsIndex_ReturnList()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void ListExpenses_ReturnList()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            //Act
            var result = mockRepository.Object.GetAllExpenses();
            //Assert
            Assert.NotEmpty(result); // Check that the list is not empty
        }

        [Fact]
        public void ExpensesSummary_ReturnList()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void ExpensesSummaryByMonth_InputIsMonth_ReturnList()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}