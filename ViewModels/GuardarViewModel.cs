using System.ComponentModel.DataAnnotations;

public class GuardarViewModel
{
   public GuardarViewModel(){

    }
   
    public int Id { get; set; }
    [Required (ErrorMessage ="El nombre es obligatorio!")][MaxLength(50)]
    public string? Nombre { get; set; }
   [Required (ErrorMessage ="El Telefono es obligatorio!")]
    public string? Telefono { get; set; }
   [Required (ErrorMessage ="El Email es obligatorio!")]
    public string? Email { get; set; }
}