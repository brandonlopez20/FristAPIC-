using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relaciones.Models
{
    public class RelacionMuchos
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        // Propiedad de navegación a uno
        public int RelacionUnoId { get; set; }

        public RelacionUno RelacionUno { get; set; }
    }
}
