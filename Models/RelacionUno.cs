using System.ComponentModel.DataAnnotations;

namespace Relaciones.Models
{
    public class RelacionUno
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        // Propiedad de navegación uno a muchos
        public List<RelacionMuchos> RelacionMuchos { get; set; }

    }
}
