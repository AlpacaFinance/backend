namespace AlpacaFinance.API.AlpacaFinance.Domain.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DNI { get; set; }
    public string Email { get; set; }
    public string Direction { get; set; }
    public string Country { get; set; }
    public string Password { get; set; }
    public int Telephone { get; set; }

    public IList<Operacion> Operacions { get; set; } = new List<Operacion>();
    
}