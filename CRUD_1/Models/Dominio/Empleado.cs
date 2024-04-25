using System.ComponentModel.DataAnnotations;

namespace CRUD_1.Models.Dominio
{
    public class Empleado
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Nombre { get; set; }
        public string Email { get; set; }
        public long Salarry { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Departamento { get; set; }
    }
}
