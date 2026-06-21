namespace App_Biblioteca.Domain.DTOs.Editorial;

public class EditorialResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Pais { get; set; }
}
