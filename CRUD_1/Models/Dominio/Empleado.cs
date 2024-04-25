namespace CRUD_1.Models.Dominio
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public long Salarry { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Departamento { get; set; }
    }
}
