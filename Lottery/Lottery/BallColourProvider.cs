namespace Lottery.Lottery
{
    public interface IBallColourProvider
    {
        ConsoleColor Get(int number);
    }

    public class BallColourProvider : IBallColourProvider
    {

        public ConsoleColor Get(int number)
        {
            if (number > 39)
            {
                return ConsoleColor.Yellow;
            }
            if (number > 29)
            {
                return ConsoleColor.Green;
            }
            if (number > 19)
            {
                return ConsoleColor.Magenta;
            }
            if (number > 9)
            {
                return ConsoleColor.Blue;
            }

            return ConsoleColor.Gray;
        }
    }
}
