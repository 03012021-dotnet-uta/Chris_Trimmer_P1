using Xunit;
using Models.Models;

namespace PizzaBox.Testing
{
    /// <summary>
    /// This is the testing class for Customers
    /// Right now this is just a basic test to
    /// set up the testing framework.
    /// It tests to ensure a customer is instantiated
    /// with a null name, and that their order count
    /// starts at 0 when created.
    /// </summary>
    public class CustomerTests
    {

        [Fact]
        public void Test_CustomerName_Fact()
        {
            var sut = new Acustomer();
            string expected = null;

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("John Smith")]
        public void Test_CustomerName_Theory(string expected)
        {
            var sut = new Acustomer();
            var actual = sut.Name;
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Test_CustomerOrders_Theory(int expected)
        {

            var sut = new Acustomer();


            var actual = sut.Aorders.Count;


            Assert.Equal(expected, actual);
        }

    }
}
