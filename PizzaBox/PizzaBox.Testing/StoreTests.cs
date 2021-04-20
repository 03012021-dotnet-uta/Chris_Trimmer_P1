using Xunit;
using Models.Models;

namespace PizzaBox.Testing
{
    /// <summary>
    /// This is the testing class for Stores
    /// Right now this is just a basic test to
    /// set up the testing framework.
    /// It tests to ensure a store is instantiated
    /// with a null name.
    /// </summary>
    public class StoreTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Charleston")]
        public void Test_StoreName_Theory(string expected)
        {
            var sut = new Astore();

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }

    }
}
