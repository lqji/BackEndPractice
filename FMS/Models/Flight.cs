namespace FMS;

public class Flight
{
    public string flightNumber { get; set; }
    public int flightId { get; set; }
    public string flightStatus { get; set; }
    public string flightCode { get; set; }
    public int aircraftId { get; set; }
    public int pilotId { get; set; }
    public string origin { get; set; }
    public string destination { get; set; }
    public DateTime departureDate { get; set; }
    public DateTime departureTime { get; set; }
    public double ticketPrice { get; set; }
    public double availableSeats { get; set; }
    
}