namespace CRUD_1.Models
{
    public class UpdateEmpleadoViewModel
    {
        public Guid Id { get; set; }  //Para el Id de solo lectura
        public string Nombre { get; set; }
        public string Email { get; set; }
        public long Salarry { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Departamento { get; set; }
    }
}
