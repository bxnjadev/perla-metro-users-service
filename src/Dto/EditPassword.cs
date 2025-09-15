using System.ComponentModel.DataAnnotations;

namespace perla_metro_users_service.Dto;

public class EditPassword
{
    
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
        ErrorMessage = "La contraseña debe contener al menos: una mayúscula, una minúscula, un número y un carácter especial.")]
    public string Password { get; set; } 
    
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
        ErrorMessage = "La contraseña debe contener al menos: una mayúscula, una minúscula, un número y un carácter especial.")]
    public string RepeatPassword { get; set; }
    
}