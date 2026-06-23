namespace FMS;

public class Booking
{
    public int BookingId { get; set; }
    public int passengerId { get; set; }
    public int flightId { get; set; }
    public string seatNumber { get; set; }
    public string bookingDate { get; set; }
    public double totalPrice { get; set; }
    public string status { get; set; }
    
}