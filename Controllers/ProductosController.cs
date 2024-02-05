using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relaciones.DTOS;
using Relaciones.Models;

namespace Relaciones.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductosController: ControllerBase
    {
        private readonly IMapper MP;
        private readonly AplicationDBContext DB;

        public ProductosController(AplicationDBContext db, IMapper mp)
        {
            this.DB = db;
            this.MP = mp;
        }


        [HttpGet]
        public async Task<List<Producto>> getProductos()
        {
            var data = await DB.Productos
                .Include(p => p.Presentacion)
                .Include(p => p.Marca)
                .Include(p => p.Proveedor)
                .Include(p => p.Zona)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return data;
        }


        [HttpPost]
        [Route("proveedor/{id}")]
        public async Task<List<Producto>> getProductosByProveedor(int id)
        {

            if(id == 0){
                var data1 = await DB.Productos
          .Include(p => p.Presentacion)
          .Include(p => p.Marca)
          .Include(p => p.Proveedor)
          .Include(p => p.Zona)
          .OrderByDescending(p => p.Id)
          .ToListAsync();

                return data1;
            }
            var data = await DB.Productos
                .Include(p => p.Presentacion)
                .Include(p => p.Marca)
                .Include(p => p.Proveedor)
                .Include(p => p.Zona)
                .Where(p => p.ProveedorId == id)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return data;
        }


        [HttpPost]
        public IActionResult createProduct([FromBody] ProductoCreateDTO productoDTO)
        {
            if (productoDTO == null)
            {
                return BadRequest("Datos inválidos");
            }

            var producto = MP.Map<Producto>(productoDTO);


            DB.Add(producto);

            DB.SaveChanges();

            // Puedes realizar operaciones adicionales y devolver una respuesta
            return Ok($"Datos recibidos: {producto}");
        }




        [HttpPut("{id}")]
        public IActionResult PutData(int id, [FromBody] ProductoCreateDTO productoDTO)
        {
            if (productoDTO == null)
            {
                return BadRequest("Datos inválidos");
            }

            // Buscar la entidad existente
            var entidadExistente = DB.Productos.FirstOrDefault(r => r.Id == id);

            if (entidadExistente == null)
            {
                return NotFound("Entidad no encontrada");
            }

            // Mapear propiedades desde DTO a la entidad existente
            // Aquí, asumo que MP es tu AutoMapper. Si no, reemplázalo con tu lógica de mapeo.
            // Asegúrate de configurar AutoMapper correctamente en tu aplicación.
            MP.Map(productoDTO, entidadExistente);

            // Puedes realizar operaciones adicionales aquí antes de guardar cambios
            // ...

            DB.SaveChanges();

            // Devolver una respuesta indicando que los datos se han actualizado correctamente
            return Ok($"Datos actualizados: {entidadExistente}");
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            // Buscar la entidad existente
            var entidadExistente = DB.Productos.FirstOrDefault(r => r.Id == id);

            if (entidadExistente == null)
            {
                return NotFound("Entidad no encontrada");
            }

            // Puedes realizar operaciones adicionales aquí antes de eliminar la entidad
            // ...

            // Eliminar la entidad del contexto
            DB.Productos.Remove(entidadExistente);

            // Guardar los cambios en la base de datos
            DB.SaveChanges();

            // Devolver una respuesta indicando que los datos se han eliminado correctamente
            return Ok($"Datos eliminados: {entidadExistente}");
        }





        //OBTENER OBJETOS

        [HttpPost]
        [Route("zonas")]
        public async Task<List<Zona>> getZonas()
        {
            var data = await DB.Zonas
                .ToListAsync();
            return data;
        }


        [HttpPost]
        [Route("marcas")]
        public async Task<List<Marca>> getMarcas()
        {
            var data = await DB.Marcas
                .ToListAsync();
            return data;
        }



        [HttpPost]
        [Route("Proveedores")]
        public async Task<List<Proveedor>> getProveedores()
        {
            var data = await DB.Proveedores
                .ToListAsync();
            return data;
        }



        [HttpPost]
        [Route("presentaciones")]
        public async Task<List<Presentacion>> getPresentaciones()
        {
            var data = await DB.Presentaciones
                .ToListAsync();
            return data;
        }
    }
}
