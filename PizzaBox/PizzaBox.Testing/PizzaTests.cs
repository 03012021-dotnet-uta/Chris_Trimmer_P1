using Xunit;
using Models.Models;


namespace PizzaBox.Testing
{
    public class PizzaTests
    {
        /// <summary>
        /// This is the testing class for Pizzas
        /// Right now this is just a basic test to
        /// set up the testing framework.
        /// It tests to ensure a pizza is instantiated
        /// with a null name.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Anything")]
        public void Test_PizzaName_Theory(string expected)
        {
            var sut = new Apizza();

            var actual = sut.Name;

            Assert.Equal(expected, actual);

        }


    }
}
