using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;
using LoggingKata;

namespace LoggingKata
{
    public class RunTaco
    {

        readonly ILog logger = new TacoLogger();

        public void Run(string csvPath)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">> TACO PARSER PROJECT <<\n");
            logger.LogInfo(" Log initialized\n");
            Console.ForegroundColor = prevColor;

            var lines = File.ReadAllLines(csvPath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines.Length == 0)
                {
                    logger.LogError("0 lines");
                }

                if (lines.Length == 1)
                {
                    logger.LogWarning("1 line");
                }
            }

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable taco1 = null;
            ITrackable taco2 = null;
            var corA = new GeoCoordinate();
            var corB = new GeoCoordinate();
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {

                var locA = locations[i];
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    var distanceTo = corA.GetDistanceTo(corB);

                    if (distance < distanceTo)
                    {
                        distance = distanceTo;
                        taco1 = locA;
                        taco2 = locB;
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine($"Taco Bell One: {taco1.Name}");
            Console.WriteLine();
            Console.WriteLine($"Taco Bell Two; {taco2.Name}");
            Console.WriteLine();
            Console.WriteLine($"{Math.Round(distance / 1609)}!!!");

        }
    }
}

