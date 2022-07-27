using FluentAssertions;
using Lottery.Lottery;
using NUnit.Framework;

namespace Lottery.Tests
{
    [TestFixture]
    public class BallColourProviderTest
    {
        [TestCase(1,9,ConsoleColor.Gray)]
        [TestCase(10, 19, ConsoleColor.Blue)]
        [TestCase(20, 29, ConsoleColor.Magenta)]
        [TestCase(30, 39, ConsoleColor.Green)]
        [TestCase(40, 49, ConsoleColor.Yellow)]
        public void TestColour(int from, int to, ConsoleColor expectedColour)
        {
            var ballColourProvider = new BallColourProvider();

            for(var i = from; i <= to; i++)
            {
                var colour = ballColourProvider.Get(i);

                colour.Should().Be(expectedColour);
            }
        }
    }
}
