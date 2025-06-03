namespace SEM10_Max.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateOnly FechaContratacion { get; set; }
        public bool Estado { get; set; }
    }
}
