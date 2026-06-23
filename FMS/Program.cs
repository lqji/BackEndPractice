using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FMS
{
    internal class Program
    {
        public static FMSContext Context = new FMSContext
        {
            Aircrafts = new List<Aircraft>(),
            Flights = new List<Flight>(),
            Pilots = new List<Pilot>(),
            Passangers = new List<Passanger>(),
            Bookings = new List<Booking>()
        };

        static void Main(string[] args)
        {
        }
    }
}
