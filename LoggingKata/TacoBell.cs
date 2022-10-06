using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        // TacoBell Class implements ITrackable Interface with Name & Location //
        public string Name { get; set; }

        // Point is a struct that represents a GPS Location with Lat & Long //
        public Point Location { get; set; }

        // Constructor //
        public TacoBell(string name, double latitude, double longitude)
        {
            Name = name;
            Location = new Point() { Latitude = latitude, Longitude = longitude };

        }
    }
}

