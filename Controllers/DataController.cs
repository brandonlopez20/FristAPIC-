using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Relaciones.Models;
using Relaciones.DTOS;
using AutoMapper;

namespace Relaciones.Controllers
{
    [ApiController]
    [Route("api2")]
    public class DataController:ControllerBase
    {

        private readonly AplicationDBContext DB;

        private readonly IMapper MP;


        public DataController(AplicationDBContext db, IMapper mp)
        {
            this.MP = mp;
            this.DB = db;
        }


        [HttpGet]
        public async Task<List<RelacionUno>> GetRelations()
        {
            var relacionesConMuchos = await DB.RelacionesUno
            .Include(r => r.RelacionMuchos)
            .ToListAsync();

            return relacionesConMuchos;
        }


        [HttpPost]
        public IActionResult PostData([FromBody] RelacionUnoDTO nombreRelacionDto)
        {
            if (nombreRelacionDto == null)
            {
                return BadRequest("Datos inválidos");
            }

            var nombreRecibido = MP.Map<RelacionUno>(nombreRelacionDto);


            DB.Add(nombreRecibido);

            DB.SaveChanges();

            // Puedes realizar operaciones adicionales y devolver una respuesta
            return Ok($"Datos recibidos: {nombreRecibido}");
        }


        [HttpPut("{id}")]
        public IActionResult PutData(int id, [FromBody] RelacionUnoDTO nombreRelacionDto)
        {
            if (nombreRelacionDto == null)
            {
                return BadRequest("Datos inválidos");
            }

            // Buscar la entidad existente
            var entidadExistente = DB.RelacionesUno.FirstOrDefault(r => r.Id == id);

            if (entidadExistente == null)
            {
                return NotFound("Entidad no encontrada");
            }

            // Mapear propiedades desde DTO a la entidad existente
            MP.Map(nombreRelacionDto, entidadExistente);

            // Guardar cambios en la base de datos
            DB.SaveChanges();

            // Puedes realizar operaciones adicionales y devolver una respuesta
            return Ok($"Datos actualizados: {entidadExistente}");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            // Buscar la entidad existente
            var entidadExistente = DB.RelacionesUno.FirstOrDefault(r => r.Id == id);

            if (entidadExistente == null)
            {
                return NotFound("Entidad no encontrada");
            }

            // Eliminar la entidad
            DB.RelacionesUno.Remove(entidadExistente);

            // Guardar cambios en la base de datos
            DB.SaveChanges();

            // Puedes realizar operaciones adicionales y devolver una respuesta
            return Ok($"Entidad con ID {id} eliminada exitosamente");
        }



    }
}
