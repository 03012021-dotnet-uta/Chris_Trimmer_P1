using Xunit;
using Models.Models;


namespace PizzaBox.Testing
{
    public class OrderTests
    {
        /// <summary>
        /// This is the testing class for Orders
        /// Right now this is just a basic test to
        /// set up the testing framework.
        /// It tests to ensure a order is instantiated
        /// with an empty array of customers
        /// </summary>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Test_OrdersPizzaCount_Theory(int expected)
        {
            var sut = new Aorder();

            var actual = sut.CustomerId;

            Assert.Equal(expected, actual);

        }
    }
}
