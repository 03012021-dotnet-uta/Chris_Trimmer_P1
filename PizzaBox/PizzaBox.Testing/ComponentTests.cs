using Xunit;
using Models.Models;


namespace PizzaBox.Testing
{
    /// <summary>
    /// This is the testing class for Components
    /// Right now this is just a basic test to
    /// set up the testing framework.
    /// It tests to ensure a component is instantiated
    /// with a null name, and that it starts
    /// unassociated with a pizza
    /// </summary>
    public class ComponentTests
    {
        [Fact]
        public void Test_Component_Fact()
        {
            var sut = new Acomponent();
            var expected = 0;

            var actual = sut.PizzaId;

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Barracuda")]
        public void Test_Component_Theory(string expected)
        {
            var sut = new Acomponent();

            var actual = sut.Name;

            Assert.Equal(expected, actual);

        }
    }
}
