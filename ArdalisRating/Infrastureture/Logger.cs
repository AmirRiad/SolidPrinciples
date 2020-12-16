using System;

namespace ArdalisRating.Infrastureture
{
    public class Logger : ILogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}
