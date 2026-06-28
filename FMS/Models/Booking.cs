namespace FMS;

public class Booking
{
    // System Generated
    public int BookingId { get; set; }          

    // User Input
    public int passengerId { get; set; }        
    public int flightId { get; set; }           

    // System Calculated 
    public string seatNumber { get; set; }      

    // System Generated
    public string bookingDate { get; set; }     

    // System Copied
    public double totalPrice { get; set; }      

    // Defult Value
    public string status { get; set; }          
}