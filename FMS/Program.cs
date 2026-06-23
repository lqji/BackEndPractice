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
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== FLIGHT MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Register a Passenger");
                Console.WriteLine("2. Add an Aircraft");
                Console.WriteLine("3. Register a Pilot");
                Console.WriteLine("4. View All Flights");
                Console.WriteLine("5. Schedule a Flight");
                Console.WriteLine("6. Book a Flight");
                Console.WriteLine("7. Cancel a Booking");
                Console.WriteLine("8. Depart a Flight");
                Console.WriteLine("9. Cancel a Flight");
                Console.WriteLine("10. Passenger Booking History");
                Console.WriteLine("11. Flight Revenue & Load Factor Report");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": RegisterPassenger(); break;
                    case "2": AddAircraft(); break;
                    case "3": RegisterPilot(); break;
                    case "4": ViewAllFlights(); break;
                    case "5": ScheduleFlight(); break;
                    case "6": BookFlight(); break;
                    case "7": CancelBooking(); break;
                    case "8": DepartFlight(); break;
                    case "9": CancelFlight(); break;
                    case "10": PassengerBookingHistory(); break;
                    case "11": FlightRevenueReport(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Invalid choice. Press Enter to try again."); Console.ReadLine(); break;
                }
            }
        }

        public static void RegisterPassenger()
        {
            Console.WriteLine("--- Register a Passenger ---");
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Passport Number: ");
            string passport = Console.ReadLine();
            Console.Write("Enter Nationality: ");
            string nationality = Console.ReadLine();

            int newId = Context.Passangers.Count > 0 ? Context.Passangers.Max(p => p.passengerId) + 1 : 1;

            Passanger passanger = new Passanger
            {
                passengerId = newId,
                passengerName = name,
                passengerEmail = email,
                passengerPhone = phone,
                passportNumber = passport,
                nationality = nationality
            };

            Context.Passangers.Add(passanger);
            Console.WriteLine($"\nSuccess! Passenger registered with ID: {newId}");
            Console.ReadLine();
        }
    }
}
