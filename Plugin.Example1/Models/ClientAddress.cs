namespace Plugin.Example1.Models;

public class ClientAddress
{
    public int Id { get; set; }
    public string BuildingNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string StreetAddress1 { get; set; } = string.Empty;
    public string StreetAddress2 { get; set; } = string.Empty;
    public string StreetAddress3 { get; set; } = string.Empty;
}