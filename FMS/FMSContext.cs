namespace FMS;

public class FMSContext
{
    public List<Aircraft>  Aircrafts { get; set; }
    public List<Flight> Flights { get; set; }
    public List<Pilot> Pilots { get; set; }
    public List<Passanger> Passangers { get; set; }
    public List<Booking>  Bookings { get; set; }
}