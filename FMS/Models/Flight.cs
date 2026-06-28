namespace FMS;
public class Flight
{
    // System Generated
    public int flightId { get; set; }           
    public string flightCode { get; set; }       
    public string flightNumber { get; set; }     

    // User Input
    public int aircraftId { get; set; }          
    public int pilotId { get; set; }             
    public string origin { get; set; }           
    public string destination { get; set; }      
    public DateTime departureDate { get; set; }  
    public DateTime departureTime { get; set; }  
    public double ticketPrice { get; set; }      

    // System Copied 
    public double availableSeats { get; set; }  

    // Defult Value
    public string flightStatus { get; set; }     
}