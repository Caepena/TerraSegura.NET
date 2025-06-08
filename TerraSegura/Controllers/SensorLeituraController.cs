using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerraSegura.Domain.Entity;
using TerraSegura.Domain.Enums;
using TerraSegura.DTOs.TerraSegura.DTOs;
using TerraSegura.Infrastructure.Context;

namespace TerraSegura.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SensorLeituraController : ControllerBase
    {
        private readonly TerraSeguraContext _context;

        public SensorLeituraController(TerraSeguraContext context)
        {
            _context = context;
        }

        // GET: /SensorLeitura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorLeitura>>> GetsensorLeituras()
        {
            return await _context.sensorLeituras.ToListAsync();
        }

        // GET: /SensorLeitura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorLeitura>> GetSensorLeitura(Guid id)
        {
            var sensorLeitura = await _context.sensorLeituras.FindAsync(id);

            if (sensorLeitura == null)
            {
                return NotFound();
            }

            return sensorLeitura;
        }

        // PUT: /SensorLeitura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorLeitura(Guid id, SensorLeitura sensorLeitura)
        {
            if (id != sensorLeitura.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorLeitura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorLeituraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /SensorLeitura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SensorLeitura>> PostSensorLeitura(SensorLeituraCreateDto dto)
        {
            if (!Enum.TryParse<TipoSensor>(dto.TipoSensor, true, out var tipoSensor))
                return BadRequest("TipoSensor inválido.");

            var sensorLeitura = new SensorLeitura(
                dto.Valor,
                dto.DataHora,
                tipoSensor,
                dto.RegiaoMonitoradaId
            );

            _context.sensorLeituras.Add(sensorLeitura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorLeitura", new { id = sensorLeitura.Id }, sensorLeitura);
        }


        // DELETE: /SensorLeitura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorLeitura(Guid id)
        {
            var sensorLeitura = await _context.sensorLeituras.FindAsync(id);
            if (sensorLeitura == null)
            {
                return NotFound();
            }

            _context.sensorLeituras.Remove(sensorLeitura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorLeituraExists(Guid id)
        {
            return _context.sensorLeituras.Any(e => e.Id == id);
        }
    }
}
