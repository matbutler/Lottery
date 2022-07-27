using Lottery.Lottery;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lottery
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupDIContainer();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogInformation("Starting application");
            
            var lotteryRunner = serviceProvider.GetService<ILotteryRunner>();
            lotteryRunner.Run();

            logger.LogInformation("All done!");
            Console.ReadKey();
        }

        private static ServiceProvider SetupDIContainer()
        {
            return new ServiceCollection()
                            .AddLogging(log =>
                            {
                                log.AddConsole();
                                log.SetMinimumLevel(LogLevel.Debug);
                            })
                            .AddSingleton<ILotteryRunner, LotteryRunner>()
                            .AddSingleton<INumberDisplay, NumberDisplay>()
                            .AddSingleton<INumberGenerator, NumberGenerator>()
                            .AddSingleton<IBallColourProvider, BallColourProvider>()
                            .BuildServiceProvider();
        }
    }
}