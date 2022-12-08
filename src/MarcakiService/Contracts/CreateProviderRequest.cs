namespace MarcakiService.Application.Contracts;

public class CreateProviderRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DocumentRequest DocumentRequest { get; set; }
    public List<PhoneRequest> Phones { get; set; }
    public string Email { get; set; }
    public List<string> Address { get; set; }
    public List<int> Employees { get; set; }
    public List<int> Services { get; set; }
    public List<AvailabilityRequest> Availability { get; set; }
    public string Status { get; set; }
    public string ActivationDate { get; set; }
    public string BlockedDate { get; set; }
    public string CreationDate { get; set; }
    public string BlockedReason { get; set; }
}