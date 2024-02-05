namespace Relaciones.Models
{
    public class Zona
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
