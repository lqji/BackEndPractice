namespace FMS;

public class FMSContext
{
    public List<Aircraft>  aircrafts { get; set; }
    public List<Flight> flights { get; set; }
    public List<Pilot> pilots { get; set; }
    public List<Passanger> passangers { get; set; }
    public List<Booking>  bookings { get; set; }
}