namespace Shared.Dtos.Clients;

public class CreateClientDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Direccion { get; set; }
    public string? Cuit { get; set; }
}
