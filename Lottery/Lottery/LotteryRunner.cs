using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Lottery
{
    public interface ILotteryRunner
    {
        void Run();
    }

    public class LotteryRunner : ILotteryRunner
    {
        private readonly ILogger<LotteryRunner> _logger;
        private readonly INumberGenerator _numberGenerator;
        private readonly INumberDisplay _numberDisplay;

        public LotteryRunner(
                        ILogger<LotteryRunner> logger, 
                        INumberGenerator numberGenerator,
                        INumberDisplay numberDisplay)
        {
            _logger = logger;
            _numberGenerator = numberGenerator;
            _numberDisplay = numberDisplay;
        }

        public void Run()
        {
            while (true)
            {
                var key = _numberDisplay.AskQuestion();

                if (ConsoleKey.Q == key)
                {
                    break;
                }

                if (ConsoleKey.G != key)
                {
                    _logger.LogInformation("Invalid key");
                    continue;
                }

                _numberGenerator.Shuffle();

                var balls = _numberGenerator.Generate();
                _numberDisplay.Display(balls);

                var bonusBall = _numberGenerator.GenerateBonus();
                _numberDisplay.Display(bonusBall, isBonus: true);
            }
        }
    }
}
