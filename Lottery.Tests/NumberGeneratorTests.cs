using FluentAssertions;
using Lottery.Lottery;
using NUnit.Framework;

namespace Lottery.Tests
{
    [TestFixture]
    public class NumberGeneratorTests
    {
        [Test]
        public void NumberGenerator_Generates_Correct_Range()
        {
            var expectedRange = Enumerable.Range(1, 49);

            var numberGenerator = new NumberGenerator();
            var numbers = numberGenerator.Generate(fetchAll: true);

            numbers.Min().Should().Be(1);
            numbers.Max().Should().Be(49);
            numbers.Should().BeEquivalentTo(expectedRange);
        }

        [Test]
        public void NumberGenerator_Generates_Ordered_Range()
        {
            var numberGenerator = new NumberGenerator();

            numberGenerator.Shuffle();
            var numbers = numberGenerator.Generate();

            numbers.Should().BeInAscendingOrder();
        }

        [Test]
        public void NumberGenerator_Generates_Correct_Size_Range()
        {
            var numberGenerator = new NumberGenerator();

            numberGenerator.Shuffle();
            var numbers = numberGenerator.Generate();

            numbers.Count().Should().Be(6);
        }


        [Test]
        public void NumberGenerator_Generates_Random_Range()
        {
            var numberGenerator = new NumberGenerator();

            numberGenerator.Shuffle();
            var first = numberGenerator.Generate();
            numberGenerator.Shuffle();
            var second = numberGenerator.Generate();

            first.Should().NotBeEquivalentTo(second);
        }

        [Test]
        public void NumberGenerator_Generates_Unique_Range()
        {
            var numberGenerator = new NumberGenerator();

            numberGenerator.Shuffle();
            var numbers = numberGenerator.Generate();

            numbers.Distinct().Count().Should().Be(numbers.Count());
        }

        [Test]
        public void NumberGenerator_Generates_Unique_Bonus()
        {
            var numberGenerator = new NumberGenerator();

            numberGenerator.Shuffle();
            var numbers = numberGenerator.Generate();
            var bonus = numberGenerator.GenerateBonus();

            numbers.Should().NotContain(bonus);
            bonus.Should().BeGreaterThan(0);
            bonus.Should().BeLessThan(50);
        }
    }
}