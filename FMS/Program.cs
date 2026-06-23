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

        public static void AddAircraft()
        {
            Console.WriteLine("--- Add an Aircraft ---");
            Console.Write("Enter Model (e.g., Boeing 737): ");
            string model = Console.ReadLine();
            Console.Write("Enter Total Seats: ");
            int seats = int.Parse(Console.ReadLine());

            int newId = Context.Aircrafts.Count > 0 ? Context.Aircrafts.Max(a => a.aircraftID) + 1 : 1;

            Aircraft aircraft = new Aircraft
            {
                aircraftID = newId,
                model = model,
                totalSeats = seats,
                isOperational = true
            };

            Context.Aircrafts.Add(aircraft);
            Console.WriteLine($"\nSuccess! Aircraft recorded with ID: {newId}");
            Console.ReadLine();
        }

        public static void RegisterPilot()
        {
            Console.WriteLine("--- Register a Pilot ---");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter License Number: ");
            string license = Console.ReadLine();

            int newId = Context.Pilots.Count > 0 ? Context.Pilots.Max(p => p.pilotId) + 1 : 1;

            Pilot pilot = new Pilot
            {
                pilotId = newId,
                pilotName = name,
                pilotPhone = phone,
                licenseNumber = license,
                flightHours = "0",
                isAvailable = true
            };

            Context.Pilots.Add(pilot);
            Console.WriteLine($"\nSuccess! Pilot registered with ID: {newId}");
            Console.ReadLine();
        }

        public static void ViewAllFlights()
        {
            Console.WriteLine("--- All Scheduled Flights ---");
            if (!Context.Flights.Any())
            {
                Console.WriteLine("No flights scheduled yet.");
            }
            else
            {
                foreach (var f in Context.Flights)
                {
                    Console.WriteLine($"Code: {f.flightCode} | {f.origin} -> {f.destination} | Date: {f.departureDate:yyyy-MM-dd} {f.departureTime:HH:mm} | Seats Left: {f.availableSeats} | Price: {f.ticketPrice:F2} OMR | Status: {f.flightStatus}");
                }
            }
            Console.ReadLine();
        }

        public static void ScheduleFlight()
        {
            Console.WriteLine("--- Schedule a New Flight ---");
            Console.Write("Enter Origin City: ");
            string origin = Console.ReadLine();
            Console.Write("Enter Destination City: ");
            string dest = Console.ReadLine();
            Console.Write("Enter Departure Date (yyyy-MM-dd): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.Write("Enter Departure Time (HH:mm): ");
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Enter Ticket Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Aircraft ID: ");
            int targetAircraftId = int.Parse(Console.ReadLine());
            var aircraft = Context.Aircrafts.FirstOrDefault(a => a.aircraftID == targetAircraftId && a.isOperational);

            if (aircraft == null)
            {
                Console.WriteLine("Error: Aircraft not found or is grounded for maintenance.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Pilot ID: ");
            int targetPilotId = int.Parse(Console.ReadLine());
            var pilot = Context.Pilots.FirstOrDefault(p => p.pilotId == targetPilotId && p.isAvailable);

            if (pilot == null)
            {
                Console.WriteLine("Error: Pilot not found or is currently unavailable.");
                Console.ReadLine();
                return;
            }

            int newId = Context.Flights.Count > 0 ? Context.Flights.Max(f => f.flightId) + 1 : 1;
            string generatedCode = $"OA-{100 + newId}";

            Flight flight = new Flight
            {
                flightId = newId,
                flightCode = generatedCode,
                flightNumber = generatedCode,
                aircraftId = aircraft.aircraftID,
                pilotId = pilot.pilotId,
                origin = origin,
                destination = dest,
                departureDate = date,
                departureTime = time,
                ticketPrice = price,
                availableSeats = aircraft.totalSeats,
                flightStatus = "Scheduled"
            };

            pilot.isAvailable = false;
            Context.Flights.Add(flight);
            Console.WriteLine($"\nSuccess! Flight {generatedCode} scheduled successfully.");
            Console.ReadLine();
        }

        public static void BookFlight()
        {
            Console.WriteLine("--- Book a Flight ---");
            Console.Write("Enter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());
            var passanger = Context.Passangers.FirstOrDefault(p => p.passengerId == passengerId);
            if (passanger == null)
            {
                Console.WriteLine("Passenger not found.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Destination City: ");
            string dest = Console.ReadLine();

            var availableFlights = Context.Flights
                .Where(f => f.destination.Equals(dest, StringComparison.OrdinalIgnoreCase) && f.flightStatus == "Scheduled" && f.availableSeats > 0)
                .ToList();

            if (!availableFlights.Any())
            {
                Console.WriteLine("No available scheduled flights to that destination.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\nAvailable Flights:");
            foreach (var f in availableFlights)
            {
                Console.WriteLine($"ID: {f.flightId} | Code: {f.flightCode} | Price: {f.ticketPrice:F2} OMR | Seats Left: {f.availableSeats}");
            }

            Console.Write("\nEnter Flight ID to book: ");
            int targetFlightId = int.Parse(Console.ReadLine());
            var selectedFlight = availableFlights.FirstOrDefault(f => f.flightId == targetFlightId);

            if (selectedFlight == null)
            {
                Console.WriteLine("Invalid selection.");
                Console.ReadLine();
                return;
            }

            selectedFlight.availableSeats--;
            int newBookingId = Context.Bookings.Count > 0 ? Context.Bookings.Max(b => b.BookingId) + 1 : 1;
            string seatLabel = $"{(int)selectedFlight.availableSeats + 1}A";

            Booking booking = new Booking
            {
                BookingId = newBookingId,
                passengerId = passanger.passengerId,
                flightId = selectedFlight.flightId,
                seatNumber = seatLabel,
                bookingDate = DateTime.Now.ToString("yyyy-MM-dd"),
                totalPrice = selectedFlight.ticketPrice,
                status = "Confirmed"
            };

            Context.Bookings.Add(booking);
            Console.WriteLine($"\nSuccess! Booking confirmed. Seat: {seatLabel}, Booking ID: {newBookingId}");
            Console.ReadLine();
        }

        public static void CancelBooking()
        {
            Console.WriteLine("--- Cancel a Booking ---");
            Console.Write("Enter Booking ID: ");
            int targetBookingId = int.Parse(Console.ReadLine());

            var booking = Context.Bookings.FirstOrDefault(b => b.BookingId == targetBookingId && b.status == "Confirmed");
            if (booking == null)
            {
                Console.WriteLine("Confirmed booking not found.");
                Console.ReadLine();
                return;
            }

            var flight = Context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);
            if (flight != null)
            {
                flight.availableSeats++;
            }

            booking.status = "Cancelled";
            Console.WriteLine("Booking successfully cancelled.");
            Console.ReadLine();
        }

        public static void DepartFlight()
        {
            Console.WriteLine("--- Depart a Flight ---");
            Console.Write("Enter Flight ID: ");
            int targetFlightId = int.Parse(Console.ReadLine());

            var flight = Context.Flights.FirstOrDefault(f => f.flightId == targetFlightId && f.flightStatus == "Scheduled");
            if (flight == null)
            {
                Console.WriteLine("Scheduled flight not found.");
                Console.ReadLine();
                return;
            }

            flight.flightStatus = "Departed";

            var pilot = Context.Pilots.FirstOrDefault(p => p.pilotId == flight.pilotId);
            if (pilot != null)
            {
                int.TryParse(pilot.flightHours, out int hours);
                hours += 3;
                pilot.flightHours = hours.ToString();
            }

            Console.WriteLine($"Flight {flight.flightCode} has departed.");
            Console.ReadLine();
        }

        public static void CancelFlight()
        {
            Console.WriteLine("--- Cancel Entire Flight ---");
            Console.Write("Enter Flight ID to cancel: ");
            int targetFlightId = int.Parse(Console.ReadLine());

            var flight = Context.Flights.FirstOrDefault(f => f.flightId == targetFlightId && f.flightStatus == "Scheduled");
            if (flight == null)
            {
                Console.WriteLine("Scheduled flight not found.");
                Console.ReadLine();
                return;
            }

            flight.flightStatus = "Cancelled";

            var pilot = Context.Pilots.FirstOrDefault(p => p.pilotId == flight.pilotId);
            if (pilot != null) pilot.isAvailable = true;

            var associatedBookings = Context.Bookings.Where(b => b.flightId == targetFlightId && b.status == "Confirmed").ToList();
            foreach (var b in associatedBookings)
            {
                b.status = "Cancelled";
            }

            Console.WriteLine($"Flight {flight.flightCode} cancelled. Affected bookings updated: {associatedBookings.Count}");
            Console.ReadLine();
        }
    }
}
