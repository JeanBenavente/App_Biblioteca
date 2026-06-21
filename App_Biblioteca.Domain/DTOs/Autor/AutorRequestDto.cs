namespace App_Biblioteca.Domain.DTOs.Autor;

public class AutorRequestDto
{
    public string Nombre { get; set; } = string.Empty;
    public string? Nacionalidad { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
}
