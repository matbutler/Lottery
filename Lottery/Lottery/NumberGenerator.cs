namespace Lottery.Lottery
{
    public interface INumberGenerator
    {
        void Shuffle();
        IEnumerable<int> Generate(bool fetchAll = false);
        int GenerateBonus();
    }

    public class NumberGenerator : INumberGenerator
    {
        private IEnumerable<int> _balls = Enumerable.Range(1, 49);
        private readonly int _defaultSelectedBalls = 6;

        public void Shuffle()
        {
            _balls = _balls.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public IEnumerable<int> Generate(bool fetchAll = false)
        {
            var balls = fetchAll ? _balls : _balls.Take(_defaultSelectedBalls);
            return balls.OrderBy(x => x).ToList();
        }

        public int GenerateBonus() => _balls.Skip(_defaultSelectedBalls).First();
    }
}
