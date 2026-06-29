namespace FMS;

public class Pilot
{
  public int pilotId { get; set; } //system generated
  public string pilotName { get; set; } //user input
  public string pilotPhone { get; set; } //user input 
  public string licenseNumber  { get; set; } // user input
  public string flightHours { get; set; } // system generated
  public bool isAvailable { get; set; } //defult value
}