namespace Lottery.Lottery
{
    public interface INumberDisplay
    {
        ConsoleKey AskQuestion();
        void Display(int ball, bool isBonus = false);
        void Display(IEnumerable<int> balls);
    }

    public class NumberDisplay : INumberDisplay
    {
        private readonly IBallColourProvider _ballColourProvider;

        public NumberDisplay(IBallColourProvider ballColourProvider)
        {
            _ballColourProvider = ballColourProvider;
        }

        public ConsoleKey AskQuestion()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n\nPress 'G' to Generate Numbers or 'Q' to Quit: ");
            var key = Console.ReadKey().Key;
            Console.Write("\n\n ");
            return key;
        }

        public void Display(int ball, bool isBonus = false)
        {
            if (isBonus)
            {
                Console.Write(" Bonus Ball: ");
            }

            SetBallColour(ball);
            Console.Write(ball.ToString("00"));
            ResetDisplay();
        }
        public void Display(IEnumerable<int> balls)
        {
            foreach (var ball in balls)
            {
                Display(ball);
            }
        }

        private static void ResetDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
        }

        private void SetBallColour(int ball)
        {
            Console.BackgroundColor = _ballColourProvider.Get(ball);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
