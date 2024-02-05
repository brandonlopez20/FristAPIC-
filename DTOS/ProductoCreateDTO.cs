namespace Relaciones.DTOS
{
    public class ProductoCreateDTO
    {
        public string Name { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Iva { get; set; }

        public int codigo { get; set; }


        public int stock { get; set; }


        public double peso { get; set; }


        //RELACIONES


        public int ProveedorId { get; set; }
        public int PresentacionId { get; set; }
        public int MarcaId { get; set; }
        public int ZonaId { get; set; }

    }
}
