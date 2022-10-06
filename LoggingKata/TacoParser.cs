using System;

namespace LoggingKata
{
    /// Parses a POI file to locate all the Taco Bells
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            logger.LogInfo(" Begin parsing\n");
            Console.ForegroundColor = prevColor;

            string[] cells = line.Split(',');
            if (cells.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                logger.LogError("Something Went Wrong");
                Console.ForegroundColor = prevColor;
                return null;
            }

            var latitude = Double.Parse(cells[0]);
            var longitude = Double.Parse(cells[1]);
            var name = cells[2];

            TacoBell newTacoBell = new TacoBell(name, latitude, longitude);

            return newTacoBell;
        }
    }
}