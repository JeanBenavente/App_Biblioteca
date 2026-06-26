namespace App_Biblioteca.Domain.DTOs.Autor;

public class AutorResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Nacionalidad { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
}
